using System.Collections.Generic;
using BetterTooltips.Common.Stats;
using BetterTooltips.Common.Systems;
using Terraria;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Items
{
  public class WingItem : GlobalItem
  {
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
      if (!IsWing(item) || Utils.IsHoveringSocialSlot()) return;

      var empty = WingStat.Empty();
      var hovered = WingSystem.Cache.GetValueOrDefault(item.type, empty);
      var equipped = Main.LocalPlayer.equippedWings is not Item wings ? empty
        : WingSystem.Cache.GetValueOrDefault(wings.type, empty);

      tooltips.Add(GetFlightTimeTooltip(hovered.FlightTime, equipped.FlightTime));
      tooltips.Add(GetHeightTooltip(hovered.Height, equipped.Height));
      tooltips.Add(GetSpeedBonusTooltip((int)hovered.SpeedBonus * 100, (int)equipped.SpeedBonus * 100));
    }

    private static bool IsWing(Item item)
    {
      return item.wingSlot > 0;
    }

    private TooltipLine GetFlightTimeTooltip(float hovered, float equipped)
    {
      var comparer = Utils.GreaterIsBetter<float>;
      var comparison = Utils.GetComparisonText(hovered, equipped, comparer);
      var text = $"Flight time: {hovered:0.##} seconds ({comparison})";
      return new TooltipLine(Mod, "WingFlightTime", text);
    }

    private TooltipLine GetHeightTooltip(int hovered, int equipped)
    {
      var comparer = Utils.GreaterIsBetter<int>;
      var comparison = Utils.GetComparisonText(hovered, equipped, comparer);
      var text = $"Height: {hovered} tiles ({comparison})";
      return new TooltipLine(Mod, "WingHeight", text);
    }

    private TooltipLine GetSpeedBonusTooltip(int hovered, int equipped)
    {
      var comparer = Utils.GreaterIsBetter<int>;
      var comparison = Utils.GetComparisonText(hovered, equipped, comparer);
      var text = $"Speed bonus: +{hovered}% ({comparison})";
      return new TooltipLine(Mod, "WingSpeedBonus", text);
    }
  }
}
