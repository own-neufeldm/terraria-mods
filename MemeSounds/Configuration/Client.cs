using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MemeSounds.Configuration
{
  public enum Event
  {
    Death,
    Spawn,
  }

  [AttributeUsage(AttributeTargets.Field)]
  public class MetadataAttribute(string filename, Event onEvent) : Attribute
  {
    public string Filename { get; } = filename;
    public Event OnEvent { get; } = onEvent;
  }

  public class Client : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [Header("DeathSounds")]

    [Metadata("13OunceOkayLong", Event.Death)]
    [DefaultValue(true)]
    public bool ThirteenOunceOkayLong;

    [Metadata("13OunceOkayShort", Event.Death)]
    [DefaultValue(true)]
    public bool ThirteenOunceOkayShort;

    [Metadata("MetalPipeFalling", Event.Death)]
    [DefaultValue(true)]
    public bool MetalPipeFalling;

    [Metadata("MinecraftTNT", Event.Death)]
    [DefaultValue(true)]
    public bool MinecraftTNT;

    [Metadata("ReverbFart", Event.Death)]
    [DefaultValue(true)]
    public bool ReverbFart;

    [Metadata("WindowsXPError", Event.Death)]
    [DefaultValue(true)]
    public bool WindowsXPError;

    [Metadata("WindowsXPShutdown", Event.Death)]
    [DefaultValue(true)]
    public bool WindowsXPShutdown;

    [Header("RespawnSounds")]

    [Metadata("WindowsXPStartup", Event.Spawn)]
    [DefaultValue(true)]
    public bool WindowsXPStartup;
  }
}
