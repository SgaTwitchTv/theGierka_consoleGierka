using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.World;   

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class FilledDungeonProcedure : IDungeonProcedure  // A dungeon procedure that fills the entire dungeon with walls, creating a "filled" dungeon
    {
        public string Name => "Filled dungeon";

        public void Apply(DungeonBuildContext context)
        {
            for (int r = 0; r < context.World.Rows; r++)
            {
                for (int c = 0; c < context.World.Cols; c++)
                {
                    context.World.SetWall(new Pos(r, c));
                }
            }
        }
    }
}
