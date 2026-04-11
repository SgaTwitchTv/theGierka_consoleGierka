using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Items.Equipping
{
    // DESIGN PATTERN: Strategy / Policy - encapsulates equip/unequip policy for one-handed weapons.
    public sealed class OneHandRequirement : IHandRequirement   // If the weapon is one-handed, it can be equipped in either hand, but not both at the same time.
    {
        public void Equip(Player player, IWeapon weapon, HandSlot preferredSlot) // The preferredSlot is just a hint; if it's occupied, we can try the other hand.
        {
            // Unequip whatever is in that hand (back to inventory)
            player.Hands.UnequipSlotToInventory(preferredSlot);

            // Put weapon in that hand
            player.Hands.EquipOneHand(weapon, preferredSlot);
        }

        public void Unequip(Player player, IWeapon weapon)   // Just unequip the weapon from whichever hand it's in, back to inventory.
        {
            player.Hands.UnequipWeaponToInventory(weapon);
        }
    }
}
