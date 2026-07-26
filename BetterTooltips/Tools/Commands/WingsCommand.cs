using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Tools.Commands
{
  public enum ModTarget
  {
    vanilla,
    thorium,
  }

  public record WingStat(
    string Name,
    int ID,
    float FlightTime,
    int Height,
    int SpeedBonus
  );

  public class WingsSettings : CommandSettings
  {
    [CommandOption("--mod")]
    [Description("Fetch data for this mod")]
    [DefaultValue(ModTarget.vanilla)]
    public ModTarget ModTarget { get; init; } = ModTarget.vanilla;
  }

  [Description("Fetch wiki data for wings")]
  public class WingsCommand : Command<WingsSettings>
  {
    protected override int Execute(
      CommandContext context,
      WingsSettings settings,
      CancellationToken cancellation
    )
    {
      if (settings.ModTarget == ModTarget.vanilla)
      {
        var data = DownloadData("https://terraria.wiki.gg/wiki/Wings/List");
        var stats = ParseVanillaStats(data.DocumentNode);
        WriteStats(stats, "Vanilla.json");
        return 0;
      }

      var message = $"Mod '{settings.ModTarget}' is not implemented.";
      AnsiConsole.WriteException(new NotImplementedException(message));
      return 1;
    }

    private static HtmlDocument DownloadData(string url)
    {
      return new HtmlWeb { UserAgent = "dotnet/htmlagilitypack" }.Load(url);
    }

    // https://thoriummod.wiki.gg/wiki/Wings [2]
#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    private static List<WingStat> ParseVanillaStats(HtmlNode root)
    {
      var stats = new List<WingStat>();
      var table = root.SelectNodes("//table[1]")[0];

      foreach (HtmlNode row in table.SelectNodes(".//tr"))
      {
        var cols = row.SelectNodes(".//td");
        if (cols == null) continue;

        string value = HtmlEntity.DeEntitize(cols[1].InnerText).Trim();
        var match = Regex.Match(value, @"(?<name>.+)\s*Internal\s*Item\s*ID:\s*(?<id>.+)");
        string name = match.Groups["name"].Value;
        int id = int.Parse(match.Groups["id"].Value);

        value = HtmlEntity.DeEntitize(cols[4].InnerText).Trim();
        match = Regex.Match(value, @"(?<value>[\d.]+)");
        float flightTime = float.Parse(
          match.Groups["value"].Value,
          CultureInfo.InvariantCulture
        );

        value = HtmlEntity.DeEntitize(cols[5].InnerText).Trim();
        match = Regex.Match(value, @"(?<value>\d+)");
        int height = int.Parse(match.Groups["value"].Value);

        value = HtmlEntity.DeEntitize(cols[7].InnerText).Trim();
        match = Regex.Match(value, @"(?<value>\d+)");
        int speedBonus = int.Parse(match.Groups["value"].Value) - 100;

        stats.Add(new(name, id, flightTime, height, speedBonus));
      }

      return stats;
    }
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.

    private static void WriteStats(object stats, string fileName)
    {
      var path = Path.Join("..", "Assets", "Stats", "Wings", fileName);
      var json = JsonConvert.SerializeObject(stats, Formatting.Indented);
      File.WriteAllText(path, json);
    }
  }
}
