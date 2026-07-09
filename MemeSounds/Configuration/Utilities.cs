using System;

namespace MemeSounds.Configuration
{
  public enum Event
  {
    Death,
    Spawn,
  }

  [AttributeUsage(AttributeTargets.Field)]
  public class OnEventAttribute(Event value) : Attribute
  {
    public Event Value { get; } = value;
  }

  [AttributeUsage(AttributeTargets.Field)]
  public class SoundNameAttribute(string value) : Attribute
  {
    public string Value { get; } = value;
  }
}
