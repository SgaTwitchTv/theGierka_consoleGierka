using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;

namespace RpgGame.Core.Dungeons.Placement
{
    public interface IRandomItemSource  // An interface for a source of random items that can be used to place items in the dungeon. The Next method takes a Random object as a parameter and returns an Item, allowing for different implementations of random item generation based on the provided random number generator.
    {
        IItem Next(Random random);  // Metod Next takes a Random object as a parameter and returns an IItem, allowing for different implementations of random item generation based on the provided random number generator.
    }
}
