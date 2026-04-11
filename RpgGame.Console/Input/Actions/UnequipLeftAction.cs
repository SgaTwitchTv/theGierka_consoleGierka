using RpgGame.Core.Items.Equipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class UnequipLeftAction : IGameAction
    {
        public string HelpText => "1 - unequip left hand";
        public string HelpGroup => "Inventory";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.D1;
        public bool IsAvailable(GameContext context) => context.Player.Hands.Left != null;

        public void Execute(GameContext context)
        {
            context.Player.Hands.UnequipSlotToInventory(HandSlot.Left);
            context.LastMessage = "Unequipped left hand.";
        }
    }
}
