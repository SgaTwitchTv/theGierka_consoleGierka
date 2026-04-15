using RpgGame.Core.Dungeons.Placement;
using RpgGame.Core.Dungeons.Procedures;
using RpgGame.Core.Dungeons.Strategies;
using RpgGame.Core.Items.Weapons.Artifacts;

namespace RpgGame.Core.Dungeons.Themes
{
    public sealed class LibraryTheme : IDungeonTheme    // This theme is inspired by the idea of a forgotten library, filled with ancient books and knowledge. The enemies are spectral and the items are related to magic and lore. The unique item is a powerful wand that can be found in the depths of the library.
    {
        public string Name => "Forgotten Library";
        public string IntroMessage => "The smell of old books fills the air.";

        public IDungeonStrategy CreateStrategy()    // The strategy for the Library theme includes a mix of procedures to create a dungeon that feels like an ancient library. The dungeon is filled with random paths and chambers to explore, with a focus on finding magical items and weapons. The unique item is the Black Wand, a powerful artifact that can be found in the library. The enemies are spectral, fitting the theme of a haunted library filled with restless spirits.
        {
            return new ThemedDungeonStrategy(Name, IntroMessage, new IDungeonProcedure[]
            {
                new FilledDungeonProcedure(),
                new RandomPathsProcedure(20, 12),
                new RandomChambersProcedure(3, 2, 4),
                new EnsureConnectedDungeonProcedure(),
                new RandomItemsProcedure(10, new LibraryItemSource()),
                new RandomWeaponsProcedure(3, new RandomWeaponSource()),
                new UniqueItemProcedure(new BlackWand()),
                new RandomEnemiesProcedure(5, new NamedEnemySource(new[] { "Mage", "Archivist", "Book Wraith" }, '?', health: 10, attack: 7, armor: 1))
            });
        }
    }
}
