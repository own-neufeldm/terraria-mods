using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Fetch.Helpers;
using Fetch.Models;
using HtmlAgilityPack;
using Spectre.Console.Cli;

namespace Fetch.Commands.Hooks
{
  public class VanillaSettings : CommandSettings { }

  [Description("Fetch stats for Vanilla hooks")]
  public class VanillaCommand : Command<VanillaSettings>
  {
    protected override int Execute(
      CommandContext context,
      VanillaSettings settings,
      CancellationToken cancellationToken
    )
    {
      var url = "https://terraria.wiki.gg/wiki/Hooks";
      var document = HtmlHelpers.GetWebDocument(url);
      var stats = ParseStats(document.DocumentNode);
      AssetHelpers.WriteJson(stats, "Stats/Hooks/Vanilla.json");
      return 0;
    }

    private static List<HookModel> ParseStats(HtmlNode root)
    {
      var stats = new List<HookModel>();
      var tables = root.SelectNodes("//table").ToList().GetRange(1, 2);

      foreach (var table in tables)
      {
        foreach (var row in table.SelectNodes(".//tr"))
        {
          var cols = row.SelectNodes(".//td");
          if (cols == null) continue;
          (var name, var id) = ParseNameAndID(cols[1]);
          stats.Add(new(
            Name: name,
            ID: id,
            Reach: ParseReach(cols[5]),
            Velocity: ParseVelocity(cols[6]),
            Hooks: ParseHooks(cols[3])
          ));
        }
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

    private static int ParseReach(HtmlNode col)
    {
      var stringValue = HtmlHelpers.GetInnerText(col);
      var floatValue = float.Parse(stringValue, CultureInfo.InvariantCulture);
      return (int)(floatValue + 0.5f);
    }

    private static int ParseVelocity(HtmlNode col)
    {
      var stringValue = HtmlHelpers.GetInnerText(col);
      var floatValue = float.Parse(stringValue, CultureInfo.InvariantCulture);
      return (int)(floatValue * 42240.0f / 216000.0f + 0.5f);
    }

    private static int ParseHooks(HtmlNode col)
    {
      var value = HtmlHelpers.GetInnerText(col);
      return int.Parse(value);
    }
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
  }
}
