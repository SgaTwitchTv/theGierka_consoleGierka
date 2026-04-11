using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    internal class RandomPathsProcedure : IDungeonProcedure // A dungeon procedure that creates random paths in the dungeon, starting from a random position and carving out paths in random directions until a certain number of paths have been created
    {
        public string Name => "Random paths";

        private readonly int _pathCount;
        private readonly int _maxPathLength;

        public RandomPathsProcedure(int pathCount, int maxPathLength)
        {
            _pathCount = pathCount;
            _maxPathLength = maxPathLength;
        }

        public IEnumerable<string> GetInstructions()
        {
            yield break;
        }

        public void Apply(DungeonBuildContext context)
        {
            for(int i = 0; i < _pathCount; i++)
            {
                CarveSinglePath(context);
            }
        }

        private void CarveSinglePath(DungeonBuildContext context)   // Carve a single random path starting from a random position and going in a random direction for a random length
        {
            int row = context.Random.Next(context.World.Rows);
            int col = context.Random.Next(context.World.Cols);

            int direction = context.Random.Next(4); // 0 = up, 1 = right, 2 = down, 3 = left
            int length = context.Random.Next(3, _maxPathLength + 1);

            int dRow = 0;
            int dCol = 0;

            switch(direction)
            {
                // Up
                case 0:
                    dRow = -1;
                    break;
                
                // Down
                case 1:
                    dRow = 1;
                    break;

                // Left
                case 2:
                    dCol = -1;
                    break;

                // Right
                case 3:
                    dCol = 1;
                    break;
            }

            for (int step = 0; step < length; step++)   // Carve out the path step by step
            {
                var pos = new Pos(row, col);

                if(!context.World.IsInBounds(pos))
                {
                    break;
                }

                context.World.SetFloor(pos);

                row += dRow;
                col += dCol;
            }
        }
    }
}
