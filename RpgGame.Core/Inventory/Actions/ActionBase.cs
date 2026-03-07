using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Inventory.Actions
{
    public abstract class InventoryActionBase : IInventoryAction    // Inventory action clas
    {
        public string Label { get; }

        protected InventoryActionBase(string label) => Label = label;

        public abstract void Execute(); // Execute method
    }
}
