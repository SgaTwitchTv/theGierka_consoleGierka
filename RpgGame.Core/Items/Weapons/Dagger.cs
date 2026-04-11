using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Combat;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public sealed class Dagger : Weapon
    {
        public Dagger() : base("Dagger", 'd', damage: 3, defense: 1, category: new LightWeaponCategory(), handRequirement: new OneHandRequirement()) { }
    }
}
