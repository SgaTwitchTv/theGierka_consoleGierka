using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;

namespace RpgGame.Core.Items.Currency
{
    public abstract class Currency : Item   // Inherited from the Item, Currency class
    {
        protected Currency(string name, char symbol) : base(name, symbol) { }

        public sealed override bool GoesToInventory => false;
        public sealed override void OnPickUp(Player player) => Collect(player); // If picked up by a player, it will call the Collect method...
        protected abstract void Collect(Player player);                        // ...abstratly predeclared here
    }
}
