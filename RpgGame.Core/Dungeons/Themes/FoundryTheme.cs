using RpgGame.Core.Dungeons.Placement;
using RpgGame.Core.Dungeons.Procedures;
using RpgGame.Core.Dungeons.Strategies;
using RpgGame.Core.Items.Weapons.Artifacts;

namespace RpgGame.Core.Dungeons.Themes
{
    public sealed class FoundryTheme : IDungeonTheme    // This theme is inspired by the idea of a foundry or factory, with a focus on metal and machinery. The enemies are robotic and the items are related to technology and engineering.
    {
        public string Name => "Echoing Foundry";
        public string IntroMessage => "The clang of metal echoes off the walls.";

        public IDungeonStrategy CreateStrategy()    // The strategy for the Foundry theme includes a mix of procedures to create a dungeon that feels industrial and mechanical. The central room is larger to accommodate machinery, and there are several random chambers and paths to explore. The items include a mix of technological gadgets and weapons, with a unique blaster as a special item. The enemies are robotic, fitting the theme of a foundry or factory.
        {
            return new ThemedDungeonStrategy(Name, IntroMessage, new IDungeonProcedure[]
            {
                new FilledDungeonProcedure(),
                new CentralRoomProcedure(5, 9),
                new RandomChambersProcedure(10, 3, 6),
                new RandomPathsProcedure(8, 8),
                new EnsureConnectedDungeonProcedure(),
                new RandomItemsProcedure(12, new FoundryItemSource()),
                new RandomWeaponsProcedure(5, new RandomWeaponSource()),
                new UniqueItemProcedure(new Blaster()),
                new RandomEnemiesProcedure(5, new NamedEnemySource(new[] { "Cleaning Robot", "Rust Drone", "Insurgent Automaton" }, 'R', health: 14, attack: 6, armor: 4))
            });
        }
    }
}
