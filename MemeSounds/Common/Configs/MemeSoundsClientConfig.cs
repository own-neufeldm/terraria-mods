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

  public class MemeSoundsClientConfig : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [JsonIgnore]
    public List<SoundStyle> DeathSounds { get; } = [];

    [JsonIgnore]
    public List<SoundStyle> SpawnSounds { get; } = [];

    [Header("SoundEffects")]

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent Ack;

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent Fah;

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent Knocked;

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent MagicFlute;

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent MetalPipe;

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent ReverbFart;

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent WrestlingBell;

    [DefaultValue(MemeSoundsEvent.Death)]
    public MemeSoundsEvent SystemShutdown;

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

        var sound = new SoundStyle($"MemeSounds/Assets/Sounds/{field.Name}").WithVolumeScale(0.3f);
        if (onEvent == MemeSoundsEvent.Death) DeathSounds.Add(sound);
        if (onEvent == MemeSoundsEvent.Spawn) SpawnSounds.Add(sound);
      }
    }
  }
}
