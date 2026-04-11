using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveUpAction : IGameAction  // This class represents the action of moving up in the game.
    {
        public string HelpText => "W - move up";
        public string HelpGroup => "Movement";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.W;
        public bool IsAvailable(GameContext context) => true;

        public void Execute(GameContext context)
        {
            context.LastMessage = context.Player.TryMove(context.World, -1, 0) ? "Moved up." : "Blocked.";
        }
    }
}
