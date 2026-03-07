using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Items.Junk
{
    public sealed class Rock : UnusableItem
    {
        public Rock() : base("Rock", 'r') { }
        public override string GetDescription() => "Just a rock. Not very useful.";
    }
}
