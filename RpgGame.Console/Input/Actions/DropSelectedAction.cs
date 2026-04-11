using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class DropSelectedAction : IGameAction    // This class represents an action that allows the player to drop the currently selected item from their inventory. It implements the IGameAction interface, which requires defining a HelpText property, a Matches method to determine if the action should be executed based on user input, and an Execute method that performs the action when triggered.
    {
        public string HelpText => "Backspace - drop selected inventory item";
        public string HelpGroup => "Inventory";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.Backspace; // The Matches method checks if the user has pressed the Backspace key, which is the trigger for dropping the selected inventory item.
        public bool IsAvailable(GameContext context) => context.Player.Inventory.Items.Count > 0;

        public void Execute(GameContext context)    // The Execute method performs the action of dropping the selected inventory item. It first checks if the player's inventory is empty and sets a message if it is. If there are items in the inventory, it ensures that the selected inventory index is within bounds. Then, it attempts to drop the item at the selected index from the player's inventory into the world. If successful, it updates the last message with the result and adjusts the selected inventory index if necessary. If the drop action fails, it sets the last message to indicate the failure reason.
        {
            if (context.Player.Inventory.Items.Count == 0)
            {
                context.LastMessage = "Inventory empty.";
                return;
            }

            if (context.SelectedInventoryIndex >= context.Player.Inventory.Items.Count)
            {
                context.SelectedInventoryIndex = context.Player.Inventory.Items.Count - 1;
            }

            if (context.Player.TryDropFromInventory(context.World, context.SelectedInventoryIndex, out var message))    // The TryDropFromInventory method is called to attempt to drop the item at the selected index. It returns a boolean indicating success and an output message describing the result of the action.
            {
                context.LastMessage = message;

                if (context.SelectedInventoryIndex >= context.Player.Inventory.Items.Count)
                {
                    context.SelectedInventoryIndex = Math.Max(0, context.Player.Inventory.Items.Count - 1);
                }
            }
            else
            {
                context.LastMessage = message;
            }
        }
    }
}
