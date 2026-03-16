using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Dungeons.Placement;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class RandomItemsProcedure : IDungeonProcedure  // A dungeon procedure that places a specified number of random items in the dungeon using a provided item source. The procedure utilizes the IRandomItemSource to obtain random items and places them in random positions within the dungeon world.
    {
        public string Name => "Random items";

        private readonly int _itemCount;
        private readonly IRandomItemSource _itemSource;

        public RandomItemsProcedure(int itemCount, IRandomItemSource itemSource)
        {
            _itemCount = itemCount;
            _itemSource = itemSource;
        }

        public IEnumerable<string> GetInstructions()
        {
            yield return "Items are placed in the dungeon.";
            yield return "Stand on an item and press E to pick it up.";
        }

        public void Apply(DungeonBuildContext context)  // The Apply method is responsible for placing the random items in the dungeon. It first collects all the floor positions in the dungeon world, and then randomly selects positions to place the items. The number of items placed is determined by the _itemCount field, and the items themselves are obtained from the _itemSource.
        {
            var floorPositions = CollectFloorPositions(context.World);

            if (floorPositions.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _itemCount; i++)
            {
                int index = context.Random.Next(floorPositions.Count);
                var pos = floorPositions[index];

                context.World.Cell(pos).Items.Add(_itemSource.Next(context.Random));
            }
        }

        private static List<Pos> CollectFloorPositions(World.World world)   // This method iterates through all the cells in the dungeon world and collects the positions of the cells that can be entered (i.e., floor cells). It returns a list of these positions, which can then be used to randomly place items in the dungeon.
        {
            var positions = new List<Pos>();

            for (int r = 0; r < world.Rows; r++)
            {
                for (int c = 0; c < world.Cols; c++)
                {
                    var pos = new Pos(r, c);
                    if (world.CanEnter(pos))
                    {
                        positions.Add(pos);
                    }
                }
            }

            return positions;
        }
    }
}
