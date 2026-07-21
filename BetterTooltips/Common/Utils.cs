using System.Collections.Generic;
using System.Numerics;
using Terraria;
using Terraria.ModLoader;

namespace BetterTooltips.Common
{
  public static class Utils
  {
    public static bool IsHoveringSocialSlot()
    {
      return Main.HoverItem.social;
    }

    public static string GetComparisonText(float hovered, float equipped)
    {
      return $"[c/{GetComparisonColorHex(hovered, equipped)}:{equipped:0.##}]";
    }

    public static string GetComparisonText(int hovered, int equipped)
    {
      return $"[c/{GetComparisonColorHex(hovered, equipped)}:{equipped:0}]";
    }

    public static string GetComparisonColorHex<T>(T hovered, T equipped)
      where T : IComparisonOperators<T, T, bool>
    {
      if (hovered < equipped) return "FF0000"; // red
      if (hovered > equipped) return "00FF00"; // green
      return "FFFF00";                         // yellow
    }

    public static ModItem FindItem(Mod mod, string name)
    {
      var comparator = System.StringComparison.OrdinalIgnoreCase;
      var items = new List<ModItem>();
      foreach (ILoadable loadable in mod.GetContent())
      {
        if (loadable is not ModItem item) continue;
        items.Add(item);
        if (item.Name.Equals(name, comparator)) return item;
      }
      items.Sort((a, b) => a.Name.CompareTo(b.Name));
      foreach (ModItem item in items) mod.Logger.Debug(item.Name);
      throw new System.Exception($"Unable to find '{mod.Name}/{name}' item.");
    }
  }
}
