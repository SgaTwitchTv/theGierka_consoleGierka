using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class LightWeaponCategory : IWeaponCategory
    {
        public string DisplayName => "Light";

        public int GetAttackDamage(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetLightAttack(weapon, stats);

        public int GetDefenseValue(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetLightDefense(weapon, stats);
    }
}
