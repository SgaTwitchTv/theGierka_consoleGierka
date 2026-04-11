using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Equipping;
using RpgGame.Core.Items.Weapons.Actions;

namespace RpgGame.Core.Items.Decorators
{
    public abstract class WeaponDecorator : Items.Weapons.Weapon    // Weapon Decorator class to allow for easy creation of new weapons by wrapping existing ones and modifying their properties (e.g., damage, name)
    {
        protected readonly Items.Weapons.IWeapon Inner;
        private readonly int _damageDelta;

        protected WeaponDecorator(Items.Weapons.IWeapon inner, string modifierName, int damageBonus) : base(name: BuildName(inner.Name, modifierName), symbol: inner.Symbol, damage: inner.Damage, defense: inner.Defense, category: inner.Category, handRequirement: inner.HandRequirement)
        {
            Inner = inner;
            _damageDelta = damageBonus;
        }

        private static string BuildName(string innerName, string modifierName)
        {
            if (string.IsNullOrEmpty(innerName))
            {
                return $"({modifierName})";
            }

            var token = $"({modifierName})";
            // If the modifier is already present in the inner name, don't append it again.
            if (innerName.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return innerName;
            }

            return $"{innerName} {token}";
        }

        // Keep weapon actions (equip left/right) working and make sure actions reference the decorator so the decorator isn't lost when the weapon is moved between inventory and hands.
        public override IEnumerable<IInventoryAction> GetInventoryActions(Entities.Player player)
        {
            // Return equip actions that reference this decorated weapon instance.
            yield return new EquipWeaponAction(player, this, HandSlot.Left);
            yield return new EquipWeaponAction(player, this, HandSlot.Right);
        }
        public override int Damage => Inner.Damage + _damageDelta;
        public override Modifiers.PlayerStatModifier GetStatModifier() => Inner.GetStatModifier();
    }
}
