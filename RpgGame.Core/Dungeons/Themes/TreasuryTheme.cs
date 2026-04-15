using RpgGame.Core.Dungeons.Placement;
using RpgGame.Core.Dungeons.Procedures;
using RpgGame.Core.Dungeons.Strategies;
using RpgGame.Core.Items.Weapons.Artifacts;

namespace RpgGame.Core.Dungeons.Themes
{
    public sealed class TreasuryTheme : IDungeonTheme   // This theme is inspired by the idea of a treasury or vault, filled with valuable items and guarded by greedy enemies. The unique item is a Lucky Coin Pouch, which can provide the player with extra gold or valuable items when used. The enemies are themed around money and greed, such as angry briefcases, living safes, and greedy chests.
    {
        public string Name => "Restless Treasury";
        public string IntroMessage => "You feel an itch in your wallet.";

        public IDungeonStrategy CreateStrategy()    // The strategy for the Treasury theme includes a mix of procedures to create a dungeon that feels like a vault or treasury. The central room is larger to accommodate the idea of a vault, and there are several random paths to explore. The items include a mix of valuable treasures and gold, with a unique Lucky Coin Pouch as a special item. The enemies are themed around money and greed, fitting the concept of a treasury filled with valuable items that are guarded by greedy entities.
        {
            return new ThemedDungeonStrategy(Name, IntroMessage, new IDungeonProcedure[]
            {
                new FilledDungeonProcedure(),
                new CentralRoomProcedure(9, 15),
                new RandomPathsProcedure(16, 10),
                new EnsureConnectedDungeonProcedure(),
                new RandomItemsProcedure(16, new TreasuryItemSource()),
                new UniqueItemProcedure(new LuckyCoinPouch()),
                new RandomEnemiesProcedure(6, new NamedEnemySource(new[] { "Angry Briefcase", "Living Safe", "Greedy Chest" }, '$', health: 16, attack: 7, armor: 3))
            });
        }
    }
}
