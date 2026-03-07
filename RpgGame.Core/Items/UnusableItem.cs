using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Items
{
    public abstract class UnusableItem : Item
    {
        protected UnusableItem(string name, char symbol) : base(name, symbol) { }
    }
}
