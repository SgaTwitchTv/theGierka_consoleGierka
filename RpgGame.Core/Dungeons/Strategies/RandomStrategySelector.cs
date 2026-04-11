using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Dungeons.Strategies;

namespace RpgGame.Core.Dungeons.Strategies
{
    public static class RandomStrategySelector  // We select random strategy from the strategy list
    {
        public static IDungeonStrategy Choose(Random random)
        {
            var strategies = new List<IDungeonStrategy>
            {
                new DungeonGroundsStrategy(),
                new RoomsAndPathsNoItemsStrategy()
            };

            int index = random.Next(strategies.Count);
            return strategies[index];
        }
    }
}
