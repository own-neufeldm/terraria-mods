using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using Fetch.Helpers;
using Fetch.Models;
using HtmlAgilityPack;
using Spectre.Console.Cli;

namespace Fetch.Commands.Hooks
{
  public class ThoriumSettings : CommandSettings { }

  [Description("Fetch stats for Thorium Mod hooks")]
  public class ThoriumCommand : Command<ThoriumSettings>
  {
    protected override int Execute(
      CommandContext context,
      ThoriumSettings settings,
      CancellationToken cancellationToken
    )
    {
      var url = "https://thoriummod.wiki.gg/wiki/Hooks";
      var document = HtmlHelpers.GetWebDocument(url);
      var stats = ParseStats(document.DocumentNode);
      AssetHelpers.WriteJson(stats, "Stats/Hooks/ThoriumMod.json");
      return 0;
    }

    private static List<HookModel> ParseStats(HtmlNode root)
    {
      var stats = new List<HookModel>();
      var tables = root.SelectNodes("//table").ToList().GetRange(0, 2);

      foreach (var table in tables)
      {
        foreach (var row in table.SelectNodes(".//tr"))
        {
          var cols = row.SelectNodes(".//td");
          if (cols == null) continue;
          stats.Add(new(
            Name: ParseName(cols[1]),
            ID: 0,
            Reach: ParseReach(cols[3]),
            Velocity: ParseVelocity(cols[4]),
            Hooks: ParseHooks(cols[5])
          ));
        }
      }

      return stats;
    }

    private static string ParseName(HtmlNode col)
    {
      return HtmlHelpers.GetInnerText(col);
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
      return (int)(floatValue + 0.5f);
    }

    private static int ParseHooks(HtmlNode col)
    {
      var value = HtmlHelpers.GetInnerText(col);
      return int.Parse(value);
    }
  }
}
