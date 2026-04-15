using RpgGame.Core.Items;
using RpgGame.Core.Items.Currency;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class TreasuryItemSource : IRandomItemSource  // An item source that generates random currency items, which can be used for placing random items in the dungeon during the build process.
    {
        public IItem Next(Random random)    // Implementation of the Next method from IRandomItemSource, which generates a random currency item based on a random roll. The method uses a simple random check to determine whether to create a Coin or Gold item.
        {
            return random.Next(2) == 0 ? new Coin() : new Gold();
        }
    }
}
