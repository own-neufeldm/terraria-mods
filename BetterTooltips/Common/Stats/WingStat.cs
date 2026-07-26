namespace BetterTooltips.Common.Stats
{
  public record WingStat(
    string Name,
    int ID,
    float FlightTime,
    int Height,
    int SpeedBonus
  )
  {
    public static WingStat Empty() => new("", 0, 0.0f, 0, 0);
  }
}
