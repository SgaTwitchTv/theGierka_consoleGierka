using RpgGame.Core.Items;
using RpgGame.Core.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Core.Entities
{
    public sealed class Player  // Player class
    {
        public Pos Position { get; private set; } = new(0, 0);      // Set initial position of the player to (0, 0)
        public Wallet Wallet { get; } = new();                    // Initialize the wallet
        public Inventory.Inventory Inventory { get; } = new();  // Initialize the inventory
        public Hands Hands { get; }                           // Initialize the hands for equipping weapons

        public Stats Stats { get; } = new Stats(strength: 5, dexterity: 5, health: 20, luck: 1, aggression: 3, wisdom: 2);  // Initialize the stats of the player with some default values

        public Player()
        {
            Hands = new Hands(Inventory);
        }

        public void SetPosition(Pos position)  // Method to set the player's position
        {
            Position = position;
        }

        public bool TryMove(World.World world, int dRow, int dCol)  // Method to attempt moving the player in the world
        {
            var next = Position.Move(dRow, dCol);                 // Usage of the move function
            if (world.CanEnter(next))
            {
                Position = next;
                return true;
            }

            return false;
        }

        public bool TryPickUp(World.World world, out string message)    // Method to attempt picking up an item from the current cell in the world
        {
            var cell = world.Cell(Position);    // Get the current cell based on the player's position

            if (cell.Items.Count == 0)  // Check if there are any items in the cell
            {
                message = "Nothing here.";
                return false;
            }

            // Pick top item (last)
            IItem item = cell.Items[^1];
            cell.Items.RemoveAt(cell.Items.Count - 1);

            item.OnPickUp(this);    // Call the OnPickUp method of the item, passing the player as an argument

            if (item.GoesToInventory)
            {
                Inventory.Add(item);
                message = $"Picked up: {item.Name}";
            }
            else
            {
                message = $"Collected: {item.Name}";
            }

            return true;
        }

        public bool TryDropFromInventory(World.World world, int inventoryIndex, out string message) // Method to attempt dropping an item from the player's inventory into the current cell in the world
        {
            if (!Inventory.TryRemoveAt(inventoryIndex, out var item) || item == null)   // Try to remove the item from the inventory at the specified index, and check if it was successful
            {
                message = "Invalid inventory index.";
                return false;
            }

            world.Cell(Position).Items.Add(item);
            message = $"Dropped: {item.Name}";
            return true;
        }

        public Items.Modifiers.PlayerStatModifier GetEquippedStatModifier()
        {
            var modifier = Items.Modifiers.PlayerStatModifier.None;

            foreach (var item in Hands.GetHeldItems())
            {
                modifier = modifier.Combine(item.GetStatModifier());
            }

            return modifier;
        }

        public Stats GetEffectiveStats()
        {
            var modifier = GetEquippedStatModifier();

            return new Stats(
                Stats.Strength + modifier.Strength,
                Stats.Dexterity + modifier.Dexterity,
                Stats.Health + modifier.Health,
                Stats.Luck + modifier.Luck,
                Stats.Aggression + modifier.Aggression,
                Stats.Wisdom + modifier.Wisdom
            );
        }
    }
}
