using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items;

namespace RpgGame.Core.Dungeons.Placement
{
    public interface IRandomWeaponSource
    {
        IItem Next(Random random);
    }
}
