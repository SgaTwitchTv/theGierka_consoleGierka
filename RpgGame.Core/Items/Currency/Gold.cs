using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;

namespace RpgGame.Core.Items.Currency
{
    public sealed class Gold : Currency // Class that represents a gold piece in the game
    {
        public Gold() : base("Gold", 'g') { }

        public override string GetDescription() => "A gold piece."; // Analogously to the coin
        protected override void Collect(Player player) => player.Wallet.AddGold(1);
    }
}
