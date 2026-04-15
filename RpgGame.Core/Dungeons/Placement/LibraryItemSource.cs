using RpgGame.Core.Items;
using RpgGame.Core.Items.Junk;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class LibraryItemSource : IRandomItemSource   // A class that implements the IRandomItemSource interface, providing a source of random items that can be placed in the library area of the dungeon. The Next method uses a Random object to randomly select and return an item from a predefined set of items (in this case, OldBook and BrokenAmulet).
    {
        public IItem Next(Random random)    // The Next method takes a Random object as a parameter and returns an IItem. It uses the random number generator to randomly select and return an item from a predefined set of items (in this case, OldBook and BrokenAmulet).
        {
            return random.Next(3) switch
            {
                0 => new OldBook(),
                1 => new BrokenAmulet(),
                _ => new OldBook()
            };
        }
    }
}
