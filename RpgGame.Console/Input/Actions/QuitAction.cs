using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class QuitAction : IGameAction    // This class represents an action that allows the player to quit the game. It implements the IGameAction interface, which requires defining a HelpText property, a Matches method to determine if the action should be executed based on user input, and an Execute method that performs the action when triggered.
    {
        public string HelpText => "Q - quit";
        public string HelpGroup => "System";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.Q || keyInfo.Key == ConsoleKey.Escape;
        public bool IsAvailable(GameContext context) => true;

        public void Execute(GameContext context)
        {
            context.LastMessage = "Quitting game.";
            context.IsRunning = false;
        }
    }
}
