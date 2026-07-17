using System.Collections.Generic;
using MemeSounds.Common.Configs;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MemeSounds.Common.Players
{
  public class MemeSoundsPlayer : ModPlayer
  {
    public override void Kill(
      double damage,
      int hitDirection,
      bool pvp,
      PlayerDeathReason damageSource
    )
    {
      var config = ModContent.GetInstance<MemeSoundsClientConfig>();
      var seed = (int)(Main.GameUpdateCount + Player.whoAmI);
      PlayRandomSound(config.DeathSounds, seed);
    }

    public override void OnEnterWorld()
    {
      var config = ModContent.GetInstance<MemeSoundsClientConfig>();
      var seed = (int)(Main.GameUpdateCount + Player.whoAmI);
      PlayRandomSound(config.SpawnSounds, seed);
    }

    public override void OnRespawn()
    {
      var config = ModContent.GetInstance<MemeSoundsClientConfig>();
      var seed = (int)(Main.GameUpdateCount + Player.whoAmI);
      PlayRandomSound(config.SpawnSounds, seed);
    }

    public void PlayRandomSound(List<SoundStyle> sounds, int seed)
    {
      if (sounds.Count == 0) return;
      var random = new Terraria.Utilities.UnifiedRandom(seed);
      var sound = sounds[random.Next(sounds.Count)];
      SoundEngine.PlaySound(sound, Player.position);
    }
  }
}
