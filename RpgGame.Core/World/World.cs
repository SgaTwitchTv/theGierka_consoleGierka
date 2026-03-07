using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.World
{
    public sealed class World   // The map class
    {
        public const int Rows = 20;
        public const int Cols = 40;

        private readonly GridCell[,] _cells = new GridCell[Rows, Cols];

        public World()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    _cells[r, c] = new GridCell();  // Build the map with empty cells
                }
            }
        }

        public bool IsInBounds(Pos p) => p.Row >= 0 && p.Row < Rows && p.Col >= 0 && p.Col < Cols;  // Check if the position is within the map bounds

        public GridCell Cell(Pos p) => _cells[p.Row, p.Col];    // Get the cell at the given position

        public bool CanEnter(Pos p) => IsInBounds(p) && !Cell(p).IsWall;    // Check if the player can enter the cell

        public void SetWall(Pos p)  // Set a wall at the given position
        {
            if (IsInBounds(p))
            {
                Cell(p).SetWall(true);
            }
        }
    }
}
