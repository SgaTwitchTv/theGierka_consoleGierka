using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class PickUpAction : IGameAction
    {
        public string HelpText => "";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.E;

        public void Execute(GameContext context)
        {
            context.Player.TryPickUp(context.World, out var message);
            context.LastMessage = message;
        }
    }
}
