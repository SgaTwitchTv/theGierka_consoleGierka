using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;

namespace RpgGame.Core.Items
{
    public abstract class Item : IItem  // Base class for all items in the game
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
        public virtual Modifiers.PlayerStatModifier GetStatModifier() => Modifiers.PlayerStatModifier.None; // A modifier that can be applied to the player when the item is equipped or used
        // For stage 1 we use this for currency auto-collect
        public virtual void OnPickUp(Player player) { }
        public virtual IEnumerable<IInventoryAction> GetInventoryActions(Player player)
        {
            yield break;
        }
    }
}
