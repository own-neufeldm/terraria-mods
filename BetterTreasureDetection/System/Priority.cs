using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterTreasureDetection.System
{
  public class Priority : ModSystem
  {
    public override void PostSetupContent()
    {
      Apply(ModContent.GetInstance<Configuration.Client.Vanilla>());
      Apply(ModContent.GetInstance<Configuration.Client.CalamityMod>());
      Apply(ModContent.GetInstance<Configuration.Client.ThoriumMod>());
    }

    public static void Apply(Configuration.Client.Vanilla config)
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

    public static void Apply(Configuration.Client.CalamityMod config)
    {
      if (config == null || !ModLoader.TryGetMod("CalamityMod", out Mod mod)) return;

      // Ores (pre-hardmode)
      if (mod.TryFind("AerialiteOre", out ModTile tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.AerialiteOre;

      // Ores (hardmode)
      if (mod.TryFind("CryonicOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.CryonicOre;
      if (mod.TryFind("InfernalSuevite", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.InfernalSuevite;
      if (mod.TryFind("HallowedOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.HallowedOre;
      if (mod.TryFind("PerennialOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.PerennialOre;
      if (mod.TryFind("ScoriaOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.ScoriaOre;
      if (mod.TryFind("AstralOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.AstralOre;

      // Ores (post-moonlord)
      if (mod.TryFind("ExodiumOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.ExodiumCluster;
      Main.tileOreFinderPriority[TileID.LunarOre] = (short)config.LuminiteOre;
      if (mod.TryFind("UelibloomOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.UelibloomOre;
      if (mod.TryFind("AuricOre", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.AuricOre;

      // Treasures
      if (mod.TryFind("AbyssalPots", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Pot;
      if (mod.TryFind("SulphurousPots", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Pot;
      if (mod.TryFind("AbyssChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("AbyssTreasureChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("AcidwoodChestTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("AgedSecurityChestTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("AncientNavystoneChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("AnodizedWulfrumChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("AshenChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("AstralChestLocked", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("BotanicChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("CosmiliteChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("DriftwoodChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("ExoChestTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("MarniteChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("MonolithChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("NavystoneChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("OtherworldlyChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("PlaguedPlateChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("ProfanedChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("RustyChestTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("SacrilegiousChestTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("SecurityChestTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("SilvaChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("StatigelChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("StratusChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("VoidChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("IronBallPlaced", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.IronBall;
      if (mod.TryFind("RoxTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Roxcalibur;
    }

    public static void Apply(Configuration.Client.ThoriumMod config)
    {
      if (config == null || !ModLoader.TryGetMod("ThoriumMod", out Mod mod)) return;

      // Ores (pre-hardmode)
      if (mod.TryFind("ThoriumOre", out ModTile tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.ThoriumOre;
      if (mod.TryFind("SmoothCoal", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.SmoothCoal;
      if (mod.TryFind("LifeQuartz", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.LifeQuartz;
      if (mod.TryFind("Aquaite", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.AquaiteOre;
      if (mod.TryFind("AquaiteBare", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.AquaiteOre;

      // Ores (hardmode)
      if (mod.TryFind("LodeStone", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.LodestoneChunk;
      if (mod.TryFind("ValadiumChunk", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.ValadiumChunk;
      if (mod.TryFind("IllumiteChunk", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.IllumiteChunk;

      // Treasures
      if (mod.TryFind("AquaticDepthsBiomeChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("BloodstainedChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("CelestialChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("CursedChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("DeadwoodChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("DepthChestTile", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("DesertBiomeChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("EvergreenChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("FossilChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("GingerbreadChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("LivingMahoganyChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("LodestoneChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("MarineChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("NagaChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("OrnateChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("PermafrostChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("PlateChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("ScarletChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("ShadyChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("ShootingStarChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("ThoriumChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("TrappedChests", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("UnderworldChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("ValadiumChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("WhiteDwarfChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("YewChest", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.Chest;
      if (mod.TryFind("OceanCrystal", out tile)) Main.tileOreFinderPriority[tile.Type] = (short)config.CrystalWave;
    }
  }
}
