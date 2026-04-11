using RpgGame.Core.Combat;

namespace RpgGame.Console.Input.Actions
{
    public abstract class AttackActionBase : IGameAction    // Base class for attack actions, providing common functionality for different attack styles.
    {
        private readonly IAttackStyle _attackStyle;

        protected AttackActionBase(string actionLabel, ConsoleKey key, IAttackStyle attackStyle)
        {
            Key = key;
            _attackStyle = attackStyle;
            HelpText = $"{FormatKey(key)} - {actionLabel}";
        }

        protected ConsoleKey Key { get; }
        public string HelpText { get; }
        public string HelpGroup => "Combat";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == Key;

        public bool IsAvailable(GameContext context) => CombatResolver.HasAdjacentEnemy(context.World, context.Player);

        public void Execute(GameContext context)
        {
            CombatResolver.TryAttack(context.World, context.Player, _attackStyle, context.SelectedEnemyIndex, out var message, out var playerDefeated);
            context.LastMessage = message;

            var remainingEnemies = CombatResolver.GetAdjacentEnemies(context.World, context.Player);
            context.SelectedEnemyIndex = remainingEnemies.Count == 0 ? 0 : Math.Min(context.SelectedEnemyIndex, remainingEnemies.Count - 1);

            if (playerDefeated)
            {
                context.IsGameOver = true;
                context.IsRunning = false;
            }
        }

        private static string FormatKey(ConsoleKey key)
        {
            var keyText = key.ToString();

            return keyText.Length == 1 ? keyText.ToUpperInvariant() : keyText;
        }
    }
}
