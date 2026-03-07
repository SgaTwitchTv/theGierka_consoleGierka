using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Items.Equipping;
using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Weapons.Actions;

namespace RpgGame.Core.Items.Weapons
{
    public abstract class Weapon : Item // Weapon class
    {
        public int Damage { get; }
        public IHandRequirement HandRequirement { get; }    // The interface for hand requirements (e.g., one-handed, two-handed)

        protected Weapon(string name, char symbol, int damage, IHandRequirement handRequirement) : base(name, symbol)
        {
            Damage = damage;
            HandRequirement = handRequirement;
        }

        public override string GetDescription() => $"{Name} (DMG {Damage})";    // Override GetDescription to include damage information
        public override IEnumerable<IInventoryAction> GetInventoryActions(Player player)    // Override GetInventoryActions to include equipping actions based on hand requirements
        {
            // Yield equipping actions based on the hand requirement of the weapon because the player can only equip the weapon in the appropriate hand(s)
            yield return new EquipWeaponAction(player, this, HandSlot.Left);
            yield return new EquipWeaponAction(player, this, HandSlot.Right);
        }
    }
}
