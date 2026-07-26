using Spectre.Console.Cli;

namespace Fetch
{
  public class Program
  {
    public static int Main(string[] args)
    {
      var app = new CommandApp();
      app.Configure(config =>
      {
        config.SetApplicationName("fetch");

        config.AddBranch("wings", remote =>
        {
          remote.SetDescription("Fetch stats for wings");
          remote.AddCommand<Commands.Wings.VanillaCommand>("vanilla");
          remote.AddCommand<Commands.Wings.ThoriumCommand>("thorium");
        });
      });
      return app.Run(args);
    }
  }
}
