using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Combat;
using RpgGame.Core.Entities;
using RpgGame.Core.World;

namespace RpgGame.Console.Rendering
{
    public sealed class ConsoleRenderer
    {
        public void Draw(World world, Player player, string lastMessage, int selectedInventoryIndex, int selectedEnemyIndex, string helpText, bool isGameOver = false)
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

                    string marker = i == selectedInventoryIndex ? ">" : " ";
                    string name = player.Inventory.Items[i].Name;

                    sb.Append($"{marker}[{i}] {name}");
                }

                sb.AppendLine();
            }

            sb.Append("Nearby enemies: ");
            var nearbyEnemies = CombatResolver.GetAdjacentEnemies(world, player);
            if (nearbyEnemies.Count == 0)
            {
                sb.AppendLine("(none)");
            }
            else
            {
                int clampedSelectedEnemyIndex = 0;
                if (nearbyEnemies.Count > 0)
                {
                    clampedSelectedEnemyIndex = Math.Clamp(selectedEnemyIndex, 0, nearbyEnemies.Count - 1);
                }

                for (int i = 0; i < nearbyEnemies.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(" | ");
                    }

                    var enemy = nearbyEnemies[i];
                    var targetMarker = i == clampedSelectedEnemyIndex ? ">" : " ";
                    sb.Append($"{targetMarker}{enemy.Symbol} {enemy.Name} HP:{enemy.Health} ATK:{enemy.Attack} ARM:{enemy.Armor}");
                }

                sb.AppendLine();
            }

            // Always show consolidated (context-aware) help text once
            if (!string.IsNullOrWhiteSpace(helpText))
            {
                // helpText may contain multiple lines; append as-is
                sb.AppendLine(helpText);
            }

            if (isGameOver)
            {
                sb.AppendLine("GAME OVER - press any key to close");
            }

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
            var effectiveStats = player.GetEffectiveStats();
            var lines = new List<string>();

            lines.Add("== PLAYER ==");
            lines.Add($"Pos: {player.Position.Row},{player.Position.Col}");
            lines.Add("");

            lines.Add("== WALLET ==");
            lines.Add($"Coins: {player.Wallet.Coins}");
            lines.Add($"Gold : {player.Wallet.Gold}");
            lines.Add("");

            lines.Add("== STATS ==");
            lines.Add(FormatStat("STR", player.Stats.Strength, effectiveStats.Strength));
            lines.Add(FormatStat("DEX", player.Stats.Dexterity, effectiveStats.Dexterity));
            lines.Add(FormatStat("HP ", player.Stats.Health, effectiveStats.Health));
            lines.Add(FormatStat("LUK", player.Stats.Luck, effectiveStats.Luck));
            lines.Add(FormatStat("AGR", player.Stats.Aggression, effectiveStats.Aggression));
            lines.Add(FormatStat("WIS", player.Stats.Wisdom, effectiveStats.Wisdom));
            lines.Add("");

            lines.Add("== LAST ==");
            lines.Add(string.IsNullOrWhiteSpace(lastMessage) ? "(none)" : lastMessage);

            //x lines.Add("");
            lines.Add("== EQUIPPED ==");
            lines.Add($"Left : {(player.Hands.Left?.GetDescription() ?? "(empty)")}");
            lines.Add($"Right: {(player.Hands.Right?.GetDescription() ?? "(empty)")}");

            return lines.ToArray();
        }

        private static string FormatStat(string label, int baseValue, int effectiveValue)
        {
            if (baseValue == effectiveValue)
            {
                return $"{label}: {effectiveValue}";
            }

            return $"{label}: {effectiveValue} ({baseValue})";
        }
    }
}
