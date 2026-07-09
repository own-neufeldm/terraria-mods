using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MemeSounds.Content
{
  public class MemeSoundPlayer : ModPlayer
  {
    public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
    {
      PlaySound(Configuration.Event.Death);
    }

    public override void OnEnterWorld()
    {
      PlaySound(Configuration.Event.Spawn);
    }

    public override void OnRespawn()
    {
      PlaySound(Configuration.Event.Spawn);
    }

    public void PlaySound(Configuration.Event onEvent)
    {
      var config = ModContent.GetInstance<Configuration.Client>();

      var sounds = new List<SoundStyle>();
      foreach (var f in config.GetType().GetFields())
      {
        if (Attribute.GetCustomAttribute(f, typeof(Configuration.MetadataAttribute)) is not Configuration.MetadataAttribute a)
          continue;
        if (a.OnEvent != onEvent)
          continue;
        if ((bool)f.GetValue(config))
          sounds.Add(new($"MemeSounds/Sounds/{a.Filename}"));
      }
      if (sounds.Count == 0) return;

      SoundStyle sound = sounds[Main.rand.Next(sounds.Count)];
      SoundEngine.PlaySound(sound, Player.position);
    }
  }
}
