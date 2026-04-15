using RpgGame.Core.Items;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class UniqueItemProcedure : IDungeonProcedure // A procedure that places a unique item in the dungeon.
    {
        private readonly IItem _item;

        public UniqueItemProcedure(IItem item)
        {
            _item = item;
        }

        public string Name => $"Unique item: {_item.Name}";

        public IEnumerable<string> GetInstructions()
        {
            yield return $"A unique artifact is hidden here: {_item.Name}.";
        }

        public void Apply(DungeonBuildContext context)  // This method collects all floor positions in the dungeon and randomly places the unique item on one of those positions.
        {
            var floorPositions = CollectFloorPositions(context.World);
            if (floorPositions.Count == 0)
            {
                return;
            }

            var pos = floorPositions[context.Random.Next(floorPositions.Count)];
            context.World.Cell(pos).Items.Add(_item);
        }

        private static List<Pos> CollectFloorPositions(World.World world)   // This method iterates through all cells in the world and collects positions that are enterable, indicating they are floor positions where the unique item can be placed.
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
