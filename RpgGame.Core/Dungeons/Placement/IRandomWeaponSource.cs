using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;

namespace RpgGame.Core.Dungeons.Placement
{
    public interface IRandomWeaponSource    // An interface for a source of random weapons that can be used to place weapons in the dungeon. The Next method takes a Random object as a parameter and returns an IItem, allowing for different implementations of random weapon generation based on the provided random number generator.
    {
        IItem Next(Random random); // ...analogous to IRandomItemSource, but specifically for generating weapons. This allows for different implementations of random weapon generation based on the provided random number generator.
    }
}
