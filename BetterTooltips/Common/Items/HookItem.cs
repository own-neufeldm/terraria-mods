using System.Collections.Generic;
using BetterTooltips.Common.Stats;
using BetterTooltips.Common.Systems;
using BetterTooltips.Helpers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Items
{
  public class HookItem : GlobalItem
  {
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
      // Calamity Mod has its own tooltips for hooks
      if (ModLoader.HasMod("CalamityMod")) return;

      if (!IsHook(item) || InventoryHelpers.IsHoveringSocialSlot()) return;

      var fallback = HookStat.Empty();
      var hovered = HookSystem.Cache.GetValueOrDefault(item.type, fallback);
      var equipped = GetEquippedOrDefault(fallback);

      tooltips.Add(GetReachTooltip(hovered.Reach, equipped.Reach));
      tooltips.Add(GetVelocityTooltip(hovered.Velocity, equipped.Velocity));
      tooltips.Add(GetHooksTooltip(hovered.Hooks, equipped.Hooks));
    }

    private static bool IsHook(Item item)
    {
      return item.shoot != ProjectileID.None && Main.projHook[item.shoot];
    }

    private static HookStat GetEquippedOrDefault(HookStat fallback)
    {
      if (Main.LocalPlayer.miscEquips[4] is not Item hook) return fallback;
      return HookSystem.Cache.GetValueOrDefault(hook.type, fallback);
    }

    private TooltipLine GetReachTooltip(int hovered, int equipped)
    {
      var comparator = ComparisonHelpers.GreaterIsBetter<int>;
      var comparison = ComparisonHelpers.GetText(hovered, equipped, comparator);
      var text = $"Reach: {hovered} tiles ({comparison})";
      return new TooltipLine(Mod, "HookReach", text);
    }

    private TooltipLine GetVelocityTooltip(int hovered, int equipped)
    {
      var comparator = ComparisonHelpers.GreaterIsBetter<int>;
      var comparison = ComparisonHelpers.GetText(hovered, equipped, comparator);
      var text = $"Velocity: {hovered} pixels ({comparison})";
      return new TooltipLine(Mod, "HookVelocity", text);
    }

    private TooltipLine GetHooksTooltip(int hovered, int equipped)
    {
      var comparator = ComparisonHelpers.GreaterIsBetter<int>;
      var comparison = ComparisonHelpers.GetText(hovered, equipped, comparator);
      var text = $"Hooks: {hovered} at once ({comparison})";
      return new TooltipLine(Mod, "HookHooks", text);
    }
  }
}
