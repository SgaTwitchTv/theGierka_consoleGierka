using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public sealed class GreatAxe : Weapon
    {
        public GreatAxe() : base("Great Axe", 'G', damage: 9, handRequirement: new TwoHandRequirement()) { }
    }
}
