using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items.Currency;
using RpgGame.Core.Items.Junk;
using RpgGame.Core.Items.Weapons;
using RpgGame.Core.Items.Decorators;

namespace RpgGame.Core.World
{
    public static class WorldFactory    // WorldFactory class to create different stages of the world
    {
        public static World CreateStage1Room()  // Method to create the first stage of the world
        {
            var w = new World();

            // Set internal walls
            for (int c = 5; c < 30; c++)
            {
                w.SetWall(new Pos(8, c));
            }

            for (int r = 3; r < 15; r++)
            {
                w.SetWall(new Pos(r, 20));
            }

            // A coin to test pickup
            w.Cell(new Pos(2, 2)).Items.Add(new Coin());
            w.Cell(new Pos(4, 10)).Items.Add(new Gold());

            w.Cell(new Pos(1, 5)).Items.Add(new Rock());
            w.Cell(new Pos(3, 3)).Items.Add(new OldBoot());
            w.Cell(new Pos(6, 7)).Items.Add(new BrokenAmulet());

            w.Cell(new Pos(2, 6)).Items.Add(new Dagger());
            w.Cell(new Pos(5, 5)).Items.Add(new Sword());
            w.Cell(new Pos(7, 2)).Items.Add(new GreatAxe());

            w.Cell(new Pos(9, 9)).Items.Add(new SharpModifier(new Items.Weapons.Sword()));
            w.Cell(new Pos(10, 9)).Items.Add(new HeavyModifier(new Items.Weapons.Dagger()));
            w.Cell(new Pos(11, 9)).Items.Add(new SharpModifier(new Items.Weapons.GreatAxe()));

            return w;
        }
    }
}
