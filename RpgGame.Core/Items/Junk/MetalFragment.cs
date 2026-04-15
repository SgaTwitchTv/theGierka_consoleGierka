namespace RpgGame.Core.Items.Junk
{
    public sealed class MetalFragment : UnusableItem    // This item is considered "junk" and cannot be used by the player.
    {
        public MetalFragment() : base("Metal Fragment", 'm')    // The constructor initializes the item with a name and a character symbol for display purposes.
        {
        }

        public override string GetDescription() => "A cold fragment of polished metal.";    // This method provides a description of the item when the player examines it.
    }
}
