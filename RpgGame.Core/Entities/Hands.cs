using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Inventory;
using RpgGame.Core.Items.Equipping;
using RpgGame.Core.Items.Weapons;


namespace RpgGame.Core.Entities
{
    public sealed class Hands   // Hands class - player's weapon management. Tracks what weppon is equipped in each hand and helps to equip and unequip
    {
        private readonly Inventory.Inventory _inventory;    // Reference to player's inventory for moving items when equipping/unequipping

        public Weapon? Left { get; private set; }
        public Weapon? Right { get; private set; }

        public Hands(Inventory.Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool IsTwoHandedEquipped => Left is not null && ReferenceEquals(Left, Right); // ReferenceEquals checks if both hands reference the same weapon, which indicates a 2-handed weapon is equipped

        public void EquipOneHand(Weapon weapon, HandSlot slot)
        {
            if (slot == HandSlot.Left)
            {
                Left = weapon;
            }
            else
            {
                Right = weapon;
            }
        }

        public void EquipTwoHand(Weapon weapon)
        {
            Left = weapon;
            Right = weapon;
        }

        public void UnequipAllToInventory() // Unequips both hands to inventory, used for 2-handed weapons or when player wants to free both hands
        {
            if (Left is not null)
            {
                _inventory.Add(Left);
            }

            // avoid double-add if 2H
            if (Right is not null && !ReferenceEquals(Right, Left))
            {
                _inventory.Add(Right);
            }

            Left = null;
            Right = null;
        }

        public void UnequipSlotToInventory(HandSlot slot)   // Unequips a specific hand slot to inventory, used for 1-handed weapons or when player wants to free one hand
        {
            var w = (slot == HandSlot.Left) ? Left : Right; // Get the weapon in the specified slot
            if (w is null)
            {
                return;
            }

            // If 2H weapon is equipped, unequip both
            if (ReferenceEquals(Left, Right))
            {
                UnequipAllToInventory();
                return;
            }

            _inventory.Add(w);  // Add the weapon to inventory
            if (slot == HandSlot.Left)
            {
                Left = null;
            }
            else
            {
                Right = null;
            }
        }

        public void UnequipWeaponToInventory(Weapon weapon) // Unequips a specified weapon to the inventory
        {
            // If weapon occupies both hands
            if (ReferenceEquals(Left, Right) && ReferenceEquals(Left, weapon))  // Check if the weapon is the one equipped in both hands
            {
                UnequipAllToInventory();
                return;
            }

            if (ReferenceEquals(Left, weapon))
            {
                _inventory.Add(weapon);
                Left = null;
            }

            if (ReferenceEquals(Right, weapon))
            {
                _inventory.Add(weapon);
                Right = null;
            }
        }
    }
}
