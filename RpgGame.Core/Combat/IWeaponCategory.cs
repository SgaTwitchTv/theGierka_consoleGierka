using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public interface IWeaponCategory    // Interface that defines the structure for different weapon categories in the game. It includes a property for the display name of the category and methods to calculate attack damage and defense values based on the equipped weapon, the player's stats, and the attack style. Each weapon category will implement this interface to provide specific calculations for their respective attack and defense values.
    {
        string DisplayName { get; }
        int GetAttackDamage(IWeapon weapon, Stats stats, IAttackStyle attackStyle); // Method to calculate the attack damage based on the equipped weapon, player's stats, and attack style.
        int GetDefenseValue(IWeapon weapon, Stats stats, IAttackStyle attackStyle); // Method to calculate the defense value based on the equipped weapon, player's stats, and attack style.
    }
}
