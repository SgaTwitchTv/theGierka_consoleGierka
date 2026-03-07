using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Equipping;

namespace RpgGame.Core.Items.Weapons.Actions
{
    public sealed class EquipWeaponAction : InventoryActionBase // EquipWeaponAction is a specific type of InventoryActionBase that handles equipping weapons for a player. It takes in the player, the weapon to be equipped, and the hand slot (left or right) as parameters. When executed, it calls the Equip method on the weapon's HandRequirement, passing in the player, weapon, and slot to perform the equipping action.
    {
        private readonly Player _player;
        private readonly Weapons.Weapon _weapon;
        private readonly HandSlot _slot;

        public EquipWeaponAction(Player player, Weapons.Weapon weapon, HandSlot slot): base(slot == HandSlot.Left ? "Equip Left" : "Equip Right")   // The constructor initializes the EquipWeaponAction with the player, weapon, and hand slot. It also sets the action name based on the hand slot (either "Equip Left" or "Equip Right").
        {
            _player = player;
            _weapon = weapon;
            _slot = slot;
        }

        public override void Execute() // The execute method is overridden to perform the actual equipping action. It calls the Equip method on the weapon's HandRequirement, passing in the player, weapon, and hand slot to equip the weapon accordingly.
        {
            _weapon.HandRequirement.Equip(_player, _weapon, _slot);
        }
    }
}
