using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Weapons;
using RpgGame.Core.Items.Decorators;
using RpgGame.Core.Items.Modifiers;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class RandomWeaponSource : IRandomWeaponSource    // This class generates random weapons with possible modifiers for placement in the dungeon.
    {
        public IItem Next(Random random) // This method generates a random weapon, potentially with a modifier, based on random rolls.
        {
            int baseRoll = random.Next(4);
            IWeapon baseWeapon = baseRoll switch
            {
                0 => new Dagger(),
                1 => new Sword(),
                2 => new GreatAxe(),
                3 => new Wand(),
                _ => new Dagger(),
            };

            IWeapon modifiedWeapon = baseWeapon;

            if (random.Next(4) == 1)
            {
                modifiedWeapon = new SharpModifier(modifiedWeapon);
            }

            if (random.Next(4) == 1)
            {
                modifiedWeapon = new HeavyModifier(modifiedWeapon);
            }

            if (random.Next(3) == 1)
            {
                modifiedWeapon = new StrongWeaponModifier(modifiedWeapon);
            }

            if (random.Next(3) == 1)
            {
                modifiedWeapon = new UnluckyWeaponModifier(modifiedWeapon);
            }

            return modifiedWeapon;
        }
    }
}
