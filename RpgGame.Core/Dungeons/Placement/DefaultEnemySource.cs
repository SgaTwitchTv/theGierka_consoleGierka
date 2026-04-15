using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class DefaultEnemySource : IEnemySource   // DefaultEnemySource class implements the IEnemySource interface, which means it must provide an implementation for the Next method that returns an Enemy based on a random input and a position.
    {
        public Enemy Next(Random random, Pos position)  // The Next method takes a Random object and a Pos object as parameters and returns an Enemy object. The Enemy is created with specific attributes such as name, symbol, health, attack, and armor.
        {
            return new Enemy("Goblin", '!', position, health: 12, attack: 6, armor: 2);
        }
    }
}
