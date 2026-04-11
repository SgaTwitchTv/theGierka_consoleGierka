using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Items.Equipping
{
    public sealed class TwoHandRequirement : IHandRequirement   // Analogously, but for 2handed weapon
    {
        public void Equip(Player player, IWeapon weapon, HandSlot preferredSlot) // For 2-handed weapons, we ignore the preferredSlot and just unequip both hands and equip the weapon in both.
        {
            player.Hands.UnequipAllToInventory();   // Unequip both hands to inventory
            player.Hands.EquipTwoHand(weapon);     // Equip the weapon in both hands
        }

        public void Unequip(Player player, IWeapon weapon)   // Just unequip the weapon from both hands, back to inventory.
        {
            player.Hands.UnequipWeaponToInventory(weapon);
        }
    }
}
