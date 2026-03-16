using RpgGame.Console.Rendering;
using RpgGame.Core.Dungeons.Strategies;
using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Console;

internal static class Program
{
    static void Main()
    {
        System.Console.Title = "RPG Game";

        var strategy = new DungeonGroundsStrategy();
        var world = DungeonStrategyRunner.Build(strategy, 20, 40);

        var player = new Player();
        player.SetPosition(world.FindFirstFloor());

        var renderer = new ConsoleRenderer();
        var loop = new GameLoop(world, player, renderer, strategy.GetInstructions());

        loop.Run();
    }
}