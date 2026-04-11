using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Entities;
using RpgGame.Core.Items.Weapons;

namespace RpgGame.Core.Items.Equipping
{
    public interface IHandRequirement   // Defines how a weapon should be equipped
    {
        void Equip(Player player, IWeapon weapon, HandSlot preferredSlot);
        void Unequip(Player player, IWeapon weapon);
    }
}
