using System.Collections.Generic;
using BetterTooltips.Common.Stats;
using BetterTooltips.Helpers;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Systems
{
  public class HookSystem : ModSystem
  {
    public static Dictionary<int, HookStat> Cache { get; } = [];

    public override void PostSetupContent()
    {
      AddVanilla();
      AddCalamityMod();
      AddThoriumMod();
    }

    private static void AddVanilla()
    {
      Cache.Add(84, new(19, 12, 1)); // Grappling Hook
      Cache.Add(1236, new(19, 10, 1)); // Amethyst Hook
      Cache.Add(4759, new(19, 12, 1)); // Squirrel Hook
      Cache.Add(1237, new(21, 11, 1)); // Topaz Hook
      Cache.Add(1238, new(23, 11, 1)); // Sapphire Hook
      Cache.Add(1239, new(24, 12, 1)); // Emerald Hook
      Cache.Add(1240, new(26, 12, 1)); // Ruby Hook
      Cache.Add(4257, new(26, 13, 1)); // Amber Hook
      Cache.Add(1241, new(28, 13, 1)); // Diamond Hook
      Cache.Add(939, new(23, 10, 8)); // Web Slinger
      Cache.Add(1273, new(27, 22, 2)); // Skeletron Hand
      Cache.Add(2585, new(19, 13, 3)); // Slime Hook
      Cache.Add(2360, new(25, 13, 3)); // Fish Hook
      Cache.Add(185, new(25, 13, 3)); // Ivy Whip
      Cache.Add(1800, new(31, 13, 1)); // Bat Hook
      Cache.Add(1915, new(25, 12, 1)); // Candy Cane Hook
      Cache.Add(437, new(28, 14, 2)); // Dual Hook
      Cache.Add(3022, new(30, 15, 3)); // Illuminant Hook
      Cache.Add(3023, new(30, 15, 3)); // Worm Hook
      Cache.Add(3020, new(30, 15, 3)); // Tendon Hook
      Cache.Add(4980, new(31, 16, 1)); // Hook of Dissonance
      Cache.Add(3623, new(38, 16, 2)); // Static Hook
      Cache.Add(3021, new(30, 15, 3)); // Thorn Hook
      Cache.Add(1829, new(34, 15, 3)); // Spooky Hook
      Cache.Add(1916, new(34, 15, 3)); // Christmas Hook
      Cache.Add(2800, new(31, 14, 3)); // Anti-Gravity Hook
      Cache.Add(3572, new(34, 18, 4)); // Lunar Hook
    }

    private static void AddCalamityMod()
    {
      if (!ModLoader.TryGetMod("CalamityMod", out Mod mod)) return;

      // Cache.Add(ContentHelpers.FindItem(mod, "BetterToolTips/debug").Type, HookStat.Empty());
      Cache.Add(ContentHelpers.FindItem(mod, "SerpentsBite").Type, new(28, 18, 2)); // Serpent's Bite
      Cache.Add(ContentHelpers.FindItem(mod, "BobbitHook").Type, new(40, 25, 1)); // Bobbit Hook
    }

    private static void AddThoriumMod()
    {
      if (!ModLoader.TryGetMod("ThoriumMod", out Mod mod)) return;

      // Cache.Add(ContentHelpers.FindItem(mod, "BetterToolTips/debug").Type, HookStat.Empty());
      Cache.Add(ContentHelpers.FindItem(mod, "ZephyrsGrip").Type, new(9, 10, 1)); // Zephyr's Grip
      Cache.Add(ContentHelpers.FindItem(mod, "OpalHook").Type, new(21, 11, 1)); // Opal Hook
      Cache.Add(ContentHelpers.FindItem(mod, "AquamarineHook").Type, new(22, 11, 1)); // Aquamarine Hook
      Cache.Add(ContentHelpers.FindItem(mod, "SpringHook").Type, new(17, 12, 1)); // Spring Hook
      Cache.Add(ContentHelpers.FindItem(mod, "JewellersWallGrip").Type, new(28, 13, 2)); // Jeweller's Wall Grip
      Cache.Add(ContentHelpers.FindItem(mod, "Leviathan").Type, new(27, 14, 10)); // Leviathan
      Cache.Add(ContentHelpers.FindItem(mod, "DevilsReach").Type, new(33, 15, 3)); // Devil's Reach
      Cache.Add(ContentHelpers.FindItem(mod, "FungalHook").Type, new(30, 16, 3)); // Fungal Hook
      Cache.Add(ContentHelpers.FindItem(mod, "NeptuneGrasp").Type, new(30, 15, 4)); // Neptune's Grasp
      Cache.Add(ContentHelpers.FindItem(mod, "AmmutsebaSash").Type, new(30, 15, 1)); // Ammutseba's Sash
      Cache.Add(ContentHelpers.FindItem(mod, "GhostlyGrapple").Type, new(34, 16, 2)); // Ghostly Grapple
    }
  }
}
