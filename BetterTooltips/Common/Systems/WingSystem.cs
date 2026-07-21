using System.Collections.Generic;
using BetterTooltips.Common.Stats;
using Terraria.ModLoader;

namespace BetterTooltips.Common.Systems
{
  public class WingSystem : ModSystem
  {
    public static Dictionary<int, WingStat> Cache { get; } = [];

    public override void PostSetupContent()
    {
      AddVanilla();
      AddCalamityMod();
      AddThoriumMod();
    }

    private static void AddVanilla()
    {
      Cache.Add(4978, new(0.42f, 18, 0.0f)); // Fledgling Wings
      Cache.Add(493, new(1.67f, 53, 0.0f)); // Angel Wings
      Cache.Add(492, new(1.67f, 53, 0.0f)); // Demon Wings
      Cache.Add(761, new(2.17f, 67, 0.0f)); // Fairy Wings
      Cache.Add(2494, new(2.17f, 67, 0.0f)); // Fin Wings
      Cache.Add(822, new(2.17f, 67, 0.0f)); // Frozen Wings
      Cache.Add(785, new(2.17f, 67, 0.0f)); // Harpy Wings
      Cache.Add(748, new(2.5f, 77, 0.0f)); // Jetpack
      Cache.Add(5627, new(2.5f, 77, 0.0f)); // Chippy's Cloak
      Cache.Add(5659, new(2.5f, 77, 0.0f)); // Heroicis' Wings
      Cache.Add(665, new(2.5f, 77, 0.0f)); // Red's Wings
      Cache.Add(1583, new(2.5f, 77, 0.0f)); // D-Town's Wings
      Cache.Add(1584, new(2.5f, 77, 0.0f)); // Will's Wings
      Cache.Add(1585, new(2.5f, 77, 0.0f)); // Crowno's Wings
      Cache.Add(1586, new(2.5f, 77, 0.0f)); // Cenx's Wings
      Cache.Add(3228, new(2.5f, 77, 0.0f)); // Lazure's Barrier Platform
      Cache.Add(3580, new(2.5f, 77, 0.0f)); // Yoraiz0r's Spell
      Cache.Add(3582, new(2.5f, 77, 0.0f)); // Jim's Wings
      Cache.Add(3588, new(2.5f, 77, 0.0f)); // Skiphs' Paws
      Cache.Add(3592, new(2.5f, 77, 0.0f)); // Loki's Wings
      Cache.Add(3924, new(2.5f, 77, 0.0f)); // Arkhalis' Lightwings
      Cache.Add(3928, new(2.5f, 77, 0.0f)); // Leinfors' Prehensile Cloak
      Cache.Add(4730, new(2.5f, 77, 0.0f)); // Ghostar's Infinity Eight
      Cache.Add(4746, new(2.5f, 77, 0.0f)); // Safeman's Blanket Cape
      Cache.Add(4750, new(2.5f, 77, 0.0f)); // FoodBarbarian's Tattered Dragon Wings
      Cache.Add(4754, new(2.5f, 77, 0.0f)); // Grox The Great's Wings
      Cache.Add(6140, new(2.5f, 77, 0.0f)); // Luna's Runic Pixie Wings
      Cache.Add(5686, new(2.5f, 77, 0.0f)); // Kazzymodus' Wings
      Cache.Add(5586, new(2.5f, 77, 0.0f)); // Chicken Bones' Wings
      Cache.Add(1162, new(2.67f, 81, 0.0f)); // Leaf Wings
      Cache.Add(1165, new(2.67f, 81, 0.0f)); // Bat Wings
      Cache.Add(1515, new(2.67f, 81, 0.0f)); // Bee Wings
      Cache.Add(749, new(2.67f, 81, 0.0f)); // Butterfly Wings
      Cache.Add(821, new(2.67f, 81, 0.0f)); // Flame Wings
      Cache.Add(1866, new(2.83f, 94, 0.0f)); // Hoverboard
      Cache.Add(786, new(2.83f, 94, 0.0f)); // Bone Wings
      Cache.Add(2770, new(2.83f, 94, 0.0f)); // Mothron Wings
      Cache.Add(823, new(2.83f, 94, 0.0f)); // Spectre Wings
      Cache.Add(2280, new(2.83f, 94, 0.0f)); // Beetle Wings
      Cache.Add(1871, new(3.0f, 107, 0.0f)); // Festive Wings
      Cache.Add(1830, new(3.0f, 107, 0.0f)); // Spooky Wings
      Cache.Add(1797, new(3.0f, 107, 0.0f)); // Tattered Fairy Wings
      Cache.Add(948, new(3.0f, 107, 0.0f)); // Steampunk Wings
      Cache.Add(3883, new(2.5f, 119, 1.5f)); // Betsy's Wings
      Cache.Add(4823, new(2.5f, 128, 1.0f)); // Empress Wings
      Cache.Add(2609, new(3.0f, 143, 1.0f)); // Fishron Wings
      Cache.Add(3470, new(3.0f, 143, 0.5f)); // Nebula Mantle
      Cache.Add(3469, new(3.0f, 143, 0.5f)); // Vortex Booster
      Cache.Add(3468, new(3.0f, 167, 1.5f)); // Solar Wings
      Cache.Add(3471, new(3.0f, 167, 1.5f)); // Stardust Wings
      Cache.Add(4954, new(3.0f, 201, 3.5f)); // Celestial Starboard
    }

    private static void AddCalamityMod()
    {
      if (!ModLoader.TryGetMod("CalamityMod", out Mod mod)) return;

      // Cache.Add(Utils.FindItem(mod, "BetterToolTips/debug").Type, WingStats.Empty());
      Cache.Add(Utils.FindItem(mod, "SkylineWings").Type, new(1.33f, 60, 0.0f)); // Skyline Wings
      Cache.Add(Utils.FindItem(mod, "StarlightWings").Type, new(2.83f, 117, 0.5f)); // Starlight Wings
      Cache.Add(Utils.FindItem(mod, "AureateBooster").Type, new(2.0f, 128, 0.5f)); // Aureate Booster
      Cache.Add(Utils.FindItem(mod, "HadarianWings").Type, new(1.8f, 100, 1.0f)); // Hadarian Wings
      Cache.Add(Utils.FindItem(mod, "HadalMantle").Type, new(2.17f, 108, 1.0f)); // Hadal Mantle
      Cache.Add(Utils.FindItem(mod, "ExodusWings").Type, new(3.0f, 222, 1.5f)); // Exodus Wings
      Cache.Add(Utils.FindItem(mod, "TarragonWings").Type, new(4.5f, 335, 1.5f)); // Tarragon Wings
      Cache.Add(Utils.FindItem(mod, "ElysianWings").Type, new(4.0f, 305, 2.0f)); // Elysian Wings
      Cache.Add(Utils.FindItem(mod, "SilvaWings").Type, new(4.5f, 359, 1.8f)); // Silva Wings
      Cache.Add(Utils.FindItem(mod, "WingsofRebirth").Type, new(6.0f, 490, 1.9f)); // Wings of Rebirth
      Cache.Add(Utils.FindItem(mod, "SoulofCryogen").Type, new(2.67f, 111, 0.0f)); // Soul of Cryogen
      Cache.Add(Utils.FindItem(mod, "MOAB").Type, new(1.25f, 159, 0.0f)); // MOAB
      Cache.Add(Utils.FindItem(mod, "MoonWalkers").Type, new(2.67f, 170, 1.6f)); // Moon Walkers
      Cache.Add(Utils.FindItem(mod, "VoidStriders").Type, new(3.33f, 229, 1.7f)); // Void Striders
      Cache.Add(Utils.FindItem(mod, "SeraphTracers").Type, new(4.17f, 308, 1.8f)); // Seraph Tracers
    }

    private static void AddThoriumMod()
    {
      if (!ModLoader.TryGetMod("ThoriumMod", out Mod mod)) return;

      // Cache.Add(Utils.FindItem(mod, "BetterToolTips/debug").Type, WingStats.Empty());
      Cache.Add(Utils.FindItem(mod, "ChampionWing").Type, new(1.0f, 34, 0.0f)); // Champion's Wings
      Cache.Add(Utils.FindItem(mod, "DridersGrace").Type, new(0.0f, 28, 0.0f)); // Drider's Grace
      Cache.Add(Utils.FindItem(mod, "DragonWings").Type, new(2.0f, 72, 1.33f)); // Dragon's Wings
      Cache.Add(Utils.FindItem(mod, "FleshWings").Type, new(2.0f, 72, 1.33f)); // Flesh Wings
      Cache.Add(Utils.FindItem(mod, "PhonicWings").Type, new(2.0f, 77, 1.33f)); // Phonic Wings
      Cache.Add(Utils.FindItem(mod, "TitanWings").Type, new(2.0f, 72, 1.33f)); // Titan Wings
      Cache.Add(Utils.FindItem(mod, "SubspaceWings").Type, new(2.0f, 72, 1.33f)); // Subspace Wings
      Cache.Add(Utils.FindItem(mod, "DreadWings").Type, new(2.0f, 72, 1.5f)); // Dread Wings
      Cache.Add(Utils.FindItem(mod, "DemonBloodWings").Type, new(2.0f, 72, 1.5f)); // Demon Blood Wings
      Cache.Add(Utils.FindItem(mod, "TerrariumWings").Type, new(3.0f, 187, 1.67f)); // Terrarium Wings
      Cache.Add(Utils.FindItem(mod, "ShootingStarTurboTuba").Type, new(2.0f, 151, 1.17f)); // Shooting Star Turbo Tuba
      Cache.Add(Utils.FindItem(mod, "CelestialCarrier").Type, new(2.0f, 151, 1.17f)); // Celestial Carrier
      Cache.Add(Utils.FindItem(mod, "WhiteDwarfThrusters").Type, new(2.0f, 151, 2.33f)); // White Dwarf Thrusters
    }
  }
}
