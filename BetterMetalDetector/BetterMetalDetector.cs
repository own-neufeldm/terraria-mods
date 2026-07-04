using System;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace BetterMetalDetector
{
  public class System : ModSystem
  {
    public override void PostSetupContent()
    {
      ApplyCustomPriorities(ModContent.GetInstance<Config>());
    }

    public static void ApplyCustomPriorities(Config config)
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

  public class Config : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("OresPreHM")]

    [Slider]
    [SliderColor(185, 140, 100)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(150)]
    public int FossilOre;

    [Slider]
    [SliderColor(220, 105, 30)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(200)]
    public int CopperOre;

    [Slider]
    [SliderColor(165, 175, 160)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(210)]
    public int TinOre;

    [Slider]
    [SliderColor(140, 130, 120)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(220)]
    public int IronOre;

    [Slider]
    [SliderColor(95, 110, 130)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(230)]
    public int LeadOre;

    [Slider]
    [SliderColor(190, 210, 215)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(240)]
    public int SilverOre;

    [Slider]
    [SliderColor(130, 170, 145)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(250)]
    public int TungstenOre;

    [Slider]
    [SliderColor(245, 215, 75)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(260)]
    public int GoldOre;

    [Slider]
    [SliderColor(170, 185, 210)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(270)]
    public int PlatinumOre;

    [Slider]
    [SliderColor(145, 115, 210)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(300)]
    public int DemoniteOre;

    [Slider]
    [SliderColor(215, 45, 45)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(310)]
    public int CrimtaneOre;

    [Slider]
    [SliderColor(105, 95, 130)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(400)]
    public int MeteoriteOre;

    [Header("OresHM")]

    [Slider]
    [SliderColor(0, 160, 235)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(600)]
    public int CobaltOre;

    [Slider]
    [SliderColor(235, 95, 50)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(610)]
    public int PalladiumOre;

    [Slider]
    [SliderColor(70, 195, 140)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(620)]
    public int MythrilOre;

    [Slider]
    [SliderColor(210, 75, 180)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(630)]
    public int OrichalcumOre;

    [Slider]
    [SliderColor(225, 60, 110)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(640)]
    public int AdamantiteOre;

    [Slider]
    [SliderColor(150, 165, 180)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(650)]
    public int TitaniumOre;

    [Slider]
    [SliderColor(160, 225, 35)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(700)]
    public int ChlorophyteOre;

    [Header("TreasuresPreHM")]

    [Slider]
    [SliderColor(165, 110, 80)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(100)]
    public int Pot;

    [Slider]
    [SliderColor(185, 140, 70)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(500)]
    public int Chest;

    [Slider]
    [SliderColor(245, 55, 105)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(550)]
    public int LifeCrystal;

    [Slider]
    [SliderColor(80, 105, 235)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(550)]
    public int ManaCrystal;

    [Slider]
    [SliderColor(195, 75, 225)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(750)]
    public int StrangePlant;

    [Slider]
    [SliderColor(35, 205, 180)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(760)]
    public int GlowTulip;

    [Header("TreasuresHM")]

    [Slider]
    [SliderColor(225, 110, 235)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(675)]
    public int GelatinCrystal;

    [Slider]
    [SliderColor(140, 215, 55)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(810)]
    public int LifeFruit;

    public override void OnChanged()
    {
      System.ApplyCustomPriorities(this);
    }
  }
}
