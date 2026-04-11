    using System;
using System.Collections.Generic;
using System.Text;
using RpgGame.Core.Combat;
using RpgGame.Core.Items.Equipping;
using RpgGame.Core.Entities;
using RpgGame.Core.Inventory.Actions;
using RpgGame.Core.Items.Weapons.Actions;

namespace RpgGame.Core.Items.Weapons
{
    // DESIGN: Template / Factory for inventory actions - base weapon provides shared behavior and produces concrete equip actions.
    public abstract class Weapon : Item, IWeapon // Weapon class inherits from Item and implements IWeapon interface, representing a weapon item in the game
    {
        public virtual int Damage { get; }
        public int Defense { get; }
        public IWeaponCategory Category { get; }
        public IHandRequirement HandRequirement { get; }    // The interface for hand requirements (e.g., one-handed, two-handed)

        protected Weapon(string name, char symbol, int damage, int defense, IWeaponCategory category, IHandRequirement handRequirement) : base(EnsureCategoryLabel(name, category), symbol)
        {
            Damage = damage;
            Defense = defense;
            Category = category;
            HandRequirement = handRequirement;
        }

        private static string EnsureCategoryLabel(string name, IWeaponCategory category)
        {
            var categoryToken = $"({category.DisplayName})";

            if (name.IndexOf(categoryToken, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return name;
            }

            return $"{name} {categoryToken}";
        }

        public override string GetDescription() => $"{Name} (DMG {Damage}, DEF {Defense})";    // Override GetDescription to include the effective damage information
        public override IEnumerable<IInventoryAction> GetInventoryActions(Player player)    // Override GetInventoryActions to include equipping actions based on hand requirements
        {
            // Yield equipping actions based on the hand requirement of the weapon because the player can only equip the weapon in the appropriate hand(s)
            yield return new EquipWeaponAction(player, this, HandSlot.Left);
            yield return new EquipWeaponAction(player, this, HandSlot.Right);
        }
    }
}
