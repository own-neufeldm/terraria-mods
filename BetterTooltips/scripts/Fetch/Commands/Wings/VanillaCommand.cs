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
  public class VanillaSettings : CommandSettings { }

  [Description("Fetch stats for Vanilla wings")]
  public class VanillaCommand : Command<VanillaSettings>
  {
    protected override int Execute(
      CommandContext context,
      VanillaSettings settings,
      CancellationToken cancellationToken
    )
    {
      var url = "https://terraria.wiki.gg/wiki/Wings";
      var document = HtmlHelpers.GetWebDocument(url);
      var stats = ParseStats(document.DocumentNode);
      AssetHelpers.WriteJson(stats, "Stats/Wings/Vanilla.json");
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
        (var name, var id) = ParseNameAndID(cols[1]);
        stats.Add(new(
          Name: name,
          ID: id,
          FlightTime: ParseFlightTime(cols[4]),
          Height: ParseHeight(cols[5]),
          SpeedBonus: ParseSpeedBonus(cols[7])
        ));
      }

      return stats;
    }

#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    private static (string, int) ParseNameAndID(HtmlNode col)
    {
      var value = HtmlHelpers.GetInnerText(col);
      var match = Regex.Match(value, @"(?<name>.+)\s*Internal\s*Item\s*ID:\s*(?<id>.+)");
      return (match.Groups["name"].Value, int.Parse(match.Groups["id"].Value));
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
      return int.Parse(match.Groups["value"].Value) - 100;
    }
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
  }
}
