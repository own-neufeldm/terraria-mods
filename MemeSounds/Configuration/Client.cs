using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Terraria.Audio;
using Terraria.ModLoader.Config;

namespace MemeSounds.Configuration
{
  public class Client : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [JsonIgnore]
    public List<SoundStyle> DeathSounds { get; } = [];

    [JsonIgnore]
    public List<SoundStyle> SpawnSounds { get; } = [];

    [Header("DeathSounds")]

    [SoundName("13OunceOkayLong")]
    [OnEvent(Event.Death)]
    [DefaultValue(false)]
    public bool ThirteenOunceOkayLong;

    [SoundName("13OunceOkayShort")]
    [OnEvent(Event.Death)]
    [DefaultValue(false)]
    public bool ThirteenOunceOkayShort;

    [SoundName("MetalPipeFalling")]
    [OnEvent(Event.Death)]
    [DefaultValue(false)]
    public bool MetalPipeFalling;

    [SoundName("MinecraftTNT")]
    [OnEvent(Event.Death)]
    [DefaultValue(false)]
    public bool MinecraftTNT;

    [SoundName("ReverbFart")]
    [OnEvent(Event.Death)]
    [DefaultValue(false)]
    public bool ReverbFart;

    [SoundName("WindowsXPError")]
    [OnEvent(Event.Death)]
    [DefaultValue(false)]
    public bool WindowsXPError;

    [SoundName("WindowsXPShutdown")]
    [OnEvent(Event.Death)]
    [DefaultValue(true)]
    public bool WindowsXPShutdown;

    [Header("RespawnSounds")]

    [SoundName("WindowsXPStartup")]
    [OnEvent(Event.Spawn)]
    [DefaultValue(true)]
    public bool WindowsXPStartup;

    public override void OnChanged()
    {
      DeathSounds.Clear();
      SpawnSounds.Clear();

      foreach (var field in GetType().GetFields())
      {
        if (Attribute.GetCustomAttribute(field, typeof(SoundNameAttribute)) is not SoundNameAttribute soundName)
          continue;
        if (Attribute.GetCustomAttribute(field, typeof(OnEventAttribute)) is not OnEventAttribute onEvent)
          continue;
        if (!(bool)field.GetValue(this))
          continue;

        SoundStyle sound = new($"MemeSounds/Sounds/{soundName.Value}");
        if (onEvent.Value == Event.Death) DeathSounds.Add(sound);
        if (onEvent.Value == Event.Spawn) SpawnSounds.Add(sound);
      }
    }
  }
}
