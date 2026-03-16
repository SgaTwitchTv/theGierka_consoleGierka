using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveRightAction : IGameAction   // This class represents the action of moving the player to the right in the game.
    {
        public string HelpText => "";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.D; // This method checks if the pressed key is 'D', which is the key assigned for moving right.

        public void Execute(GameContext context)
        {
            context.Player.TryMove(context.World, 0, 1);
            context.LastMessage = "Moved right.";
        }
    }
}
