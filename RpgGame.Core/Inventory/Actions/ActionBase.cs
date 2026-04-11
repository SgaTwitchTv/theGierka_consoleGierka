using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Inventory.Actions
{
    public abstract class InventoryActionBase : IInventoryAction    // Inventory action class
    {
        public string Label { get; }

        protected InventoryActionBase(string label) => Label = label;

        public abstract void Execute(); // Execute method to be implemented by derived classes and called when the action is performed
    }
}
