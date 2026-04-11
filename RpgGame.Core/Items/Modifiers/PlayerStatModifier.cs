namespace RpgGame.Core.Items.Modifiers
{
    public readonly record struct PlayerStatModifier(int Strength, int Dexterity, int Health, int Luck, int Aggression, int Wisdom) // A struct that represents a modification to the player's stats, which can be applied by items or other effects. Each field represents how much to modify the corresponding player stat when this modifier is applied.
    {
        public static PlayerStatModifier None => new(0, 0, 0, 0, 0, 0);

        public PlayerStatModifier Combine(PlayerStatModifier other) =>  //  Combine this modifier with another, summing their respective stats.
            new(
                Strength + other.Strength,
                Dexterity + other.Dexterity,
                Health + other.Health,
                Luck + other.Luck,
                Aggression + other.Aggression,
                Wisdom + other.Wisdom
            );
    }
}
