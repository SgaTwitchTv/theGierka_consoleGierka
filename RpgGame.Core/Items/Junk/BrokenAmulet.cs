using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Items.Junk
{
    public sealed class BrokenAmulet : UnusableItem
    {
        public BrokenAmulet() : base("Broken Amulet", 'a') { }
        public override string GetDescription() => "An amulet with a cracked gem.";
    }
}
