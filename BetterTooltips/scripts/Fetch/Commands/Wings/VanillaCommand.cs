using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
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
      var url = "https://terraria.wiki.gg/wiki/Wings/List";
      var document = HtmlHelpers.GetWebDocument(url);
      var stats = ParseStats(document.DocumentNode);
      var path = Path.Join("Stats", "Wings", "Vanilla.json");
      AssetHelpers.WriteJson(stats, path);
      return 0;
    }

#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    private static List<WingModel> ParseStats(HtmlNode root)
    {
      var stats = new List<WingModel>();
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
  }
}
