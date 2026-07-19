using Terraria;
using Terraria.ModLoader;

namespace BetterPickaxes.Common.Players
{
  public class BetterPickaxesPlayer : ModPlayer
  {
    public override void PostUpdate()
    {
      if (Player.GetBestPickaxe() is not Item best) return;
      for (int i = 0; i < Player.inventory.Length; i++)
      {
        Item item = Player.inventory[i];
        if (item.pick > 0) item.pick = best.pick;
      }
    }
  }
}
