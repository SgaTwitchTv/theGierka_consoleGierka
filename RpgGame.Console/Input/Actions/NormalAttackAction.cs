using RpgGame.Core.Combat;

namespace RpgGame.Console.Input.Actions
{
    public sealed class NormalAttackAction : AttackActionBase
    {
        public NormalAttackAction() : base("normal attack", ConsoleKey.N, new NormalAttackStyle())
        {
        }
    }
}
