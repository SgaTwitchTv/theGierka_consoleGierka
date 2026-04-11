using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public interface IWeaponCategory
    {
        string DisplayName { get; }
        int GetAttackDamage(IWeapon weapon, Stats stats, IAttackStyle attackStyle);
        int GetDefenseValue(IWeapon weapon, Stats stats, IAttackStyle attackStyle);
    }
}
