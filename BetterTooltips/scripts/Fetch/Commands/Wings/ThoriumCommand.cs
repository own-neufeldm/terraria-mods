using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
      var path = Path.Join("Stats", "Wings", "ThoriumMod.json");
      AssetHelpers.WriteJson(stats, path);
      return 0;
    }

    private static List<WingModel> ParseStats(HtmlNode root)
    {
      throw new System.NotImplementedException();
    }
  }
}
