using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.World;

namespace RpgGame.Core.Dungeons.Procedures
{
    public sealed class EnsureConnectedDungeonProcedure : IDungeonProcedure
    {
        public string Name => "Ensure connected dungeon";

        public IEnumerable<string> GetInstructions()
        {
            yield break;
        }

        public void Apply(DungeonBuildContext context)  // Applies the procedure to ensure that all floor areas in the dungeon are connected. It does this by repeatedly finding connected components of floor tiles and carving corridors between them until only one connected component remains.
        {
            while (true)
            {
                var components = FindConnectedComponents(context.World);

                if (components.Count <= 1)
                {
                    return;
                }

                var first = components[0];
                var second = components[1];

                var start = first[0];
                var end = second[0];

                CarveCorridor(context.World, start, end);
            }
        }

        private static List<List<Pos>> FindConnectedComponents(World.World world)   // Finds all connected components of floor tiles in the world. It uses a depth-first search (DFS) algorithm to explore the world and group connected floor tiles together.
        {
            var visited = new bool[world.Rows, world.Cols];
            var components = new List<List<Pos>>();

            for (int r = 0; r < world.Rows; r++)
            {
                for (int c = 0; c < world.Cols; c++)
                {
                    var pos = new Pos(r, c);

                    if (!world.CanEnter(pos) || visited[r, c])
                    {
                        continue;
                    }

                    var component = new List<Pos>();
                    DFS(world, pos, visited, component);
                    components.Add(component);
                }
            }

            return components;
        }

        private static void DFS(World.World world, Pos start, bool[,] visited, List<Pos> component) // Performs a DFS starting from the given position to find all connected floor tiles. It marks visited tiles and adds them to the current component list.
        {
            var stack = new Stack<Pos>();
            stack.Push(start);

            while (stack.Count > 0) // Continues until there are no more positions to explore in the stack.
            {
                var current = stack.Pop();

                if (!world.IsInBounds(current))
                {
                    continue;
                }

                if (visited[current.Row, current.Col])
                {
                    continue;
                }

                if (!world.CanEnter(current))
                {
                    continue;
                }

                visited[current.Row, current.Col] = true;
                component.Add(current);

                stack.Push(new Pos(current.Row - 1, current.Col));
                stack.Push(new Pos(current.Row + 1, current.Col));
                stack.Push(new Pos(current.Row, current.Col - 1));
                stack.Push(new Pos(current.Row, current.Col + 1));
            }
        }

        private static void CarveCorridor(World.World world, Pos start, Pos end)    // Carves a corridor between two positions by setting floor tiles along a path from the start to the end. It first moves horizontally from the start to align with the end's column, and then moves vertically to reach the end's row, carving floor tiles along the way.
        {
            int row = start.Row;
            int col = start.Col;

            while (col != end.Col)
            {
                world.SetFloor(new Pos(row, col));
                col += col < end.Col ? 1 : -1;
            }

            while (row != end.Row)
            {
                world.SetFloor(new Pos(row, col));
                row += row < end.Row ? 1 : -1;
            }

            world.SetFloor(end);
        }
    }
}
