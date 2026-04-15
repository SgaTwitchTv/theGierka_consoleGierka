using RpgGame.Core.Entities;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Weapons;
using RpgGame.Core.World;

namespace RpgGame.Core.Combat
{
    public static class CombatResolver  // A static class responsible for resolving combat interactions between the player and enemies. It provides methods to check for adjacent enemies and to perform attacks, calculating damage based on the player's stats, equipped weapons, and the chosen attack style.
    {
        public static bool HasAdjacentEnemy(World.World world, Player player) => GetAdjacentEnemies(world, player).Count > 0; // A method that checks if there is an adjacent enemy to the player by looking for adjacent enemies.

        public static IReadOnlyList<Enemy> GetAdjacentEnemies(World.World world, Player player) // Method that retrieves a list of enemies adjacent to the player's current position. It checks all the directions for enemies and returns a list of any found. If there are no adjacent enemies, it returns an empty list.
        {
            var enemies = new List<Enemy>();
            var positions = new[]
            {
                new Pos(player.Position.Row - 1, player.Position.Col),
                new Pos(player.Position.Row, player.Position.Col + 1),
                new Pos(player.Position.Row + 1, player.Position.Col),
                new Pos(player.Position.Row, player.Position.Col - 1)
            };

            foreach (var pos in positions)
            {
                if (!world.IsInBounds(pos))
                {
                    continue;
                }

                var enemy = world.Cell(pos).Enemy;
                if (enemy != null)
                {
                    enemies.Add(enemy);
                }
            }

            return enemies;
        }

        public static bool TryAttack(World.World world, Player player, IAttackStyle attackStyle, int targetIndex, out string message, out bool playerDefeated)   // A method that attempts to perform an attack on a selected adjacent enemy using the specified attack style. It calculates the damage dealt to the enemy and the damage received by the player, updates their health accordingly, and returns a message describing the outcome of the attack. It also indicates whether the player was defeated as a result of the combat.
        {
            playerDefeated = false;

            var adjacentEnemies = GetAdjacentEnemies(world, player);
            if (adjacentEnemies.Count == 0)
            {
                message = "No enemy nearby.";
                return false;
            }

            if (targetIndex < 0 || targetIndex >= adjacentEnemies.Count)
            {
                targetIndex = 0;
            }

            var enemy = adjacentEnemies[targetIndex];   // Get the selected enemy based on the target index. If the index is out of bounds, it defaults to the first adjacent enemy.

            var effectiveStats = player.GetEffectiveStats();
            var heldItems = player.Hands.GetHeldItems();

            // Calculate the outgoing damage based on the player's held items and the chosen attack style. If no items are held, it uses the fallback attack value from the attack style.
            int outgoingDamage = heldItems.Count == 0 ? attackStyle.GetFallbackAttack(effectiveStats) : heldItems.Sum(item => GetAttackDamage(item, effectiveStats, attackStyle));

            int dealtDamage = Math.Max(0, outgoingDamage - enemy.Armor);
            enemy.TakeDamage(dealtDamage);
            RpgGame.Core.Logging.GameLog.Write($"{attackStyle.Name} attack dealt {dealtDamage} damage to {enemy.Name}.");

            if (!enemy.IsAlive)
            {
                world.Cell(enemy.Position).Enemy = null;
                message = $"{attackStyle.Name} attack hit {enemy.Name} for {dealtDamage} and defeated it.";
                RpgGame.Core.Logging.GameLog.Write($"Defeated {enemy.Name}.");
                return true;
            }

            // Calculate the incoming damage from the enemy's attack, considering the player's defense from held items and the attack style. If no items are held, it uses the fallback defense value from the attack style.
            int defense = heldItems.Count == 0 ? attackStyle.GetFallbackDefense(effectiveStats) : heldItems.Sum(item => GetDefenseValue(item, effectiveStats, attackStyle));

            int receivedDamage = Math.Max(0, enemy.Attack - defense);
            player.Stats.ReduceHealth(receivedDamage);
            RpgGame.Core.Logging.GameLog.Write($"{enemy.Name} attacked {player.Name} for {receivedDamage} damage.");

            if (player.Stats.Health <= 0)
            {
                playerDefeated = true;
                message = $"{attackStyle.Name} attack hit {enemy.Name} for {dealtDamage}. {enemy.Name} struck back for {receivedDamage}. You were defeated.";
                return true;
            }

            message = $"{attackStyle.Name} attack hit {enemy.Name} for {dealtDamage}. {enemy.Name} struck back for {receivedDamage}.";
            return true;
        }

          // Implementing the interface methods to calculate attack damage and defense values based on the equipped item, player's stats, and the chosen attack style.
         //  If the item is a weapon, it uses the weapon category's methods to get the attack damage and defense values.
        //   If it's not a weapon, it falls back to the attack style's methods for held items.
        private static int GetAttackDamage(IItem item, Stats stats, IAttackStyle attackStyle)
        {
            if (item is IWeapon weapon)
            {
                return weapon.Category.GetAttackDamage(weapon, stats, attackStyle);
            }

            return attackStyle.GetHeldItemAttack(item, stats);
        }

        private static int GetDefenseValue(IItem item, Stats stats, IAttackStyle attackStyle)
        {
            if (item is IWeapon weapon)
            {
                return weapon.Category.GetDefenseValue(weapon, stats, attackStyle);
            }

            return attackStyle.GetHeldItemDefense(item, stats);
        }
    }
}
