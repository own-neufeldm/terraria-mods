using System.Collections.Generic;
using BetterTooltips.Common.Stats;
using Newtonsoft.Json;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Systems
{
  public class WingSystem : ModSystem
  {
    public static Dictionary<int, WingStat> Cache { get; } = [];

    public override void PostSetupContent()
    {
      LoadVanillaStats();
      LoadThoriumModStats();
    }

    private static void LoadVanillaStats()
    {
      var json = Utils.ReadFile("Assets/Stats/Wings/Vanilla.json");
      var stats = JsonConvert.DeserializeObject<List<WingStat>>(json);
      foreach (var stat in stats) Cache.Add(stat.ID, stat);
    }

    private static void LoadThoriumModStats()
    {
      if (!ModLoader.TryGetMod("ThoriumMod", out Mod mod)) return;

      var json = Utils.ReadFile("Assets/Stats/Wings/ThoriumMod.json");
      var stats = JsonConvert.DeserializeObject<List<WingStat>>(json);
      var names = new Dictionary<string, string>
      {
        ["Champion's Wings"] = "ChampionWing",
        ["Drider's Grace"] = "DridersGrace",
        ["Dragon's Wings"] = "DragonWings",
        ["Flesh Wings"] = "FleshWings",
        ["Phonic Wings"] = "PhonicWings",
        ["Titan Wings"] = "TitanWings",
        ["Subspace Wings"] = "SubspaceWings",
        ["Dread Wings"] = "DreadWings",
        ["Demon Blood Wings"] = "DemonBloodWings",
        ["Terrarium Wings"] = "TerrariumWings",
        ["Shooting Star Turbo Tuba"] = "ShootingStarTurboTuba",
        ["Celestial Carrier"] = "CelestialCarrier",
        ["White Dwarf Thrusters"] = "WhiteDwarfThrusters",
      };

      foreach (var stat in stats)
      {
        var name = names[stat.Name];
        var item = mod.Find<ModItem>(name);
        stat.ID = item.Type;
        Cache.Add(stat.ID, stat);
      }
    }
  }
}
