using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Decorators
{
    public abstract class WeaponDecorator : Items.Weapons.Weapon    // Weapon Decorator class to allow for easy creation of new weapons by wrapping existing ones and modifying their properties (e.g., damage, name)
    {
        protected readonly Items.Weapons.Weapon Inner;

        protected WeaponDecorator(Items.Weapons.Weapon inner, string namePrefix, int damageBonus) : base(name: $"{namePrefix} {inner.Name}", symbol: inner.Symbol, damage: inner.Damage + damageBonus, handRequirement: inner.HandRequirement)
        {
            Inner = inner;
        }

        // IMPORTANT: keep weapon actions (equip left/right) working
        public override IEnumerable<IInventoryAction> GetInventoryActions(Entities.Player player) => Inner.GetInventoryActions(player); // This ensures that the decorated weapon can still be equipped and used as intended.

        // If you ever add other behavior to Weapon, forward it here similarly.
    }
}
