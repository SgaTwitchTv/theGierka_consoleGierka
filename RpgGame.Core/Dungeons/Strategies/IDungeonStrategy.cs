using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Dungeons.Procedures;

namespace RpgGame.Core.Dungeons.Strategies
{
    public interface IDungeonStrategy   // An interface for defining a dungeon strategy, which includes a name, a method to create a sequence of dungeon procedures, and a method to get instructions for the player. Implementing this interface allows for different dungeon strategies to be created, each with its own unique layout, features, and instructions for players to follow when exploring the dungeon.
    {
        string Name { get; }
        IEnumerable<IDungeonProcedure> CreateProcedures();  // A method that returns a collection of dungeon procedures to build the dungeon layout and populate it with various elements such as rooms, paths, items, and enemies. Each procedure contributes to different aspects of the dungeon design, allowing for a modular and flexible approach to creating diverse dungeon environments.
        IEnumerable<string> GetInstructions();  // A method that returns a collection of instructions as strings. These instructions can be used to inform the player about specific mechanics, interactions, or objectives related to the dungeon strategy. The instructions can be aggregated from the individual procedures that make up the strategy, providing players with guidance on how to navigate and interact with the dungeon effectively.
    }
}
