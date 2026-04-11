namespace RpgGame.Core.Items.Modifiers
{
    public sealed class UnluckyWeaponModifier : Decorators.WeaponDecorator  // A weapon modifier that decreases the player's luck stat by a flat amount, representing an "unlucky" curse that brings misfortune to the player when they have this weapon equipped or in their inventory. It does not change the damage of the weapon, but it applies a negative luck modifier to the player when they have this weapon.
    {
        public UnluckyWeaponModifier(Weapons.IWeapon inner) : base(inner, modifierName: "Unlucky", damageBonus: 0)
        {
        }

        public override PlayerStatModifier GetStatModifier() => Inner.GetStatModifier().Combine(new PlayerStatModifier(0, 0, 0, -5, 0, 0));

        public override string GetDescription() => $"{Name} (DMG {Damage}) - It gives off a cursed feeling.";
    }
}
