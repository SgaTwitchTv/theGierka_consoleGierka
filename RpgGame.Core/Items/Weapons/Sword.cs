using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public sealed class Sword : Weapon
    {
        public Sword() : base("Sword", 's', damage: 5, handRequirement: new OneHandRequirement()) { }
    }
}
