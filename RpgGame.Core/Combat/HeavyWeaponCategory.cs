using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class HeavyWeaponCategory : IWeaponCategory   // Implements the IWeaponCategory interface to define the behavior of heavy weapons in combat. It provides specific implementations for calculating attack damage and defense values based on the heavy attack style.
    {
        public string DisplayName => "Heavy";

        public int GetAttackDamage(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetHeavyAttack(weapon, stats);

        public int GetDefenseValue(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetHeavyDefense(weapon, stats);
    }
}
