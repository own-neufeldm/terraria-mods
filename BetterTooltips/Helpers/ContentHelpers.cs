using System;
using System.Collections.Generic;
using System.Text;
using Terraria.ModLoader;

namespace BetterTooltips.Helpers
{
  public static class ContentHelpers
  {
    public static ModItem FindItem(Mod mod, string name)
    {
      var comparator = StringComparison.OrdinalIgnoreCase;
      var items = new List<ModItem>();
      foreach (ILoadable loadable in mod.GetContent())
      {
        if (loadable is not ModItem item) continue;
        items.Add(item);
        if (item.Name.Equals(name, comparator)) return item;
      }
      items.Sort((a, b) => a.Name.CompareTo(b.Name));
      foreach (ModItem item in items) mod.Logger.Debug(item.Name);
      throw new Exception($"Unable to find '{mod.Name}/{name}' item.");
    }

    public static string ReadFile(string path)
    {
      var mod = ModContent.GetInstance<BetterTooltips>();
      var bytes = mod.GetFileBytes(path);
      return Encoding.UTF8.GetString(bytes);
    }
  }
}
