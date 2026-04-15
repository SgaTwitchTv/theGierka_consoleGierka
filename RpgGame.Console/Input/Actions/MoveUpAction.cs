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
            var target = context.Player.Position.Move(-1, 0);
            bool moved = context.Player.TryMove(context.World, -1, 0);
            context.LastMessage = moved ? "Moved up." : "Blocked.";

            if (!moved && context.World.IsInBounds(target) && context.World.Cell(target).IsWall)
            {
                RpgGame.Core.Logging.GameLog.Write($"Attempted to walk into a wall at {target.Row},{target.Col}.");
            }
        }
    }
}
