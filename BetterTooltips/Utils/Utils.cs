using Terraria;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace BetterTooltips
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
  public static class Utils
  {
    public static bool HoveringSocialSlot()
    {
      return Main.HoverItem.social;
    }

    public static string GetComparisonText(float hoveredValue, float equippedValue)
    {
      return $"[c/{GetColorHex(hoveredValue, equippedValue)}:{equippedValue:0.##}]";
    }

    public static string GetColorHex(float hoveredValue, float equippedValue)
    {
      if (hoveredValue < equippedValue) return "FF0000"; // red
      if (hoveredValue > equippedValue) return "00FF00"; // green
      return "FFFFFF";                                   // white
    }
  }
}
