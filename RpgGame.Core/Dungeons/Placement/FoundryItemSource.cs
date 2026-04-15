using RpgGame.Core.Items;
using RpgGame.Core.Items.Junk;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class FoundryItemSource : IRandomItemSource   // FoundryItemSource class implements the IRandomItemSource interface, which means it must provide an implementation for the Next method that returns an IItem based on a random input.
    {
        public IItem Next(Random random)
        {
            return random.Next(3) switch
            {
                0 => new MetalFragment(),
                1 => new Rock(),
                _ => new MetalFragment()
            };
        }
    }
}
