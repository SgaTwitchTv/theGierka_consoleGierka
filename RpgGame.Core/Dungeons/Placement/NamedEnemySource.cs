using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Placement
{
    public sealed class NamedEnemySource : IEnemySource // An enemy source that generates enemies with random names from a provided list.
    {
        private readonly string[] _names;
        private readonly char _symbol;
        private readonly int _health;
        private readonly int _attack;
        private readonly int _armor;

        public NamedEnemySource(string[] names, char symbol, int health, int attack, int armor)
        {
            _names = names;
            _symbol = symbol;
            _health = health;
            _attack = attack;
            _armor = armor;
        }

        public Enemy Next(Random random, Pos position)  // The Next method generates a new Enemy with a random name from the provided list, using the specified symbol, health, attack, and armor values.
        {
            string name = _names[random.Next(_names.Length)];                        // Select a random name from the list of names using the provided Random object.
            return new Enemy(name, _symbol, position, _health, _attack, _armor);    // Create and return a new Enemy instance with the selected name, symbol, position, health, attack, and armor values.
        }
    }
}
