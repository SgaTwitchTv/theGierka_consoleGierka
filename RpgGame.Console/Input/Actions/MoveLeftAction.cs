using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveLeftAction : IGameAction    // This class represents the action of moving left in the game.
    {
        public string HelpText => "";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.A;

        public void Execute(GameContext context)
        {
            context.Player.TryMove(context.World, 0, -1);
            context.LastMessage = "Moved left.";
        }
    }
}
