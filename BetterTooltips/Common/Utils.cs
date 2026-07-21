using System;
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

    public static int GreaterIsBetter<T>(T a, T b)
    where T : IComparisonOperators<T, T, bool>
    {
      if (a > b) return -1;
      if (a < b) return 1;
      return 0;
    }

    public static int LessIsBetter<T>(T a, T b)
where T : IComparisonOperators<T, T, bool>
    {
      if (a < b) return -1;
      if (a > b) return 1;
      return 0;
    }

    public static string GetComparisonText(
      float hovered,
      float equipped,
      Func<float, float, int> comparer
    )
    {
      var colorHex = GetComparisonColorHex(hovered, equipped, comparer);
      return $"[c/{colorHex}:{equipped:0.##}]";
    }

    public static string GetComparisonText(
      int hovered,
      int equipped,
      Func<int, int, int> comparer
    )
    {
      var colorHex = GetComparisonColorHex(hovered, equipped, comparer);
      return $"[c/{colorHex}:{equipped}]";
    }

    public static string GetComparisonColorHex<T>(
      T hovered,
      T equipped,
      Func<T, T, int> comparer
    )
    {
      var result = comparer(hovered, equipped);
      if (result < 0) return "00FF00"; // green
      if (result > 0) return "FF0000"; // red
      return "FFFF00";                 // yellow
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
