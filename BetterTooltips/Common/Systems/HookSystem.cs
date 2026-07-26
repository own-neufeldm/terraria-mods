using System.Collections.Generic;
using BetterTooltips.Common.Stats;
using BetterTooltips.Helpers;
using Newtonsoft.Json;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Systems
{
  public class HookSystem : ModSystem
  {
    public static Dictionary<int, HookStat> Cache { get; } = [];

    public override void PostSetupContent()
    {
      LoadVanillaStats();
      LoadThoriumModStats();
    }

    private static void LoadVanillaStats()
    {
      var json = ContentHelpers.ReadFile("Assets/Stats/Hooks/Vanilla.json");
      var stats = JsonConvert.DeserializeObject<List<HookStat>>(json);
      foreach (var stat in stats) Cache.Add(stat.ID, stat);
    }

    private static void LoadThoriumModStats()
    {
      if (!ModLoader.TryGetMod("ThoriumMod", out Mod mod)) return;

      var json = ContentHelpers.ReadFile("Assets/Stats/Hooks/ThoriumMod.json");
      var stats = JsonConvert.DeserializeObject<List<HookStat>>(json);
      var names = new Dictionary<string, string>
      {
        ["Zephyr's Grip"] = "ZephyrsGrip",
        ["Opal Hook"] = "OpalHook",
        ["Aquamarine Hook"] = "AquamarineHook",
        ["Spring Hook"] = "SpringHook",
        ["Jeweller's Wall Grip"] = "JewellersWallGrip",
        ["Leviathan"] = "Leviathan",
        ["Devil's Reach"] = "DevilsReach",
        ["Fungal Hook"] = "FungalHook",
        ["Neptune's Grasp"] = "NeptuneGrasp",
        ["Ammutseba's Sash"] = "AmmutsebaSash",
        ["Ghostly Grapple"] = "GhostlyGrapple",
      };

      foreach (var stat in stats)
      {
        var name = names[stat.Name];
        var item = mod.Find<ModItem>(name);
        var newStat = stat with { ID = item.Type };
        Cache.Add(newStat.ID, newStat);
      }
    }
  }
}
