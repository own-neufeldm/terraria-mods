using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterMetalDetector.System
{
  public class Priority : ModSystem
  {
    public override void PostSetupContent()
    {
      Apply(ModContent.GetInstance<Configuration.Client>());
    }

    public static void Apply(Configuration.Client config)
    {
      if (config == null) return;

      // Ores (pre-hardmode)
      Main.tileOreFinderPriority[TileID.DesertFossil] = (short)config.FossilOre;
      Main.tileOreFinderPriority[TileID.FossilOre] = (short)config.FossilOre;
      Main.tileOreFinderPriority[TileID.Copper] = (short)config.CopperOre;
      Main.tileOreFinderPriority[TileID.Tin] = (short)config.TinOre;
      Main.tileOreFinderPriority[TileID.Iron] = (short)config.IronOre;
      Main.tileOreFinderPriority[TileID.Lead] = (short)config.LeadOre;
      Main.tileOreFinderPriority[TileID.Silver] = (short)config.SilverOre;
      Main.tileOreFinderPriority[TileID.Tungsten] = (short)config.TungstenOre;
      Main.tileOreFinderPriority[TileID.Gold] = (short)config.GoldOre;
      Main.tileOreFinderPriority[TileID.Platinum] = (short)config.PlatinumOre;
      Main.tileOreFinderPriority[TileID.Demonite] = (short)config.DemoniteOre;
      Main.tileOreFinderPriority[TileID.Crimtane] = (short)config.CrimtaneOre;
      Main.tileOreFinderPriority[TileID.Meteorite] = (short)config.MeteoriteOre;

      // Ores (hardmode)
      Main.tileOreFinderPriority[TileID.Cobalt] = (short)config.CobaltOre;
      Main.tileOreFinderPriority[TileID.Palladium] = (short)config.PalladiumOre;
      Main.tileOreFinderPriority[TileID.Mythril] = (short)config.MythrilOre;
      Main.tileOreFinderPriority[TileID.Orichalcum] = (short)config.OrichalcumOre;
      Main.tileOreFinderPriority[TileID.Adamantite] = (short)config.AdamantiteOre;
      Main.tileOreFinderPriority[TileID.Titanium] = (short)config.TitaniumOre;
      Main.tileOreFinderPriority[TileID.Chlorophyte] = (short)config.ChlorophyteOre;

      // Treasures (pre-hardmode)
      Main.tileOreFinderPriority[TileID.Pots] = (short)config.Pot;
      Main.tileOreFinderPriority[TileID.Containers] = (short)config.Chest;
      Main.tileOreFinderPriority[TileID.Containers2] = (short)config.Chest;
      Main.tileOreFinderPriority[TileID.FakeContainers] = (short)config.Chest;
      Main.tileOreFinderPriority[TileID.FakeContainers2] = (short)config.Chest;
      Main.tileOreFinderPriority[TileID.Heart] = (short)config.LifeCrystal;
      Main.tileOreFinderPriority[TileID.LifeCrystalBoulder] = (short)config.LifeCrystal;
      Main.tileOreFinderPriority[TileID.ManaCrystal] = (short)config.ManaCrystal;
      Main.tileOreFinderPriority[TileID.DyePlants] = (short)config.StrangePlant;
      Main.tileOreFinderPriority[TileID.GlowTulip] = (short)config.GlowTulip;

      // Treasures (hardmode)
      Main.tileOreFinderPriority[TileID.Crystals] = (short)config.GelatinCrystal;
      Main.tileOreFinderPriority[TileID.LifeFruit] = (short)config.LifeFruit;
    }
  }
}
