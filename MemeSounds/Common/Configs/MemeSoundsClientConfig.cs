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
    Death,
    Spawn,
  }

  [AttributeUsage(AttributeTargets.Field)]
  public class OnEventAttribute(MemeSoundsEvent value) : Attribute
  {
    public MemeSoundsEvent Value { get; } = value;
  }

  public class MemeSoundsClientConfig : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [JsonIgnore]
    public List<SoundStyle> DeathSounds { get; } = [];

    [JsonIgnore]
    public List<SoundStyle> SpawnSounds { get; } = [];

    [Header("DeathSounds")]

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.3f)]
    public float Ack;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.5f)]
    public float BoneBreak;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(1f)]
    public float BrickBreak;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.5f)]
    public float BrickDeath;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.5f)]
    public float CarHorn;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.3f)]
    public float Fah;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.3f)]
    public float Knocked;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.7f)]
    public float MagicFlute;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.5f)]
    public float MetalPipe;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.3f)]
    public float ReverbFart;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.5f)]
    public float WrestlingBell;

    [OnEvent(MemeSoundsEvent.Death)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.7f)]
    public float SystemShutdown;

    [Header("SpawnSounds")]

    [OnEvent(MemeSoundsEvent.Spawn)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.7f)]
    public float BoneBuild;

    [OnEvent(MemeSoundsEvent.Spawn)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.7f)]
    public float BrickBuild;

    [OnEvent(MemeSoundsEvent.Spawn)]
    [Slider]
    [DrawTicks]
    [Increment(0.1f)]
    [Range(0f, 1f)]
    [DefaultValue(0.7f)]
    public float SystemStartup;

    public override void OnChanged()
    {
      DeathSounds.Clear();
      SpawnSounds.Clear();

      foreach (var field in GetType().GetFields())
      {
        var attribute = Attribute.GetCustomAttribute(field, typeof(OnEventAttribute));
        if (attribute is not OnEventAttribute onEvent) continue;

        var value = (float)field.GetValue(this);
        if (value == 0f) continue;
        var sound = new SoundStyle($"MemeSounds/Assets/Sounds/{field.Name}")
        {
          Volume = value
        };

        if (onEvent.Value == MemeSoundsEvent.Death) DeathSounds.Add(sound);
        if (onEvent.Value == MemeSoundsEvent.Spawn) SpawnSounds.Add(sound);
      }
    }
  }
}
