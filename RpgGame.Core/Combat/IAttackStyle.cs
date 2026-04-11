using RpgGame.Core.Entities;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public interface IAttackStyle   // An interface that defines the structure for different attack styles in the game. It includes properties and methods to calculate attack and defense values based on the equipped weapon and the player's stats. Each attack style will implement this interface to provide specific calculations for heavy, light, and magical attacks and defenses, as well as fallback values when no weapon is equipped.
    {
        string Name { get; }
        int GetHeavyAttack(IWeapon weapon, Stats stats);
        int GetLightAttack(IWeapon weapon, Stats stats);
        int GetMagicalAttack(IWeapon weapon, Stats stats);
        int GetHeavyDefense(IWeapon weapon, Stats stats);
        int GetLightDefense(IWeapon weapon, Stats stats);
        int GetMagicalDefense(IWeapon weapon, Stats stats);
        int GetHeldItemAttack(IItem item, Stats stats);
        int GetHeldItemDefense(IItem item, Stats stats);
        int GetFallbackAttack(Stats stats);
        int GetFallbackDefense(Stats stats);
    }
}
