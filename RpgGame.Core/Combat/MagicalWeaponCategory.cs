using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class MagicalWeaponCategory : IWeaponCategory // Implements the IWeaponCategory interface to define the behavior of magical weapons in combat. It provides specific implementations for calculating attack damage and defense values based on the magical attack style.
    {
        public string DisplayName => "Magical";

        public int GetAttackDamage(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetMagicalAttack(weapon, stats);

        public int GetDefenseValue(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetMagicalDefense(weapon, stats);
    }
}
