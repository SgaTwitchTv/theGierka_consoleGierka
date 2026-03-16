using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Weapons;
using RpgGame.Core.Items.Decorators;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class RandomWeaponSource : IRandomWeaponSource    // This class generates random weapons with possible modifiers for placement in the dungeon.
    {
        public Item Next(Random random) // This method generates a random weapon, potentially with a modifier, based on random rolls.
        {
            int baseRoll = random.Next(3);
            Weapon baseWeapon = baseRoll switch
            {
                0 => new Dagger(),
                1 => new Sword(),
                _ => new GreatAxe(),
            };

            int modifierRoll = random.Next(4);

            return modifierRoll switch
            {
                0 => baseWeapon,
                1 => new SharpModifier(baseWeapon),
                2 => new HeavyModifier(baseWeapon),
                _ => baseWeapon
            };
        }
    }
}
