using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Console.Rendering
{
    public sealed class ConsoleRenderer
    {
        public void Draw(World world, Player player, string lastMessage, int selectedIndex, string helpText)
        {
            // Don't clear the whole console each frame (causes flicker).
            // Move cursor to the top-left and overwrite lines individually.
            System.Console.SetCursorPosition(0, 0);

            /*
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write(new string(' ', System.Console.WindowWidth * System.Console.WindowHeight));
            System.Console.SetCursorPosition(0, 0);
            */

            // Right panel: only player/wallet/stats/last
            var rightHud = BuildRightHudLines(player, lastMessage);

            var sb = new StringBuilder();

            // MAP + RIGHT HUD (20 rows)
            for (int r = 0; r < world.Rows; r++)
            {
                // Map row
                for (int c = 0; c < world.Cols; c++)
                {
                    if (player.Position.Row == r && player.Position.Col == c)
                    {
                        sb.Append('X');
                    }
                    else
                    {
                        sb.Append(world.Cell(new Pos(r, c)).GetSymbol());
                    }
                }

                sb.Append("  ");

                if (r < rightHud.Length)
                {
                    sb.Append(rightHud[r]);
                }

                sb.AppendLine();
            }

            // BOTTOM PANEL (below map)
            sb.AppendLine(new string('-', 90));

            // On tile
            var cell = world.Cell(player.Position);
            sb.Append("On tile: ");
            if (cell.Items.Count == 0)
            {
                sb.AppendLine("(nothing)");
            }
            else
            {
                // show up to 5 items
                int shown = 0;
                for (int i = cell.Items.Count - 1; i >= 0 && shown < 5; i--, shown++)
                {
                    if (shown > 0)
                    {
                        sb.Append(" | ");
                    }

                    sb.Append($"{cell.Items[i].Symbol} {cell.Items[i].Name}");
                }
                if (cell.Items.Count > 5)
                {
                    sb.Append($" | (+{cell.Items.Count - 5} more)");
                }
                sb.AppendLine();
            }

            // Inventory
            sb.Append("Inventory: ");
            if (player.Inventory.Items.Count == 0)
            {
                sb.AppendLine("(empty)");
            }
            else
            {
                int max = Math.Min(10, player.Inventory.Items.Count);
                for (int i = 0; i < max; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(" | ");
                    }

                    string marker = i == selectedIndex ? ">" : " ";
                    string name = player.Inventory.Items[i].Name;

                    sb.Append($"{marker}[{i}] {name}");
                }

                sb.AppendLine();
            }

            // Always show consolidated help text once
            if (!string.IsNullOrWhiteSpace(helpText))
            {
                sb.AppendLine(helpText);
            }

            sb.AppendLine("WASD move | E pick up | Up/Down select | L/R equip | 1/2 unequip | Backspace drop | Q quit");

            var output = sb.ToString();
            var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int maxRows = Math.Min(System.Console.WindowHeight, lines.Length);
            for (int i = 0; i < maxRows; i++)
            {
                System.Console.SetCursorPosition(0, i);
                // PadRight to ensure previous longer lines are fully overwritten
                System.Console.Write(lines[i].PadRight(System.Console.WindowWidth));
            }

            // Clear any remaining rows in the console that weren't overwritten
            for (int i = lines.Length; i < System.Console.WindowHeight; i++)
            {
                System.Console.SetCursorPosition(0, i);
                System.Console.Write(new string(' ', System.Console.WindowWidth));
            }
        }

        private static string[] BuildRightHudLines(Player player, string lastMessage)
        {
            var lines = new List<string>();

            lines.Add("== PLAYER ==");
            lines.Add($"Pos: {player.Position.Row},{player.Position.Col}");
            lines.Add("");

            lines.Add("== WALLET ==");
            lines.Add($"Coins: {player.Wallet.Coins}");
            lines.Add($"Gold : {player.Wallet.Gold}");
            lines.Add("");

            lines.Add("== STATS ==");
            lines.Add($"STR: {player.Stats.Strength}");
            lines.Add($"DEX: {player.Stats.Dexterity}");
            lines.Add($"HP : {player.Stats.Health}");
            lines.Add($"LUK: {player.Stats.Luck}");
            lines.Add($"AGR: {player.Stats.Aggression}");
            lines.Add($"WIS: {player.Stats.Wisdom}");
            lines.Add("");

            lines.Add("== LAST ==");
            lines.Add(string.IsNullOrWhiteSpace(lastMessage) ? "(none)" : lastMessage);

            //x lines.Add("");
            lines.Add("== EQUIPPED ==");
            lines.Add($"Left : {(player.Hands.Left?.GetDescription() ?? "(empty)")}");
            lines.Add($"Right: {(player.Hands.Right?.GetDescription() ?? "(empty)")}");

            return lines.ToArray();
        }
    }
}
