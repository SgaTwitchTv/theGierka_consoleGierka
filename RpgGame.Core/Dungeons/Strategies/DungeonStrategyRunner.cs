using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Dungeons.Strategies
{
    public static class DungeonStrategyRunner   // This class is responsible for running the dungeon generation strategy and building the world based on it.
    {
        public static World.World Build(IDungeonStrategy strategy, int rows, int cols, int? seed = null)    // The build method takes an IDungeonStrategy, the dimensions of the world (rows and cols), and an optional seed for randomization. It uses the strategy to create a series of procedures, which are then added to a DungeonBuilder. Finally, it builds and returns the generated world.
        {
            var builder = new DungeonBuilder();

            foreach (var procedure in strategy.CreateProcedures())
            {
                builder.Add(procedure);
            }

            return builder.Build(rows, cols, seed);
        }
    }
}
