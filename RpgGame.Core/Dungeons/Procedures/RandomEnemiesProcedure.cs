using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class RandomEnemiesProcedure : IDungeonProcedure
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

        public void Apply(DungeonBuildContext context)
        {
            var floorPositions = CollectFreePositions(context.World);

            if (floorPositions.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _enemyCount && floorPositions.Count > 0; i++)
            {
                int index = context.Random.Next(floorPositions.Count);
                var pos = floorPositions[index];
                floorPositions.RemoveAt(index);

                var enemy = new Enemy("Goblin", '!', pos, health: 12, attack: 6, armor: 2);
                context.World.Cell(pos).Enemy = enemy;
            }
        }

        private static List<Pos> CollectFreePositions(World.World world)
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
