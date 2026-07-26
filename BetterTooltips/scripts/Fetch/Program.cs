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

        config.AddBranch("hooks", remote =>
        {
          remote.SetDescription("Fetch stats for hooks");
          remote.AddCommand<Commands.Hooks.ThoriumCommand>("thorium");
          remote.AddCommand<Commands.Hooks.VanillaCommand>("vanilla");
        });

        config.AddBranch("wings", remote =>
        {
          remote.SetDescription("Fetch stats for wings");
          remote.AddCommand<Commands.Wings.ThoriumCommand>("thorium");
          remote.AddCommand<Commands.Wings.VanillaCommand>("vanilla");
        });
      });
      return app.Run(args);
    }
  }
}
