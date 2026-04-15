using RpgGame.Core.Dungeons.Procedures;
using RpgGame.Core.Dungeons.Strategies;

namespace RpgGame.Core.Dungeons.Themes
{
    public sealed class ThemedDungeonStrategy : IDungeonStrategy    // The ThemedDungeonStrategy class implements the IDungeonStrategy interface and is used to create a dungeon based on a specific theme. It takes a name, an introductory message, and a list of procedures that define how the dungeon will be generated. The CreateProcedures method returns the list of procedures, while the GetInstructions method provides the introductory message followed by the instructions from each procedure in order. This allows for a flexible and modular approach to creating themed dungeons, where different themes can have their own unique sets of procedures while sharing a common structure for generating dungeons.
    {
        private readonly IReadOnlyList<IDungeonProcedure> _procedures;  // The _procedures field holds a list of IDungeonProcedure instances that define the steps for generating the dungeon. These procedures can include various algorithms for creating rooms, placing items, and populating enemies, all tailored to fit the theme of the dungeon. By using a list of procedures, the ThemedDungeonStrategy allows for a modular and flexible approach to dungeon generation, where different themes can have their own unique combinations of procedures while still adhering to a common structure.
        private readonly string _introMessage;  // The _introMessage field holds a string that serves as the introductory message for the dungeon. This message is intended to set the tone and atmosphere for the player as they enter the dungeon, providing context and enhancing the thematic experience. The GetInstructions method will return this introductory message first, followed by the instructions from each of the procedures in the order they are defined, creating a cohesive narrative for the player as they explore the dungeon.

        public ThemedDungeonStrategy(string name, string introMessage, IReadOnlyList<IDungeonProcedure> procedures) // The constructor for the ThemedDungeonStrategy class initializes the name, introductory message, and list of procedures for the dungeon. The name is used to identify the theme of the dungeon, while the introductory message sets the tone for the player. The list of procedures defines the specific steps that will be taken to generate the dungeon according to the theme, allowing for a customized and immersive experience. By passing these parameters to the constructor, we can create different themed dungeons with unique characteristics and challenges for the player to explore.
        {
            Name = name;
            _introMessage = introMessage;
            _procedures = procedures;
        }

        public string Name { get; }

        public IEnumerable<IDungeonProcedure> CreateProcedures() => _procedures;    // The CreateProcedures method returns the list of procedures that will be used to generate the dungeon. This allows the dungeon generation system to execute each procedure in order, creating the layout, placing items, and populating enemies according to the theme's design. By returning the list of procedures, we can ensure that the dungeon is generated consistently with the intended theme and provides a cohesive experience for the player.

        public IEnumerable<string> GetInstructions()    // The GetInstructions method returns an enumerable of strings that includes the introductory message followed by the instructions from each procedure in the order they are defined. This allows the player to receive a narrative introduction to the dungeon, setting the tone and atmosphere, before being presented with the specific instructions for navigating and exploring the dungeon. By yielding the introductory message first, we can create a more immersive experience for the player as they enter the themed dungeon, enhancing their engagement and enjoyment of the game.
        {
            yield return _introMessage;

            foreach (var procedure in _procedures)
            {
                foreach (var instruction in procedure.GetInstructions())
                {
                    yield return instruction;
                }
            }
        }
    }
}
