using Terraria;

namespace BetterTooltips.Helpers
{
  public static class InventoryHelpers
  {
    public static bool IsHoveringSocialSlot()
    {
      return Main.HoverItem.social;
    }
  }
}
