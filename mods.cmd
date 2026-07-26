@echo off
setlocal EnableDelayedExpansion

goto :MAIN
:USAGE
echo Usage: mods.cmd COMMAND [MOD]
echo.
echo Manage symlinks for tModLoader mod sources.
echo.
echo Commands:
echo   add MOD     Create a symlink for MOD.
echo   list        List all symlinks.
echo   remove MOD  Remove the symlink for MOD.
goto :EOF

:MAIN
set "SOURCE_DIR=%USERPROFILE%\repos\own-neufeldm\terraria-mods"
set "TARGET_DIR=%USERPROFILE%\Documents\My Games\Terraria\tModLoader\ModSources"

if /i "%~1"=="add" goto AddMod
if /i "%~1"=="list" goto ListMods
if /i "%~1"=="remove" goto RemoveMod
goto :USAGE

:AddMod
if "%~2"=="" goto :USAGE
sudo mklink /d "%TARGET_DIR%\%~2" "%SOURCE_DIR%\%~2"
goto :EOF

:ListMods
dir "%TARGET_DIR%" /ad /b
goto :EOF

:RemoveMod
if "%~2"=="" goto :USAGE
rmdir "%TARGET_DIR%\%~2"
goto :EOF
