using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Inventory.Actions
{
    public interface IInventoryAction   // Inventory action interface
    {
        string Label { get; }
        void Execute();
    }
}
