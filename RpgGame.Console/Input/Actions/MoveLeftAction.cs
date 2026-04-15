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
            var target = context.Player.Position.Move(0, -1);
            bool moved = context.Player.TryMove(context.World, 0, -1);
            context.LastMessage = moved ? "Moved left." : "Blocked.";

            if (!moved && context.World.IsInBounds(target) && context.World.Cell(target).IsWall)
            {
                RpgGame.Core.Logging.GameLog.Write($"Attempted to walk into a wall at {target.Row},{target.Col}.");
            }
        }
    }
}
