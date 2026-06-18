using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MyQualityOfLife
{
  public class MyQualityOfLife : Mod { }

  public class ChatCommand : ModCommand
  {
    public override string Command => "myqol";
    public override CommandType Type => CommandType.Chat;
    public override string Description => "A command-line tool for quality of life features.";

    public override void Action(CommandCaller caller, string input, string[] args)
    {
      if (args.Length == 0)
      {
        ShowHelp();
        return;
      }

      switch (args[0])
      {
        case "freeze":
          ToggleTimeFreeze();
          break;

        case "moondial":
          FastForwardTimeToDusk();
          break;

        case "quest":
          RotateAnglerQuest();
          break;

        case "sundial":
          FastForwardTimeToDawn();
          break;

        default:
          SendMessage("Unknown command.", Color.Red);
          break;
      }
    }

    private static void ShowHelp()
    {
      SendMessage("Usage: myqol <command>", Color.Yellow);
      SendMessage("freeze   Freeze or unfreeze time.");
      SendMessage("moondial   Fast-forward time to dusk.");
      SendMessage("quest   Rotate the angler quest.");
      SendMessage("sundial   Fast-forward time to dawn.");
    }

    // Send a chat message to this client's player.
    private static void SendMessage(string text, Color? color = null)
    {
      Terraria.Chat.ChatHelper.SendChatMessageToClient(
        Terraria.Localization.NetworkText.From(text),
        color ?? Color.White,
        Main.myPlayer
      );
    }

    // Broadcast a chat message to all players.
    private static void BroadcastMessage(string text, Color? color = null)
    {
      Terraria.Chat.ChatHelper.BroadcastChatMessage(
        Terraria.Localization.NetworkText.From(text),
        color ?? Color.White
      );
    }

    // Freeze or unfreeze time.
    //
    // TODO: confirm functionality in multiplayer with another player.
    private static void ToggleTimeFreeze()
    {
      var power = CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>();
      power.SetPowerInfo(!power.Enabled);
    }

    // Rotate the angler quest.
    //
    // The code below has been copied from Terraria.Main.AnglerQuestSwap() and
    // modified accordingly so it can be used in multiplayer by any player to
    // rotate the angler quest for all players.
    //
    // TODO: confirm functionality in multiplayer with another player.
    private static void RotateAnglerQuest()
    {
      Main.anglerWhoFinishedToday.Clear();
      Main.anglerQuestFinished = false;
      bool flag = NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || Main.hardMode || NPC.downedSlimeKing || NPC.downedQueenBee;
      bool flag2 = true;
      int tryCount = 0;
      while (flag2)
      {
        // Defining a new angler quest may fail if another mod has bad logic,
        // i.e. another mod tries to add an angler quest that is impossible.
        if (++tryCount > 1000)
        {
          Main.anglerQuest = 0;
          break;
        }
        flag2 = false;
        Main.anglerQuest = Main.rand.Next(Main.anglerQuestItemNetIDs.Length);
        int num = Main.anglerQuestItemNetIDs[Main.anglerQuest];
        if (num == 2454 && (!Main.hardMode || WorldGen.crimson))
          flag2 = true;

        if (num == 2457 && WorldGen.crimson)
          flag2 = true;

        if (num == 2462 && !Main.hardMode)
          flag2 = true;

        if (num == 2463 && (!Main.hardMode || !WorldGen.crimson))
          flag2 = true;

        if (num == 2465 && !Main.hardMode)
          flag2 = true;

        if (num == 2468 && !Main.hardMode)
          flag2 = true;

        if (num == 2471 && !Main.hardMode)
          flag2 = true;

        if (num == 2473 && !Main.hardMode)
          flag2 = true;

        if (num == 2477 && !WorldGen.crimson)
          flag2 = true;

        if (num == 2480 && !Main.hardMode)
          flag2 = true;

        if (num == 2483 && !Main.hardMode)
          flag2 = true;

        if (num == 2484 && !Main.hardMode)
          flag2 = true;

        if (num == 2485 && WorldGen.crimson)
          flag2 = true;

        if ((num == 2476 || num == 2453 || num == 2473) && !flag)
          flag2 = true;

        ItemLoader.IsAnglerQuestAvailable(num, ref flag2);
      }

      NetMessage.SendAnglerQuest(-1);
    }

    // Fast-forward time to dusk.
    //
    // TODO: fix multiplayer.
    private static void FastForwardTimeToDusk()
    {
      if (Main.IsFastForwardingTime()) return;
      Main.moondialCooldown = 0;
      Main.Moondialing();
    }

    // Fast-forward time to dawn.
    //
    // TODO: fix multiplayer.
    private static void FastForwardTimeToDawn()
    {
      if (Main.IsFastForwardingTime()) return;
      Main.sundialCooldown = 0;
      Main.Sundialing();
    }
  }
}
