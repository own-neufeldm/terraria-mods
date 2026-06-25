[CmdletBinding()]
param(
  [Parameter(Mandatory = $false, Position = 0)]
  [string]$Command,

  [Parameter(Mandatory = $false, Position = 1)]
  [string]$Mod
)

function Show-Usage {
  Write-Host "Usage: .\mods.ps1 COMMAND [MOD]"
  Write-Host ""
  Write-Host "Manage symlinks for tModLoader mod sources."
  Write-Host ""
  Write-Host "Commands:"
  Write-Host "  link MOD    Create a symlink for MOD."
  Write-Host "  list        List all symlinks."
  Write-Host "  unlink MOD  Remove the symlink for MOD."
  Write-Host ""
  Write-Host "Target: $TargetBase"
}

$ErrorActionPreference = "Stop"
$SourceBase = $PSScriptRoot
$TargetBase = Join-Path $HOME "Documents\My Games\Terraria\tModLoader\ModSources"

function New-ModLink {
  param([string]$Mod)
  if ([string]::IsNullOrWhiteSpace($Mod)) {
    Write-Host "[ERROR] The 'link' command requires a MOD name." -ForegroundColor Red
    return
  }

  $SourcePath = Join-Path $SourceBase $Mod
  $TargetPath = Join-Path $TargetBase $Mod

  if (-not (Test-Path -Path $SourcePath -PathType Container)) {
    Write-Host "[ERROR] Mod does not exist: $SourcePath" -ForegroundColor Red
    return
  }

  $CurrentIdentity = [Security.Principal.WindowsIdentity]::GetCurrent()
  $Principal = [Security.Principal.WindowsPrincipal]$CurrentIdentity
  $IsAdmin = $Principal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
  if (-not $IsAdmin) {
      Start-Process -FilePath "pwsh.exe" -Verb "RunAs" -ArgumentList "-NoExit -File `"$PSCommandPath`"", "`"$Command`"", "`"$Mod`""
      return
  }

  New-Item -ItemType SymbolicLink -Path $TargetPath -Value $SourcePath | Out-Null
  Write-Host "[INFO] Mod symlink created." -ForegroundColor Green
}

function Get-ModList {
  if (-not (Test-Path -Path $TargetBase -PathType Container)) {
    Write-Host "[ERROR] Mod sources directory does not exist: $TargetBase" -ForegroundColor Red
    return
  }

  Get-ChildItem -Path $TargetBase -Directory | Select-Object -ExpandProperty Name
}

function Remove-ModLink {
  param([string]$Mod)
  if ([string]::IsNullOrWhiteSpace($Mod)) {
    Write-Host "[ERROR] The 'unlink' command requires a MOD name." -ForegroundColor Red
    return
  }

  $TargetPath = Join-Path $TargetBase $Mod

  if (-not (Test-Path -Path $TargetPath)) {
    Write-Host "[ERROR] Mod symlink does not exist: $TargetPath" -ForegroundColor Red
    return
  }

  Remove-Item -Path $TargetPath -Force
  Write-Host "[INFO] Mod symlink removed." -ForegroundColor Green
}

switch ($Command.ToLower()) {
  "link"   { New-ModLink -Mod $Mod }
  "list"   { Get-ModList }
  "unlink" { Remove-ModLink -Mod $Mod }
  Default  { Show-Usage }
}
