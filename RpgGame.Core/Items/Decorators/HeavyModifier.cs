using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Items.Decorators
{
    public sealed class HeavyModifier : WeaponDecorator // A weapon modifier that increases damage but may reduce speed.
    {
        public HeavyModifier(Items.Weapons.IWeapon inner) : base(inner, modifierName: "Weighted", damageBonus: 3) { } // Adds a non-category modifier label and +3 damage.

        public override string GetDescription() => $"{Name} (DMG {Damage}) - Hits harder, feels slower.";   // Custom description for the weighted modifier.
    }
}
