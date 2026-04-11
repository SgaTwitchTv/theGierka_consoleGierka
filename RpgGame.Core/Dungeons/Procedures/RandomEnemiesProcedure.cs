using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class RandomEnemiesProcedure : IDungeonProcedure // A procedure that adds a specified number of random enemies to the dungeon.
    {
        public string Name => "Random enemies";

        private readonly int _enemyCount;

        public RandomEnemiesProcedure(int enemyCount)
        {
            _enemyCount = enemyCount;
        }

        public IEnumerable<string> GetInstructions()
        {
            yield return "Enemies lurk in the dungeon.";
        }

        public void Apply(DungeonBuildContext context)  // This method collects all free positions in the dungeon and randomly places the specified number of enemies on those positions.
        {
            var floorPositions = CollectFreePositions(context.World);

            if (floorPositions.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _enemyCount && floorPositions.Count > 0; i++)  // Loop through the number of enemies to add, ensuring we don't exceed the available free positions.
            {
                int index = context.Random.Next(floorPositions.Count);
                var pos = floorPositions[index];
                floorPositions.RemoveAt(index);

                var enemy = new Enemy("Goblin", '!', pos, health: 12, attack: 6, armor: 2);
                context.World.Cell(pos).Enemy = enemy;
            }
        }

        private static List<Pos> CollectFreePositions(World.World world)    // This method iterates through all cells in the world and collects positions that are enterable and have no items, indicating they are free for placing enemies.
        {
            var positions = new List<Pos>();

            for (int r = 0; r < world.Rows; r++)
            {
                for (int c = 0; c < world.Cols; c++)
                {
                    var pos = new Pos(r, c);
                    var cell = world.Cell(pos);
                    if (world.CanEnter(pos) && cell.Items.Count == 0)
                    {
                        positions.Add(pos);
                    }
                }
            }

            return positions;
        }
    }
}
