using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Inventory.Actions
{
    public interface IInventoryAction
    {
        string Label { get; }
        void Execute();
    }
}
