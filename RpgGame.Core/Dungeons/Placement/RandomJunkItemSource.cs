using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Junk;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class RandomJunkItemSource : IRandomItemSource  // An item source that generates random junk items, which can be used for placing random items in the dungeon during the build process.
    {
        public Item Next(Random random)
        {
            int roll = random.Next(3);

            return roll switch
            {
                0 => new Rock(),
                1 => new OldBoot(),
                _ => new BrokenAmulet()
            };
        }
    }
}
