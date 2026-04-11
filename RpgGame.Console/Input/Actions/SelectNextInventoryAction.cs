using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class SelectNextInventoryAction : IGameAction // An action that allows the player to cycle through their inventory items by pressing the Down Arrow key.
    {
        public string HelpText => "Down - select next inventory item";
        public string HelpGroup => "Inventory";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.DownArrow;
        public bool IsAvailable(GameContext context) => context.Player.Inventory.Items.Count > 0;

        public void Execute(GameContext context)
        {
            int count = context.Player.Inventory.Items.Count;
            if (count == 0)
            {
                context.SelectedInventoryIndex = 0;
                context.LastMessage = "Inventory empty.";
                return;
            }

            context.SelectedInventoryIndex = Math.Min(count - 1, context.SelectedInventoryIndex + 1);
            context.LastMessage = $"Selected inventory item: {context.SelectedInventoryIndex}";
        }
    }
}
