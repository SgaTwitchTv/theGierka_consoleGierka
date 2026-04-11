using RpgGame.Core.Combat;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public interface IWeapon : Items.IItem
    {
        int Damage { get; }
        int Defense { get; }
        IWeaponCategory Category { get; }
        IHandRequirement HandRequirement { get; }
    }
}
