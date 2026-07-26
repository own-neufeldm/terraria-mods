using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using Fetch.Helpers;
using Fetch.Models;
using HtmlAgilityPack;
using Spectre.Console.Cli;

namespace Fetch.Commands.Wings
{
  public class ThoriumSettings : CommandSettings { }

  [Description("Fetch stats for Thorium Mod wings")]
  public class ThoriumCommand : Command<ThoriumSettings>
  {
    protected override int Execute(
      CommandContext context,
      ThoriumSettings settings,
      CancellationToken cancellationToken
    )
    {
      var url = "https://thoriummod.wiki.gg/wiki/Wings";
      var document = HtmlHelpers.GetWebDocument(url);
      var stats = ParseStats(document.DocumentNode);
      AssetHelpers.WriteJson(stats, "Stats/Wings/ThoriumMod.json");
      return 0;
    }

    private static List<WingModel> ParseStats(HtmlNode root)
    {
      var stats = new List<WingModel>();
      var table = root.SelectNodes("//table")[1];

      foreach (var row in table.SelectNodes(".//tr"))
      {
        var cols = row.SelectNodes(".//td");
        if (cols == null) continue;
        stats.Add(new(
          Name: ParseName(cols[1]),
          ID: 0,
          FlightTime: ParseFlightTime(cols[4]),
          Height: ParseHeight(cols[5]),
          SpeedBonus: ParseSpeedBonus(cols[6])
        ));
      }

      return stats;
    }

#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    private static string ParseName(HtmlNode col)
    {
      return HtmlHelpers.GetInnerText(col);
    }

    private static float ParseFlightTime(HtmlNode col)
    {
      var value = HtmlHelpers.GetInnerText(col);
      var match = Regex.Match(value, @"(?<value>[\d.]+)");
      return float.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
    }

    private static int ParseHeight(HtmlNode col)
    {
      var value = HtmlHelpers.GetInnerText(col);
      var match = Regex.Match(value, @"(?<value>\d+)");
      return int.Parse(match.Groups["value"].Value);
    }

    private static int ParseSpeedBonus(HtmlNode col)
    {
      var value = HtmlHelpers.GetInnerText(col);
      var match = Regex.Match(value, @"(?<value>\d+)");
      return int.Parse(match.Groups["value"].Value);
    }
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
  }
}
