using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input.Actions
{
    public sealed class SelectPrevInventoryAction : IGameAction // This action allows the player to select the previous item in their inventory.
    {
        public string HelpText => "Up - select previous inventory item";
        public string HelpGroup => "Inventory";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.UpArrow;
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

            context.SelectedInventoryIndex = Math.Max(0, context.SelectedInventoryIndex - 1);
            context.LastMessage = $"Selected inventory item: {context.SelectedInventoryIndex}";
        }
    }
}
