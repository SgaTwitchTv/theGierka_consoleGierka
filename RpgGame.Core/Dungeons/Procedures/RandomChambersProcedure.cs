using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class RandomChambersProcedure : IDungeonProcedure  // A dungeon procedure that creates random chambers in the dungeon, starting from a random position and carving out a rectangular chamber of random size until a certain number of chambers have been created
    {
        public string Name => "Random chambers";

        private readonly int _chamberCount;
        private readonly int _minSize;
        private readonly int _maxSize;

        public RandomChambersProcedure(int chamberCount, int minSize, int maxSize)
        {
            _chamberCount = chamberCount;
            _minSize = minSize;
            _maxSize = maxSize;
        }

        public void Apply(DungeonBuildContext context)
        {
            for(int i = 0; i < _chamberCount; i++)
            {
                CarveSingleChamber(context);
            }
        }

        private void CarveSingleChamber(DungeonBuildContext context)   // Carve a single random chamber starting from a random position and carving out a rectangular chamber of random size
        {
            int size = context.Random.Next(_minSize, _maxSize + 1);

            if (size > context.World.Rows || size > context.World.Cols)
            {
                return;
            }

            int startRow = context.Random.Next(0, context.World.Rows - size + 1);
            int startCol = context.Random.Next(0, context.World.Cols - size + 1);

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    var pos = new Pos(startRow + r, startCol + c);
                    context.World.SetFloor(pos);
                }
            }
        }
    }
}
