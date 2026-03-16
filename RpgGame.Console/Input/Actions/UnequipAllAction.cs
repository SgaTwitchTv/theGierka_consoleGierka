using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Console.Input.Actions;

namespace RpgGame.Console.Input.Actions
{
    public sealed class UnequipAllAction : IGameAction  // This class represents an action that allows the player to unequip all items from their hands and move them back to their inventory. It implements the IGameAction interface, which requires defining a HelpText property, a Matches method to determine if the action should be executed based on user input, and an Execute method that performs the action when triggered.
    {
        public string HelpText => "";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.U;

        public void Execute(GameContext context)    // The Execute method performs the action of unequipping all items from the player's hands. It calls the UnequipAllToInventory method on the player's Hands, which is responsible for moving all equipped items back to the inventory. After unequipping, it sets the LastMessage property of the context to inform the player that all items have been unequipped.
        {
            context.Player.Hands.UnequipAllToInventory();
            context.LastMessage = "Unequipped all.";
        }
    }
}
