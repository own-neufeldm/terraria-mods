using System;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace BetterTreasureDetection.Configuration.Client
{
  public class ThoriumMod : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    public override bool Autoload(ref string name)
    {
      return ModLoader.HasMod("ThoriumMod");
    }

    [Header("OresPreHM")]

    [Slider]
    [SliderColor(140, 120, 170)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(280)]
    public int ThoriumOre;

    [Slider]
    [SliderColor(80, 80, 90)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(281)]
    public int SmoothCoal;

    [Slider]
    [SliderColor(230, 90, 140)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(282)]
    public int LifeQuartz;

    [Slider]
    [SliderColor(50, 150, 200)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(290)]
    public int AquaiteOre;

    [Header("OresHM")]

    [Slider]
    [SliderColor(135, 105, 80)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(660)]
    public int LodestoneChunk;

    [Slider]
    [SliderColor(115, 90, 165)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(660)]
    public int ValadiumChunk;

    [Slider]
    [SliderColor(180, 110, 210)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(710)]
    public int IllumiteChunk;

    [Header("Treasures")]

    [Slider]
    [SliderColor(185, 140, 70)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(500)]
    public int Chest;

    [Slider]
    [SliderColor(35, 205, 180)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(750)]
    public int CrystalWave;

    public override void OnChanged()
    {
      System.Priority.Apply(this);
    }
  }
}
