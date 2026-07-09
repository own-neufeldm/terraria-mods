using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MemeSounds.Content
{
  public class MemeSoundsPlayer : ModPlayer
  {
    public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
    {
      var config = ModContent.GetInstance<Configuration.Client>();
      PlayRandomSound(config.DeathSounds);
    }

    public override void OnEnterWorld()
    {
      var config = ModContent.GetInstance<Configuration.Client>();
      PlayRandomSound(config.SpawnSounds);
    }

    public override void OnRespawn()
    {
      var config = ModContent.GetInstance<Configuration.Client>();
      PlayRandomSound(config.SpawnSounds);
    }

    public void PlayRandomSound(List<SoundStyle> sounds)
    {
      if (sounds.Count == 0) return;
      SoundStyle sound = sounds[Main.rand.Next(sounds.Count)];
      SoundEngine.PlaySound(sound, Player.position);
    }
  }
}
