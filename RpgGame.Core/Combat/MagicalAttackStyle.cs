using RpgGame.Core.Entities;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class MagicalAttackStyle : IAttackStyle   // This attack style focuses on magical attacks, using the character's wisdom to enhance damage and defense.
    {
        public string Name => "Magical";

        public int GetHeavyAttack(IWeapon weapon, Stats stats) => 1;
        public int GetLightAttack(IWeapon weapon, Stats stats) => 1;
        public int GetMagicalAttack(IWeapon weapon, Stats stats) => weapon.Damage + stats.Wisdom;
        public int GetHeavyDefense(IWeapon weapon, Stats stats) => weapon.Defense + stats.Luck;
        public int GetLightDefense(IWeapon weapon, Stats stats) => weapon.Defense + stats.Luck;
        public int GetMagicalDefense(IWeapon weapon, Stats stats) => weapon.Defense + (stats.Wisdom * 2);
        public int GetHeldItemAttack(IItem item, Stats stats) => 0;
        public int GetHeldItemDefense(IItem item, Stats stats) => stats.Luck;
        public int GetFallbackAttack(Stats stats) => 0;
        public int GetFallbackDefense(Stats stats) => stats.Luck;
    }
}
