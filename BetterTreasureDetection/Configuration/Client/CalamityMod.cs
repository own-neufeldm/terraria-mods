using System;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace BetterTreasureDetection.Configuration.Client
{
  public class CalamityMod : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    public override bool Autoload(ref string name)
    {
      return ModLoader.HasMod("CalamityMod");
    }

    [Header("OresPreHM")]

    [Slider]
    [SliderColor(115, 185, 215)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(450)]
    public int AerialiteOre;

    [Header("OresHM")]

    [Slider]
    [SliderColor(95, 215, 225)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(675)]
    public int CryonicOre;

    [Slider]
    [SliderColor(210, 80, 50)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(675)]
    public int InfernalSuevite;

    [Slider]
    [SliderColor(230, 210, 110)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(690)]
    public int HallowedOre;

    [Slider]
    [SliderColor(155, 205, 80)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(710)]
    public int PerennialOre;

    [Slider]
    [SliderColor(215, 110, 45)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(850)]
    public int ScoriaOre;

    [Slider]
    [SliderColor(190, 130, 150)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(900)]
    public int AstralOre;

    [Header("OresPostML")]

    [Slider]
    [SliderColor(150, 185, 195)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(760)]
    public int ExodiumCluster;

    [Slider]
    [SliderColor(110, 220, 180)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(900)]
    public int LuminiteOre;

    [Slider]
    [SliderColor(200, 130, 50)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(950)]
    public int UelibloomOre;

    [Slider]
    [SliderColor(240, 190, 60)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(1000)]
    public int AuricOre;

    [Header("Treasures")]

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
    [SliderColor(130, 130, 140)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(770)]
    public int IronBall;

    [Slider]
    [SliderColor(200, 70, 150)]
    [Increment(10)]
    [Range(0, 2000)]
    [DefaultValue(910)]
    public int Roxcalibur;

    public override void OnChanged()
    {
      System.Priority.Apply(this);
    }
  }
}
