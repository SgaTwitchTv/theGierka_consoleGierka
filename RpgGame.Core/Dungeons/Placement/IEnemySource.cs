using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Placement
{
    public interface IEnemySource   // An interface for a source of random enemies that can be used to place enemies in the dungeon. The Next method takes a Random object and a Pos object as parameters and returns an Enemy, allowing for different implementations of random enemy generation based on the provided random number generator and position.
    {
        Enemy Next(Random random, Pos position);
    }
}
