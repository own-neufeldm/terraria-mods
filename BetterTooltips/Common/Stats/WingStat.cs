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
    public string Name { get; set; } = Name;
    public int ID { get; set; } = ID;
    public float FlightTime { get; set; } = FlightTime;
    public int Height { get; set; } = Height;
    public int SpeedBonus { get; set; } = SpeedBonus;

    public static WingStat Empty() => new("", 0, 0f, 0, 0);
  }
}
