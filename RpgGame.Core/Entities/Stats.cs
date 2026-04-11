using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Entities
{
    public sealed class Stats   // The stats class
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Health { get; private set; }
        public int Luck { get; private set; }
        public int Aggression { get; private set; }
        public int Wisdom { get; private set; }

        public Stats(int strength, int dexterity, int health, int luck, int aggression, int wisdom)
        {
            Strength = strength;
            Dexterity = dexterity;
            Health = health;
            Luck = luck;
            Aggression = aggression;
            Wisdom = wisdom;
        }

        // Helper methods to modify stats, ensuring that they don't drop below zero
        public void ModifyStrength(int delta) => Strength += delta;
        public void ModifyDexterity(int delta) => Dexterity += delta;
        public void ModifyHealth(int delta) => Health += delta;
        public void ModifyLuck(int delta) => Luck += delta;
        public void ModifyAggression(int delta) => Aggression += delta;
        public void ModifyWisdom(int delta) => Wisdom += delta;
        public void ReduceHealth(int amount) => Health = Math.Max(0, Health - amount);
    }
}
