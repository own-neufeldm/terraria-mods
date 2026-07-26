using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
  config.SetApplicationName("fetch");

  config.AddBranch("wings", remote =>
  {
    remote.SetDescription("Fetch stats for wings");
    remote.AddCommand<Fetch.Commands.Wings.VanillaCommand>("vanilla");
    remote.AddCommand<Fetch.Commands.Wings.ThoriumCommand>("thorium");
  });
});
return app.Run(args);
