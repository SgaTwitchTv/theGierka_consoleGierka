using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Dungeons
{
    public interface IInstructionContributor    // An interface for dungeon procedures that can contribute instructions to the player. Implementing this interface allows a dungeon procedure to provide specific instructions or guidance related to its functionality, which can be displayed to the player as part of the overall dungeon strategy.
    {
        IEnumerable<string> GetInstructions();  // A method that returns a collection of instructions as strings. These instructions can be used to inform the player about specific mechanics, interactions, or objectives related to the dungeon procedure that implements this interface.
    }
}
