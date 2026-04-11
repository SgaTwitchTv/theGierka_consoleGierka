using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Junk;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class RandomJunkItemSource : IRandomItemSource  // An item source that generates random junk items, which can be used for placing random items in the dungeon during the build process.
    {
        public IItem Next(Random random)    // Implementation of the Next method from IRandomItemSource, which generates a random junk item based on a random roll. The method uses a switch expression to determine which junk item to create based on the result of the random roll.
        {
            int roll = random.Next(3);

            IItem item = roll switch
            {
                0 => new Rock(),
                1 => new OldBoot(),
                _ => new BrokenAmulet()
            };

            return item;
        }
    }
}
