using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Items.Decorators
{
    public sealed class SharpModifier : WeaponDecorator // A weapon modifier that increases damage and adds a description about the weapon being sharpened to a razor finish.
    {
        public SharpModifier(Items.Weapons.Weapon inner) : base(inner, namePrefix: "Sharp", damageBonus: 2) { } // This constructor takes an existing weapon and creates a new "Sharp" version of it with increased damage.

        public override string GetDescription() => $"{Name} (DMG {Damage}) - Edge honed to a razor finish."; // This method provides a description of the weapon, including its name, damage, and a note about it being sharpened.
    }
}
