using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Dungeons.Placement;
using RpgGame.Core.Dungeons.Procedures;

namespace RpgGame.Core.Dungeons.Strategies
{
    public sealed class DungeonGroundsStrategy : IDungeonStrategy   // A dungeon strategy that creates a dungeon with a filled layout, a central room, random paths, random chambers, and random items and weapons. The strategy combines multiple procedures to create a diverse and interesting dungeon layout with various features and challenges for the player to explore.
    {
        public string Name => "Dungeon grounds";

        public IEnumerable<IDungeonProcedure> CreateProcedures()    // CreateProcedure function that yields a sequence of dungeon procedures to build the dungeon layout and populate it with items and weapons. The procedures include filling the dungeon, creating a central room, generating random paths and chambers, and placing random items and weapons using specified item sources. Each procedure contributes to different aspects of the dungeon design, resulting in a varied and engaging environment for players to explore. 
        {
            yield return new FilledDungeonProcedure();
            yield return new CentralRoomProcedure(7, 11);
            yield return new RandomPathsProcedure(12, 10);
            yield return new RandomChambersProcedure(6, 3, 6);
            yield return new RandomItemsProcedure(8, new RandomJunkItemSource());
            yield return new RandomWeaponsProcedure(5, new RandomWeaponSource());
        }

        public IEnumerable<string> GetInstructions()    // GetInstructions function that aggregates instructions from all the procedures created by the CreateProcedures function. It iterates through each procedure and checks if it implements the IInstructionContributor interface. If it does, it retrieves the instructions from that procedure and yields them as part of the overall instructions for the dungeon strategy. This allows for a modular approach where each procedure can contribute its own set of instructions, resulting in a comprehensive guide for players on how to navigate and interact with the dungeon.
        {
            foreach (var procedure in CreateProcedures())
            {
                if (procedure is RpgGame.Core.Dungeons.IInstructionContributor contributor)
                {
                    foreach (var instruction in contributor.GetInstructions())
                    {
                        yield return instruction;
                    }
                }
            }
        }
    }
}
