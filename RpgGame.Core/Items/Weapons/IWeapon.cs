using RpgGame.Core.Combat;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons
{
    public interface IWeapon : Items.IItem  // The IWeapon interface extends the IItem interface and includes properties specific to weapons, such as damage, defense, category, and hand requirements.
    {
        int Damage { get; }
        int Defense { get; }
        IWeaponCategory Category { get; }
        IHandRequirement HandRequirement { get; }
    }
}
