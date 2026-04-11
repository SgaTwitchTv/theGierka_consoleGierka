using RpgGame.Core.Entities;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class NormalAttackStyle : IAttackStyle    // This attack style represents a balanced approach to combat, utilizing both physical and magical attributes without any specialization. It provides a straightforward calculation for attacks and defenses based on the character's stats and weapon attributes.
    {
        public string Name => "Normal";

        public int GetHeavyAttack(IWeapon weapon, Stats stats) => weapon.Damage + stats.Strength + stats.Aggression;
        public int GetLightAttack(IWeapon weapon, Stats stats) => weapon.Damage + stats.Dexterity + stats.Luck;
        public int GetMagicalAttack(IWeapon weapon, Stats stats) => 1;
        public int GetHeavyDefense(IWeapon weapon, Stats stats) => weapon.Defense + stats.Strength + stats.Luck;
        public int GetLightDefense(IWeapon weapon, Stats stats) => weapon.Defense + stats.Dexterity + stats.Luck;
        public int GetMagicalDefense(IWeapon weapon, Stats stats) => weapon.Defense + stats.Dexterity + stats.Luck;
        public int GetHeldItemAttack(IItem item, Stats stats) => 0;
        public int GetHeldItemDefense(IItem item, Stats stats) => stats.Dexterity;
        public int GetFallbackAttack(Stats stats) => 0;
        public int GetFallbackDefense(Stats stats) => stats.Dexterity;
    }
}
