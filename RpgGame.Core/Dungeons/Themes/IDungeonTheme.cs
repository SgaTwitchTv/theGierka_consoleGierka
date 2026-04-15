using RpgGame.Core.Dungeons.Strategies;

namespace RpgGame.Core.Dungeons.Themes
{
    public interface IDungeonTheme  // The IDungeonTheme interface defines the structure for different dungeon themes in the game. Each theme has a name, an introductory message, and a method to create a dungeon strategy that generates the layout, items, and enemies according to the theme's concept. This allows for a variety of dungeon experiences while maintaining a consistent interface for generating dungeons.
    {
        string Name { get; }
        string IntroMessage { get; }
        IDungeonStrategy CreateStrategy();  // The CreateStrategy method is responsible for creating an instance of a dungeon strategy that defines how the dungeon will be generated. This includes the layout, the types of rooms, the placement of items and enemies, and any unique features that fit the theme. Each theme can have its own unique strategy to create a distinct dungeon experience.
    }
}
