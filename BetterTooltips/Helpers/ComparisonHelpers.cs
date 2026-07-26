using System;
using System.Numerics;

namespace BetterTooltips.Helpers
{
  public static class ComparisonHelpers
  {
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

    public static string GetText(
      float hovered,
      float equipped,
      Func<float, float, int> comparer
    )
    {
      var colorHex = GetColorHex(hovered, equipped, comparer);
      return $"[c/{colorHex}:{equipped:0.##}]";
    }

    public static string GetText(
      int hovered,
      int equipped,
      Func<int, int, int> comparer
    )
    {
      var colorHex = GetColorHex(hovered, equipped, comparer);
      return $"[c/{colorHex}:{equipped}]";
    }

    public static string GetColorHex<T>(
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
  }
}