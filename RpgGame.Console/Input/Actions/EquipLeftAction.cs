using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RpgGame.Console.Input.Actions
{
    public sealed class EquipLeftAction : IGameAction   // This class represents an action that allows the player to equip the currently selected item from their inventory into their left hand. It implements the IGameAction interface, which requires defining a HelpText property, a Matches method to determine if the action should be executed based on user input, and an Execute method that performs the action when triggered.
    {
        public string HelpText => "L - equip selected item in left hand";
        public string HelpGroup => "Inventory";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.L;
        public bool IsAvailable(GameContext context)
        {
            var items = context.Player.Inventory.Items;
            int selectedIndex = context.SelectedInventoryIndex;

            if (items.Count == 0 || selectedIndex < 0 || selectedIndex >= items.Count)
            {
                return false;
            }

            return items[selectedIndex].GetInventoryActions(context.Player).Any(a => a.Label == "Equip Left");
        }

        public void Execute(GameContext context)
        {
            var items = context.Player.Inventory.Items;

            if (items.Count == 0)
            {
                context.LastMessage = "Inventory empty.";
                return;
            }

            if (context.SelectedInventoryIndex >= items.Count)
            {
                context.SelectedInventoryIndex = items.Count - 1;
            }

            var item = items[context.SelectedInventoryIndex];
            var action = item.GetInventoryActions(context.Player)
                             .FirstOrDefault(a => a.Label == "Equip Left");

            if (action == null)
            {
                context.LastMessage = "Selected item cannot be equipped in left hand.";
                return;
            }

            if (context.Player.Inventory.TryRemoveAt(context.SelectedInventoryIndex, out var removed) && removed != null)
            {
                action.Execute();
                context.LastMessage = $"Equipped left: {removed.Name}";

                if (context.SelectedInventoryIndex >= context.Player.Inventory.Items.Count)
                {
                    context.SelectedInventoryIndex = Math.Max(0, context.Player.Inventory.Items.Count - 1);
                }
            }
        }
    }
}
