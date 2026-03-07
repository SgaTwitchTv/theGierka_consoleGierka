using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Items.Junk
{
    public sealed class OldBoot : UnusableItem
    {
        public OldBoot() : base("Old Boot", 'b') { }
        public override string GetDescription() => "A smelly old boot.";
    }
}
