using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Combat;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public sealed class Sword : Weapon
    {
        public Sword() : base("Sword", 's', damage: 5, defense: 2, category: new HeavyWeaponCategory(), handRequirement: new OneHandRequirement()) { }
    }
}
