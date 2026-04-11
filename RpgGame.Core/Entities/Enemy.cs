using RpgGame.Core.World;

namespace RpgGame.Core.Entities
{
    public sealed class Enemy   // Enemy class implementation
    {
        public string Name { get; }
        public char Symbol { get; }
        public Pos Position { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; }
        public int Armor { get; }
        public bool IsAlive => Health > 0;

        public Enemy(string name, char symbol, Pos position, int health, int attack, int armor)
        {
            Name = name;
            Symbol = symbol;
            Position = position;
            Health = health;
            Attack = attack;
            Armor = armor;
        }

        public void SetPosition(Pos position)
        {
            Position = position;
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }
    }
}
