using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RpgGame.Console.Input.Actions
{
    public sealed class EquipRightAction : IGameAction  // This class represents an action that allows the player to equip the currently selected item from their inventory into their right hand. It implements the IGameAction interface, which requires defining a HelpText property, a Matches method to determine if the action should be executed based on user input, and an Execute method that performs the action when triggered.
    {
        public string HelpText => "R - equip selected item in right hand";
        public string HelpGroup => "Inventory";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.R;
        public bool IsAvailable(GameContext context)
        {
            var items = context.Player.Inventory.Items;
            int selectedIndex = context.SelectedInventoryIndex;

            if (items.Count == 0 || selectedIndex < 0 || selectedIndex >= items.Count)
            {
                return false;
            }

            return items[selectedIndex].GetInventoryActions(context.Player).Any(a => a.Label == "Equip Right");
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
                context.SelectedInventoryIndex = items.Count - 1;

            var item = items[context.SelectedInventoryIndex];
            var action = item.GetInventoryActions(context.Player).FirstOrDefault(a => a.Label == "Equip Right");

            if (action == null)
            {
                context.LastMessage = "Selected item cannot be equipped in right hand.";
                return;
            }

            if (context.Player.Inventory.TryRemoveAt(context.SelectedInventoryIndex, out var removed) && removed != null)
            {
                action.Execute();
                context.LastMessage = $"Equipped right: {removed.Name}";
                RpgGame.Core.Logging.GameLog.Write(context.LastMessage);

                if (context.SelectedInventoryIndex >= context.Player.Inventory.Items.Count)
                {
                    context.SelectedInventoryIndex = Math.Max(0, context.Player.Inventory.Items.Count - 1);
                }
            }
        }
    }
}
