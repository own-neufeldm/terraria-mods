using HtmlAgilityPack;

namespace Fetch.Helpers
{
  public static class HtmlHelpers
  {
    public static HtmlDocument GetWebDocument(string url)
    {
      var web = new HtmlWeb { UserAgent = "dotnet/htmlagilitypack" };
      return web.Load(url);
    }

    public static string GetInnerText(HtmlNode node)
    {
      return HtmlEntity.DeEntitize(node.InnerText).Trim();
    }
  }
}
