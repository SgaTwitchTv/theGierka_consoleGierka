using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public sealed class Dagger : Weapon
    {
        public Dagger() : base("Dagger", 'd', damage: 3, handRequirement: new OneHandRequirement()) { }
    }
}
