using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Dungeons.Procedures;

namespace RpgGame.Core.Dungeons.Strategies
{
    public sealed class RoomsAndPathsNoItemsStrategy : IDungeonStrategy //  Inherited from the IDungeonStrategy interface enables to generate a dungeon with no items
    {
        public string Name => "Rooms and paths only";

        public IEnumerable<IDungeonProcedure> CreateProcedures()
        {
            yield return new FilledDungeonProcedure();
            yield return new CentralRoomProcedure(7, 11);
            yield return new RandomPathsProcedure(10, 10);
            yield return new RandomChambersProcedure(8, 3, 6);
        }

        public IEnumerable<string> GetInstructions()
        {
            yield return "Use W, A, S, D to move.";
            yield return "This dungeon contains no generated items.";
        }
    }
}
