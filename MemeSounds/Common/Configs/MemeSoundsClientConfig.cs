using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Terraria.Audio;
using Terraria.ModLoader.Config;

namespace MemeSounds.Common.Configs
{
  public enum MemeSoundsEvent
  {
    Disabled,
    Death,
    Spawn,
  }

  [AttributeUsage(AttributeTargets.Field)]
  public class SoundOptionsAttribute(float volume) : Attribute
  {
    public float Volume { get; } = volume;
  }

  public class MemeSoundsClientConfig : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [JsonIgnore]
    public List<SoundStyle> DeathSounds { get; } = [];

    [JsonIgnore]
    public List<SoundStyle> SpawnSounds { get; } = [];

    [Header("SoundEffects")]

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent Ack;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent Fah;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent Knocked;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent MagicFlute;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent MetalPipe;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent ReverbFart;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent WrestlingBell;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent SystemShutdown;

    [SoundOptions(volume: 1f)]
    [DefaultValue(MemeSoundsEvent.Spawn)]
    public MemeSoundsEvent SystemStartup;

    public override void OnChanged()
    {
      DeathSounds.Clear();
      SpawnSounds.Clear();

      foreach (var field in GetType().GetFields())
      {
        if (field.FieldType != typeof(MemeSoundsEvent)) continue;
        var onEvent = (MemeSoundsEvent)field.GetValue(this);
        if (onEvent == MemeSoundsEvent.Disabled) continue;

        var options = (SoundOptionsAttribute)Attribute.GetCustomAttribute(
          field,
          typeof(SoundOptionsAttribute)
        );
        var sound = new SoundStyle($"MemeSounds/Assets/Sounds/{field.Name}")
        {
          Volume = options.Volume
        };

        if (onEvent == MemeSoundsEvent.Death) DeathSounds.Add(sound);
        if (onEvent == MemeSoundsEvent.Spawn) SpawnSounds.Add(sound);
      }
    }
  }
}
