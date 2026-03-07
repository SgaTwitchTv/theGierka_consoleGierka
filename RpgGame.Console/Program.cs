using RpgGame.Console.Rendering;
using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Console;

internal static class Program   // The entry point of the app
{
    static void Main()
    {
        System.Console.Title = "RPG Game";  // The title

        var world = WorldFactory.CreateStage1Room();    // Create the world
        var player = new Player();                     // Create the player
        var renderer = new ConsoleRenderer();         // Create the renderer

        // Create and start the loop
        var loop = new GameLoop(world, player, renderer);
        loop.Run();
    }
}