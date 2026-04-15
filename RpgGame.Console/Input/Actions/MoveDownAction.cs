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
            var target = context.Player.Position.Move(1, 0);
            bool moved = context.Player.TryMove(context.World, 1, 0);
            context.LastMessage = moved ? "Moved down." : "Blocked.";

            if (!moved && context.World.IsInBounds(target) && context.World.Cell(target).IsWall)
            {
                RpgGame.Core.Logging.GameLog.Write($"Attempted to walk into a wall at {target.Row},{target.Col}.");
            }
        }
    }
}
