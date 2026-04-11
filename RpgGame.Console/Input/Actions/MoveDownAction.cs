using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveDownAction : IGameAction    // This class represents the action of moving down in the game.
    {
        public string HelpText => "S - move down";
        public string HelpGroup => "Movement";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.S;
        public bool IsAvailable(GameContext context) => true;

        public void Execute(GameContext context)
        {
            context.LastMessage = context.Player.TryMove(context.World, 1, 0) ? "Moved down." : "Blocked.";
        }
    }
}
