namespace RpgGame.Core.Items.Junk
{
    public sealed class OldBook : UnusableItem
    {
        public OldBook() : base("Old Book", 'B')
        {
        }

        public override string GetDescription() => "A dusty book filled with notes in the margins.";
    }
}
