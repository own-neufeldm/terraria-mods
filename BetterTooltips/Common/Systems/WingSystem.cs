using System.Collections.Generic;
using System.Text.RegularExpressions;
using BetterTooltips.Common.Stats;
using HtmlAgilityPack;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Systems
{
  public class WingSystem : ModSystem
  {
    public static Dictionary<int, WingStat> Cache { get; } = [];

    public override void PostSetupContent()
    {
      AddVanilla();
      // AddCalamityMod();
      // AddThoriumMod();
    }

#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    private static void AddVanilla()
    {
      // Mod mod = ModLoader.GetMod("BetterTooltips");
      // mod.Logger.Debug("Fetching wiki data...");

      var web = new HtmlWeb
      {
        UserAgent = "dotnet-httpagilitypack/1.12.4"
      };
      var doc = web.Load("https://terraria.wiki.gg/wiki/Wings/List");

      // mod.Logger.Debug("Selecting table...");
      var rows = doc.DocumentNode.SelectNodes("//table//tr");
      if (rows == null) return;

      // mod.Logger.Debug("Parsing table data...");
      for (int i = 1; i < rows.Count; i++)
      {
        // mod.Logger.Debug("Selecting columns...");
        var cols = rows[i].SelectNodes("td|th");
        if (cols == null || cols.Count < 8) continue;

        // mod.Logger.Debug("Parsing name and type...");
        string value = HtmlEntity.DeEntitize(cols[1].InnerText).Trim();
        // mod.Logger.Debug($"  value='{value}'");
        var match = Regex.Match(value, @"(?<name>.+)\s*Internal\s*Item\s*ID:\s*(?<id>.+)");
        string name = match.Groups["name"].Value;
        int id = int.Parse(match.Groups["id"].Value);
        // mod.Logger.Debug($"  name='{name}' | id={id}");

        // mod.Logger.Debug("Parsing flight time...");
        value = HtmlEntity.DeEntitize(cols[4].InnerText).Trim();
        // mod.Logger.Debug($"  value='{value}'");
        match = Regex.Match(value, @"([\d.]+)");
        float flightTime = float.Parse(match.Groups[0].Value);
        // mod.Logger.Debug($"  flightTime={flightTime}");

        // mod.Logger.Debug("Parsing height...");
        value = HtmlEntity.DeEntitize(cols[5].InnerText).Trim();
        // mod.Logger.Debug($"  value='{value}'");
        match = Regex.Match(value, @"(\d+)");
        int height = int.Parse(match.Groups[0].Value);
        // mod.Logger.Debug($"  height={height}");

        // mod.Logger.Debug("Parsing speed bonus...");
        value = HtmlEntity.DeEntitize(cols[7].InnerText).Trim();
        // mod.Logger.Debug($"  value='{value}'");
        match = Regex.Match(value, @"\d+");
        int speedBonus = int.Parse(match.Value) - 100;
        // mod.Logger.Debug($"  speedBonus={speedBonus}");

        // mod.Logger.Debug($"Adding '{name}' to cache...");
        Cache.Add(id, new(flightTime, height, speedBonus));
      }
    }

    // private static void AddCalamityMod()
    // {
    //   if (!ModLoader.TryGetMod("CalamityMod", out Mod mod)) return;

    //   // Cache.Add(Utils.FindItem(mod, "BetterToolTips/debug").Type, WingStat.Empty());
    //   Cache.Add(Utils.FindItem(mod, "SkylineWings").Type, new(1.33f, 60, 0.0f)); // Skyline Wings
    //   Cache.Add(Utils.FindItem(mod, "StarlightWings").Type, new(2.83f, 117, 0.5f)); // Starlight Wings
    //   Cache.Add(Utils.FindItem(mod, "AureateBooster").Type, new(2.0f, 128, 0.5f)); // Aureate Booster
    //   Cache.Add(Utils.FindItem(mod, "HadarianWings").Type, new(1.8f, 100, 1.0f)); // Hadarian Wings
    //   Cache.Add(Utils.FindItem(mod, "HadalMantle").Type, new(2.17f, 108, 1.0f)); // Hadal Mantle
    //   Cache.Add(Utils.FindItem(mod, "ExodusWings").Type, new(3.0f, 222, 1.5f)); // Exodus Wings
    //   Cache.Add(Utils.FindItem(mod, "TarragonWings").Type, new(4.5f, 335, 1.5f)); // Tarragon Wings
    //   Cache.Add(Utils.FindItem(mod, "ElysianWings").Type, new(4.0f, 305, 2.0f)); // Elysian Wings
    //   Cache.Add(Utils.FindItem(mod, "SilvaWings").Type, new(4.5f, 359, 1.8f)); // Silva Wings
    //   Cache.Add(Utils.FindItem(mod, "WingsofRebirth").Type, new(6.0f, 490, 1.9f)); // Wings of Rebirth
    //   Cache.Add(Utils.FindItem(mod, "SoulofCryogen").Type, new(2.67f, 111, 0.0f)); // Soul of Cryogen
    //   Cache.Add(Utils.FindItem(mod, "MOAB").Type, new(1.25f, 159, 0.0f)); // MOAB
    //   Cache.Add(Utils.FindItem(mod, "MoonWalkers").Type, new(2.67f, 170, 1.6f)); // Moon Walkers
    //   Cache.Add(Utils.FindItem(mod, "VoidStriders").Type, new(3.33f, 229, 1.7f)); // Void Striders
    //   Cache.Add(Utils.FindItem(mod, "SeraphTracers").Type, new(4.17f, 308, 1.8f)); // Seraph Tracers
    // }

    // private static void AddThoriumMod()
    // {
    //   if (!ModLoader.TryGetMod("ThoriumMod", out Mod mod)) return;

    //   // Cache.Add(Utils.FindItem(mod, "BetterToolTips/debug").Type, WingStat.Empty());
    //   Cache.Add(Utils.FindItem(mod, "ChampionWing").Type, new(1.0f, 34, 0.0f)); // Champion's Wings
    //   Cache.Add(Utils.FindItem(mod, "DridersGrace").Type, new(0.0f, 28, 0.0f)); // Drider's Grace
    //   Cache.Add(Utils.FindItem(mod, "DragonWings").Type, new(2.0f, 72, 1.33f)); // Dragon's Wings
    //   Cache.Add(Utils.FindItem(mod, "FleshWings").Type, new(2.0f, 72, 1.33f)); // Flesh Wings
    //   Cache.Add(Utils.FindItem(mod, "PhonicWings").Type, new(2.0f, 77, 1.33f)); // Phonic Wings
    //   Cache.Add(Utils.FindItem(mod, "TitanWings").Type, new(2.0f, 72, 1.33f)); // Titan Wings
    //   Cache.Add(Utils.FindItem(mod, "SubspaceWings").Type, new(2.0f, 72, 1.33f)); // Subspace Wings
    //   Cache.Add(Utils.FindItem(mod, "DreadWings").Type, new(2.0f, 72, 1.5f)); // Dread Wings
    //   Cache.Add(Utils.FindItem(mod, "DemonBloodWings").Type, new(2.0f, 72, 1.5f)); // Demon Blood Wings
    //   Cache.Add(Utils.FindItem(mod, "TerrariumWings").Type, new(3.0f, 187, 1.67f)); // Terrarium Wings
    //   Cache.Add(Utils.FindItem(mod, "ShootingStarTurboTuba").Type, new(2.0f, 151, 1.17f)); // Shooting Star Turbo Tuba
    //   Cache.Add(Utils.FindItem(mod, "CelestialCarrier").Type, new(2.0f, 151, 1.17f)); // Celestial Carrier
    //   Cache.Add(Utils.FindItem(mod, "WhiteDwarfThrusters").Type, new(2.0f, 151, 2.33f)); // White Dwarf Thrusters
    // }
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
  }
}
