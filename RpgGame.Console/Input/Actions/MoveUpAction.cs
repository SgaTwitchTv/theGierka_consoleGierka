using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveUpAction : IGameAction  // This class represents the action of moving up in the game.
    {
        public string HelpText => "";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.W;

        public void Execute(GameContext context)
        {
            context.Player.TryMove(context.World, -1, 0);
            context.LastMessage = "Moved up.";
        }
    }
}
