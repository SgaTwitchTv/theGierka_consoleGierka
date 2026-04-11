using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class LightWeaponCategory : IWeaponCategory   // Implements the IWeaponCategory interface to define the behavior of light weapons in combat. It provides specific implementations for calculating attack damage and defense values based on the light attack style.
    {
        public string DisplayName => "Light";

        public int GetAttackDamage(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetLightAttack(weapon, stats);

        public int GetDefenseValue(IWeapon weapon, Stats stats, IAttackStyle attackStyle) => attackStyle.GetLightDefense(weapon, stats);
    }
}
