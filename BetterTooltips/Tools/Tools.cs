using Spectre.Console.Cli;
using Tools.Commands;

namespace Tools
{
  public class Tools
  {
    public static int Main(string[] args)
    {
      var app = new CommandApp();
      app.Configure(config =>
      {
        config.AddCommand<WingsCommand>("wings");
      });
      return app.Run(args);
    }
  }
}
