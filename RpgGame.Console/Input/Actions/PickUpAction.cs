using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class PickUpAction : IGameAction  // This class represents an action that allows the player to pick up items from the current cell in the game world. It implements the IGameAction interface, which requires defining a HelpText property, a Matches method to determine if the action should be executed based on user input, and an Execute method that performs the action when triggered.
    {
        public string HelpText => "E - pick up item";
        public string HelpGroup => "Actions";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.E;
        public bool IsAvailable(GameContext context) => context.World.Cell(context.Player.Position).Items.Count > 0;

        public void Execute(GameContext context)
        {
            context.Player.TryPickUp(context.World, out var message);
            context.LastMessage = message;
            RpgGame.Core.Logging.GameLog.Write(message);
        }
    }
}
