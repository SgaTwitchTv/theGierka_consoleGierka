using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Dungeons.Placement;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class RandomWeaponsProcedure : IDungeonProcedure  // A dungeon procedure that places a specified number of random weapons in the dungeon using a provided weapon source. The procedure utilizes the IRandomWeaponSource to obtain random weapons and places them in random positions within the dungeon world.
    {
        public string Name => "Random weapons";

        private readonly int _weaponCount;
        private readonly IRandomWeaponSource _weaponSource;

        public RandomWeaponsProcedure(int weaponCount, IRandomWeaponSource weaponSource)
        {
            _weaponCount = weaponCount;
            _weaponSource = weaponSource;
        }
        
        public void Apply(DungeonBuildContext context)  // The Apply method is responsible for placing the random weapons in the dungeon. It first collects all the floor positions in the world using the CollectFloorPositions method. If there are no floor positions available, it simply returns. Otherwise, it randomly selects positions from the collected floor positions and places a random weapon obtained from the _weaponSource at each selected position until the specified number of weapons has been placed.
        {
            var floorPositions = CollectFloorPositions(context.World);

            if (floorPositions.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _weaponCount; i++)
            {
                int index = context.Random.Next(floorPositions.Count);
                var pos = floorPositions[index];

                context.World.Cell(pos).Items.Add(_weaponSource.Next(context.Random));
            }
        }

        private static List<Pos> CollectFloorPositions(World.World world)   // This method iterates through all the cells in the world and collects the positions of those that can be entered (i.e., floor positions). It returns a list of these positions, which can then be used for placing weapons or other items in the dungeon.
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

        public IEnumerable<string> GetInstructions()    // This method provides instructions related to the random weapons procedure. It yields a series of strings that inform the player about the presence of weapons in the dungeon and how to equip or unequip them using specific keys (L, R for equipping and 1, 2, U for unequipping).
        {
            yield return "Weapons are placed in the dungeon.";
            yield return "Use L or R to equip the selected inventory item.";
            yield return "Use 1, 2 or U to unequip.";
        }
    }
}
