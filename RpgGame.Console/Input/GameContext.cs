using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Console.Input
{
    public sealed class GameContext // Context class that holds the current state of the game, including the world and player information
    {
        public World World { get; }
        public Player Player { get; }

        public string LastMessage { get; set; } = "";
        public int SelectedInventoryIndex { get; set; } = 0;
        public bool IsRunning { get; set; } = true;

        public GameContext(World world, Player player)
        {
            World = world;
            Player = player;
        }
    }
}
