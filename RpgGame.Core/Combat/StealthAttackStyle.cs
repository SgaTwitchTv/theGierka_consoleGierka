using RpgGame.Core.Entities;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Combat
{
    public sealed class StealthAttackStyle : IAttackStyle   // This attack style emphasizes stealth and precision, relying on the character's dexterity and luck to enhance light attacks while minimizing the effectiveness of heavy and magical attacks. It provides a unique combat experience for characters who prefer a more agile and cunning approach to combat.
    {
        public string Name => "Stealth";

        public int GetHeavyAttack(IWeapon weapon, Stats stats) => Math.Max(1, (weapon.Damage + stats.Strength + stats.Aggression) / 2);
        public int GetLightAttack(IWeapon weapon, Stats stats) => (weapon.Damage + stats.Dexterity + stats.Luck) * 2;
        public int GetMagicalAttack(IWeapon weapon, Stats stats) => 1;
        public int GetHeavyDefense(IWeapon weapon, Stats stats) => weapon.Defense + stats.Strength;
        public int GetLightDefense(IWeapon weapon, Stats stats) => weapon.Defense + stats.Dexterity;
        public int GetMagicalDefense(IWeapon weapon, Stats stats) => weapon.Defense;
        public int GetHeldItemAttack(IItem item, Stats stats) => 0;
        public int GetHeldItemDefense(IItem item, Stats stats) => 0;
        public int GetFallbackAttack(Stats stats) => 0;
        public int GetFallbackDefense(Stats stats) => 0;
    }
}
