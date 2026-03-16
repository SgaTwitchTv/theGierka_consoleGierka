using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveDownAction : IGameAction    // This class represents the action of moving down in the game.
    {
        public string HelpText => "";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.S;

        public void Execute(GameContext context)
        {
            context.Player.TryMove(context.World, 1, 0);
            context.LastMessage = "Moved down.";
        }
    }
}
