namespace BetterTooltips.Common.Stats
{
  public record HookStat(
    string Name,
    int ID,
    int Reach,
    int Velocity,
    int Hooks
  )
  {
    public static HookStat Empty() => new("", 0, 0, 0, 0);
  }
}
