namespace BetterTooltips.Common.Stats
{
  public class WingStat(float flightTime, int height, int speedBonus)
  {
    public float FlightTime = flightTime;
    public int Height = height;
    public int SpeedBonus = speedBonus;
    public static WingStat Empty() => new(0.0f, 0, 0);
  }
}
