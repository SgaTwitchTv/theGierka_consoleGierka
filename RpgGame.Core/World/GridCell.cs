using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.Items;

namespace RpgGame.Core.World
{
    public sealed class GridCell // Each map cell class
    {
        public bool IsWall { get; private set; }    // Flag - if the cell is a wall
        public List<IItem> Items { get; } = new();   // Items laying in the cell
        public Enemy? Enemy { get; set; }

        public GridCell(bool isWall = false) => IsWall = isWall;

        public void SetWall(bool isWall) => IsWall = isWall;    // Set wall flag

        public char GetSymbol() // Get the symbol to display for this cell
        {
            if (Enemy != null)
            {
                return Enemy.Symbol;
            }

            if (Items.Count > 0)
            {
                return Items[^1].Symbol; // Top item
            }

            return IsWall ? '█' : ' ';
        }
    }
}
