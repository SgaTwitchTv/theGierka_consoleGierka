using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons
{
    public sealed class DungeonBuildContext // Context class to hold the world and random generator for dungeon building
    {
        public World.World World { get; }
        public Random Random { get; }

        public DungeonBuildContext(World.World world, Random random)
        {
            World = world;
            Random = random;
        }
    }
}
