using RpgGame.Core.Combat;

namespace RpgGame.Console.Input.Actions
{
    public sealed class MagicalAttackAction : AttackActionBase
    {
        public MagicalAttackAction() : base("magical attack", ConsoleKey.M, new MagicalAttackStyle())
        {
        }
    }
}
