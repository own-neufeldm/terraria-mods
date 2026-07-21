namespace BetterTooltips.Common.Stats
{
  public class WingStat(float flightTime, int height, float speedBonus)
  {
    public float FlightTime = flightTime;
    public int Height = height;
    public float SpeedBonus = speedBonus;
    public static WingStat Empty() => new(0.0f, 0, 0.0f);
  }
}
