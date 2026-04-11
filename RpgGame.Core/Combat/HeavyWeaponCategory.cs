using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class HeavyWeaponCategory : IWeaponCategory
    {
        public string DisplayName => "Heavy";

        public int GetAttackDamage(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetHeavyAttack(weapon, stats);

        public int GetDefenseValue(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetHeavyDefense(weapon, stats);
    }
}
