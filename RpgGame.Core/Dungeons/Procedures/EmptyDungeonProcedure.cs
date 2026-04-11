using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    // DESIGN: Concrete Procedure (Command-like) - a concrete implementation of IDungeonProcedure that modifies the build context.
    public sealed class EmptyDungeonProcedure : IDungeonProcedure   // A dungeon procedure that fills the entire dungeon with walls, creating a "filled" dungeon
    {
        public string Name => "Empty dungeon";

        public IEnumerable<string> GetInstructions()
        {
            yield break;
        }

        public void Apply(DungeonBuildContext context)
        {
            for (int r = 0; r < context.World.Rows; r++)
            {
                for (int c = 0; c < context.World.Cols; c++)
                {
                    context.World.SetFloor(new Pos(r, c));
                }
            }
        }
    }
}
