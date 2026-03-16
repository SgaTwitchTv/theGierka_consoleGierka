using RpgGame.Core.Items.Equipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class UnequipRightAction : IGameAction
    {
        public string HelpText => "";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.D2;    // Matches function that checks if the input key is D2 (the number 2 key). If the player presses the D2 key, this action will be triggered, allowing them to unequip the item in their right hand.

        public void Execute(GameContext context)    // Execute function that unequips the item in the player's right hand and moves it back to the inventory. It calls the UnequipSlotToInventory method on the player's hands, specifying the right hand slot. After unequipping, it updates the last message in the game context to inform the player that the right hand has been unequipped.
        {
            context.Player.Hands.UnequipSlotToInventory(HandSlot.Right);
            context.LastMessage = "Unequipped right hand.";
        }
    }
}
