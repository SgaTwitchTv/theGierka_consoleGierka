using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgGame.Core.Inventory;
using RpgGame.Core.Items;
using RpgGame.Core.Items.Equipping;
using RpgGame.Core.Items.Weapons;


namespace RpgGame.Core.Entities
{
    public sealed class Hands   // Hands class - player's held-item management. Tracks what item is equipped in each hand and helps to equip and unequip
    {
        private readonly Inventory.Inventory _inventory;    // Reference to player's inventory for moving items when equipping/unequipping

        public IItem? Left { get; private set; }
        public IItem? Right { get; private set; }

        public Hands(Inventory.Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool IsTwoHandedEquipped => Left != null && ReferenceEquals(Left, Right); // ReferenceEquals checks if both hands reference the same item, which indicates a 2-handed weapon is equipped

        public void EquipHeldItem(IItem item, HandSlot slot)
        {
            UnequipSlotToInventory(slot);

            if (slot == HandSlot.Left)
            {
                Left = item;
            }
            else
            {
                Right = item;
            }
        }

        public void EquipOneHand(IWeapon weapon, HandSlot slot)
        {
            EquipHeldItem(weapon, slot);
        }

        public void EquipTwoHand(IWeapon weapon)
        {
            Left = weapon;
            Right = weapon;
        }

        public void UnequipAllToInventory() // Unequips both hands to inventory, used for 2-handed weapons or when player wants to free both hands
        {
            if (Left != null)
            {
                _inventory.Add(Left);
            }

            // avoid double-add if 2H
            if (Right != null && !ReferenceEquals(Right, Left))
            {
                _inventory.Add(Right);
            }

            Left = null;
            Right = null;
        }

        public void UnequipSlotToInventory(HandSlot slot)   // Unequips a specific hand slot to inventory, used for 1-handed weapons or when player wants to free one hand
        {
            var w = (slot == HandSlot.Left) ? Left : Right; // Get the weapon in the specified slot
            if (w == null)
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

        public void UnequipWeaponToInventory(IWeapon weapon) // Unequips a specified weapon to the inventory
        {
            UnequipHeldItemToInventory(weapon);
        }

        public void UnequipHeldItemToInventory(IItem item)
        {
            // If item occupies both hands
            if (ReferenceEquals(Left, Right) && ReferenceEquals(Left, item))  // Check if the item is the one equipped in both hands
            {
                UnequipAllToInventory();
                return;
            }

            if (ReferenceEquals(Left, item))
            {
                _inventory.Add(item);
                Left = null;
            }

            if (ReferenceEquals(Right, item))
            {
                _inventory.Add(item);
                Right = null;
            }
        }

        public IReadOnlyList<IWeapon> GetEquippedWeapons()  // Method that returns a list of currently equipped weapons
        {
            var equipped = new List<IWeapon>();

            if (Left is IWeapon leftWeapon)
            {
                equipped.Add(leftWeapon);
            }

            if (Right is IWeapon rightWeapon && !ReferenceEquals(Right, Left))
            {
                equipped.Add(rightWeapon);
            }

            return equipped;
        }

        public IReadOnlyList<IItem> GetHeldItems()  // Method that returns a list of currently held items
        {
            var held = new List<IItem>();

            if (Left != null)
            {
                held.Add(Left);
            }

            if (Right != null && !ReferenceEquals(Right, Left))
            {
                held.Add(Right);
            }

            return held;
        }
    }
}
