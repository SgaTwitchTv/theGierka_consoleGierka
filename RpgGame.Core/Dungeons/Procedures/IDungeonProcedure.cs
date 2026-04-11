using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Dungeons;

namespace RpgGame.Core.Dungeons.Procedures
{
    // DESIGN PATTERN: Strategy/Command - each procedure encapsulates a modification step applied to the build context.
    public interface IDungeonProcedure    // Interface for dungeon procedures, which are steps in the dungeon generation process
    {
        string Name { get; }
        IEnumerable<string> GetInstructions();
        void Apply(DungeonBuildContext context);    // Apply the procedure to the given dungeon build context, modifying the dungeon world in some way
    }
}
