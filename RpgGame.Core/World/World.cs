using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.World
{
    public sealed class World   // The map class
    {
        public int Rows { get; }
        public int Cols { get; }

        private readonly GridCell[,] _cells;

        public World(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            _cells  = new GridCell[rows, cols];

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

        public void SetFloor(Pos p) // Set a floor at the given position
        {
            if(IsInBounds(p))
            {
                Cell(p).SetWall(false);
            }
        }

        public Pos FindFirstFloor() // Find the first floor cell in the map and return its position to spawn the player there
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    var pos = new Pos(r, c);
                    if (CanEnter(pos))
                    {
                        return pos;
                    }
                }
            }

            return new Pos(0, 0);
        }
    }
}
