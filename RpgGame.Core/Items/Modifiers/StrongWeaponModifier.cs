namespace RpgGame.Core.Items.Modifiers
{
    public sealed class StrongWeaponModifier : Decorators.WeaponDecorator   // A weapon modifier that increases the damage of the weapon by a flat amount, representing a "strong" enchantment that empowers the weapon with extra force.
    {
        public StrongWeaponModifier(Weapons.IWeapon inner): base(inner, modifierName: "Strong", damageBonus: 5)
        {
        }

        public override string GetDescription() => $"{Name} (DMG {Damage}) - Empowered with extra force.";
    }
}
