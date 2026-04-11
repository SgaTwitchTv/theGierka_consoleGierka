using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input
{
    public interface IGameAction    // Interface for game actions that can be triggered by user input
    {
        string HelpText { get; }      // Description of the action for help purposes
        string HelpGroup { get; }   // Grouping for help display like: "Movement", "Combat", "Inventory"...
        bool Matches(ConsoleKeyInfo keyInfo);       // Determines if the given key input matches this action
        bool IsAvailable(GameContext context);    // Checks if the action is currently available based on the game context like player state or location
        void Execute(GameContext context);      // Executes the action, modifying the game context as needed.
    }
}
