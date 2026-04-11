using System;
using RpgGame.Core.Combat;

namespace RpgGame.Console.Input.Actions
{
    public sealed class SelectNextEnemyAction : IGameAction // An action that allows the player to cycle through adjacent enemies during combat by pressing the Tab key.
    {
        public string HelpText => "Tab - select next nearby enemy";
        public string HelpGroup => "Combat";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.Tab;   // Triggered when the player presses the Tab key.

        public bool IsAvailable(GameContext context) => CombatResolver.GetAdjacentEnemies(context.World, context.Player).Count > 1;

        public void Execute(GameContext context)    // When executed, it retrieves the list of adjacent enemies and updates the selected enemy index to cycle through them. It also updates the last message to indicate which enemy is currently targeted.
        {
            var enemies = CombatResolver.GetAdjacentEnemies(context.World, context.Player);
            if (enemies.Count <= 1)
            {
                context.SelectedEnemyIndex = 0;
                return;
            }

            context.SelectedEnemyIndex = (context.SelectedEnemyIndex + 1) % enemies.Count;
            context.LastMessage = $"Targeting: {enemies[context.SelectedEnemyIndex].Name}";
        }
    }
}
