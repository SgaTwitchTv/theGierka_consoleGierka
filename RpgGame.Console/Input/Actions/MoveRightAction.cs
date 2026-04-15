using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MoveRightAction : IGameAction   // This class represents the action of moving the player to the right in the game.
    {
        public string HelpText => "D - move right";
        public string HelpGroup => "Movement";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.D; // This method checks if the pressed key is 'D', which is the key assigned for moving right.
        public bool IsAvailable(GameContext context) => true;

        public void Execute(GameContext context)
        {
            var target = context.Player.Position.Move(0, 1);
            bool moved = context.Player.TryMove(context.World, 0, 1);
            context.LastMessage = moved ? "Moved right." : "Blocked.";

            if (!moved && context.World.IsInBounds(target) && context.World.Cell(target).IsWall)
            {
                RpgGame.Core.Logging.GameLog.Write($"Attempted to walk into a wall at {target.Row},{target.Col}.");
            }
        }
    }
}
