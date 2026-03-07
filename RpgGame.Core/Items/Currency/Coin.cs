using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;

namespace RpgGame.Core.Items.Currency
{
    public sealed class Coin : Currency // Inherited from Currency class
    {
        public Coin() : base("Coin", 'c') { }

        public override string GetDescription() => "A small coin."; // Description of the coin
        protected override void Collect(Player player) => player.Wallet.AddCoins(1);    // When collected, add 1 coin to the player's wallet
    }
}
