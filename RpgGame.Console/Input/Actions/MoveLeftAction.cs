using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveLeftAction : IGameAction    // This class represents the action of moving left in the game.
    {
        public string HelpText => "A - move left";
        public string HelpGroup => "Movement";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.A;
        public bool IsAvailable(GameContext context) => true;

        public void Execute(GameContext context)
        {
            context.LastMessage = context.Player.TryMove(context.World, 0, -1) ? "Moved left." : "Blocked.";
        }
    }
}
