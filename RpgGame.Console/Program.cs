using RpgGame.Console.Configuration;
using RpgGame.Console.Rendering;
using RpgGame.Core.Dungeons.Strategies;
using RpgGame.Core.Dungeons.Themes;
using RpgGame.Core.Entities;
using RpgGame.Core.Logging;
using RpgGame.Core.World;

namespace RpgGame.Console;

internal static class Program
{
    static void Main()
    {
        System.Console.Title = "RPG Game";

        var config = GameConfigurationLoader.Load(Path.Combine(AppContext.BaseDirectory, "gameconfig.json"));   // Load configuration from file
        var startedAt = DateTime.Now;                                                                          // Initialize logging with a file logger that includes the player's name and timestamp

        GameLog.Configure(new FileEventLogger(config.LogDirectory, config.PlayerName, startedAt));           // Log the configuration loading
        GameLog.Write("Configuration loaded.");

        var random = new Random();
        var theme = RandomThemeSelector.Choose(random);                                                 // Create a dungeon strategy based on the selected theme
        var strategy = theme.CreateStrategy();                                                         // Log the selected theme and its intro message
        GameLog.Write($"Selected dungeon theme: {theme.Name}. {theme.IntroMessage}");

        var world = DungeonStrategyRunner.Build(strategy, 20, 40);                                  // Log the world generation

        var player = new Player(config.PlayerName);
        player.SetPosition(world.FindFirstFloor());
        GameLog.Write($"{player.Name} entered the dungeon at {player.Position.Row},{player.Position.Col}.");

        var renderer = new ConsoleRenderer();
        var loop = new GameLoop(world, player, renderer, strategy.GetInstructions(), theme.IntroMessage);

        loop.Run();
    }
}
