using System.Collections.Generic;
using BetterTooltips.Common.Stats;
using BetterTooltips.Common.Systems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Items
{
  public class HookItem : GlobalItem
  {
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
      if (!IsHook(item) || Utils.IsHoveringSocialSlot()) return;

      var empty = HookStat.Empty();
      var hovered = HookSystem.Cache.GetValueOrDefault(item.type, empty);
      var equipped = Main.LocalPlayer.miscEquips[4] is not Item hook ? empty
        : HookSystem.Cache.GetValueOrDefault(hook.type, empty);

      tooltips.Add(GetReachTooltip(hovered.Reach, equipped.Reach));
      tooltips.Add(GetVelocityTooltip(hovered.Velocity, equipped.Velocity));
      tooltips.Add(GetHooksTooltip(hovered.Hooks, equipped.Hooks));
    }

    private static bool IsHook(Item item)
    {
      return item.shoot != ProjectileID.None && Main.projHook[item.shoot];
    }

    private TooltipLine GetReachTooltip(int hovered, int equipped)
    {
      var comparer = Utils.GreaterIsBetter<int>;
      var comparison = Utils.GetComparisonText(hovered, equipped, comparer);
      var text = $"Reach: {hovered} ({comparison})";
      return new TooltipLine(Mod, "HookReach", text);
    }

    private TooltipLine GetVelocityTooltip(int hovered, int equipped)
    {
      var comparer = Utils.GreaterIsBetter<int>;
      var comparison = Utils.GetComparisonText(hovered, equipped, comparer);
      var text = $"Velocity: {hovered} ({comparison})";
      return new TooltipLine(Mod, "HookVelocity", text);
    }

    private TooltipLine GetHooksTooltip(int hovered, int equipped)
    {
      var comparer = Utils.GreaterIsBetter<int>;
      var comparison = Utils.GetComparisonText(hovered, equipped, comparer);
      var text = $"Hooks: {hovered} ({comparison})";
      return new TooltipLine(Mod, "HookHooks", text);
    }
  }
}
