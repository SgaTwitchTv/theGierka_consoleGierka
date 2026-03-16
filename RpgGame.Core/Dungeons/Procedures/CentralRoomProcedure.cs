using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class CentralRoomProcedure : IDungeonProcedure    // A dungeon procedure that creates a central room in the dungeon
    {
        public string Name => "Central room";

        private readonly int _height;
        private readonly int _width;

        public CentralRoomProcedure(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public void Apply(DungeonBuildContext context)  // Applies the central room procedure to the dungeon build context
        {

            int startRow = (context.World.Rows - _height) / 2;
            int startCol = (context.World.Cols - _width) / 2;

            for (int r = 0; r < _height; r++)
            {
                for (int c = 0; c < _width; c++)
                {
                    var pos = new Pos(startRow + r, startCol + c);
                    context.World.SetFloor(pos);
                }
            }
        }
    }
}
