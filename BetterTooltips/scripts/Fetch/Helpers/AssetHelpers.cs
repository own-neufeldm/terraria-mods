using System.IO;
using Newtonsoft.Json;

namespace Fetch.Helpers
{
  public static class AssetHelpers
  {
    public static string GetDirectory()
    {
      return Path.Join("..", "..", "Assets");
    }

    public static void WriteJson(object data, string path)
    {
      path = Path.Join(GetDirectory(), path);
      Directory.CreateDirectory(Path.GetDirectoryName(path));
      var json = JsonConvert.SerializeObject(data, Formatting.Indented);
      File.WriteAllText(path, json);
    }
  }
}