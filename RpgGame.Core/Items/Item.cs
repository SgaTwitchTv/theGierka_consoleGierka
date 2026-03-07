using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;

namespace RpgGame.Core.Items
{
    public abstract class Item  // Base class for all items in the game
    {
        public string Name { get; }
        public char Symbol { get; }

        protected Item(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public abstract string GetDescription();    // Each item will provide its own description.
        public virtual bool GoesToInventory => true;
        // For stage 1 we use this for currency auto-collect
        public virtual void OnPickUp(Player player) { }
        public virtual IEnumerable<IInventoryAction> GetInventoryActions(Player player)
        {
            yield break;
        }
    }
}
