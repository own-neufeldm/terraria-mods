using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace BetterTooltips.Tooltips
{
  public class Wing : GlobalItem
  {
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
      if (!IsWing(item) || Utils.HoveringSocialSlot()) return;

      var player = Main.LocalPlayer;
      var hoveredStats = player.GetWingStats(item.wingSlot);

      WingStats? equippedStats =
        player.equippedWings != null && player.equippedWings.type != item.type
        ? player.GetWingStats(player.equippedWings.wingSlot)
        : null;

      tooltips.Add(GetFlightTimeLine(hoveredStats, equippedStats));
      tooltips.Add(GetVerticalOverrideLine(hoveredStats, equippedStats));
      tooltips.Add(GetHorizontalMultiplierLine(hoveredStats, equippedStats));

      // todo: compare to Wings and Hook Stats mod
      //
      // tooltips.Add(GetFlightTimeLine(hoveredStats, equippedStats));
      // tooltips.Add(GetHeightLine(hoveredStats, equippedStats));
      // tooltips.Add(GetHorizontalAccelerationLine(hoveredStats, equippedStats));
    }

    private TooltipLine GetFlightTimeLine(WingStats hoveredStats, WingStats? equippedStats)
    {
      float hoveredValue = GetFlightTimeInSeconds(hoveredStats);
      string text = $"Flight time: {hoveredValue:0.##} seconds";
      if (equippedStats != null)
      {
        float equippedValue = GetFlightTimeInSeconds((WingStats)equippedStats);
        text += $" ({Utils.GetComparisonText(hoveredValue, equippedValue)})";
      }
      return new(Mod, "WingFlightTime", text);
    }

    private TooltipLine GetVerticalOverrideLine(WingStats hoveredStats, WingStats? equippedStats)
    {
      float hoveredValue = GetVerticalOverride(hoveredStats);
      string text = $"Vertical override: {hoveredValue:0.##}";
      if (equippedStats != null)
      {
        float equippedValue = GetVerticalOverride((WingStats)equippedStats);
        text += $" ({Utils.GetComparisonText(hoveredValue, equippedValue)})";
      }
      return new(Mod, "WingVerticalOverride", text);
    }

    private TooltipLine GetHorizontalMultiplierLine(WingStats hoveredStats, WingStats? equippedStats)
    {
      float hoveredValue = GetHorizontalMultiplier(hoveredStats);
      string text = $"Horizontal multiplier: {hoveredValue:0.##}";
      if (equippedStats != null)
      {
        float equippedValue = GetHorizontalMultiplier((WingStats)equippedStats);
        text += $" ({Utils.GetComparisonText(hoveredValue, equippedValue)})";
      }
      return new(Mod, "WingHorizontalMultiplier", text);
    }

    private static bool IsWing(Item item)
    {
      return item.wingSlot > 0;
    }

    private static float GetFlightTimeInSeconds(WingStats stats)
    {
      return stats.FlyTime / 60f;
    }

    private static float GetVerticalOverride(WingStats stats)
    {
      return stats.AccRunSpeedOverride;
    }

    private static float GetHorizontalMultiplier(WingStats stats)
    {
      return stats.AccRunAccelerationMult;
    }
  }
}
