using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Entities
{
    public sealed class Wallet // Wallet class to manage player's coins and gold, trivial ig
    {
        public int Coins { get; private set; }
        public int Gold { get; private set; }
        
        public void AddCoins(int amount) => Coins += amount;
        public void AddGold(int amount) => Gold += amount;
    }
}
