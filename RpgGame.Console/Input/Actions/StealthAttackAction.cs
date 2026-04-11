using RpgGame.Core.Combat;

namespace RpgGame.Console.Input.Actions
{
    public sealed class StealthAttackAction : AttackActionBase
    {
        public StealthAttackAction() : base("stealth attack", ConsoleKey.T, new StealthAttackStyle())
        {
        }
    }
}
