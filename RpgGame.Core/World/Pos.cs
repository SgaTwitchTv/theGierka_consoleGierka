using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.World
{
    public readonly record struct Pos(int Row, int Col) // Position class
    {
        // Position change function
        public Pos Move(int dRow, int dCol) => new(Row + dRow, Col + dCol);
    }
}
