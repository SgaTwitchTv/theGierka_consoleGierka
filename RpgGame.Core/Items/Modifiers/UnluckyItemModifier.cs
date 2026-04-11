namespace RpgGame.Core.Items.Modifiers
{
    public sealed class UnluckyItemModifier : ItemModifier  // An item modifier that decreases the player's luck stat by a flat amount, representing an "unlucky" curse that brings misfortune to the player when they have this item equipped or in their inventory.
    {
        public UnluckyItemModifier(IItem inner) : base(inner, "Unlucky")
        {
        }

        public override PlayerStatModifier GetStatModifier() => Inner.GetStatModifier().Combine(new PlayerStatModifier(0, 0, 0, -5, 0, 0));

        public override string GetDescription() => $"{Name} - It gives off a cursed feeling.";
    }
}
