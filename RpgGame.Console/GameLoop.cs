using RpgGame.Console.Rendering;
using RpgGame.Core.Entities;
using RpgGame.Core.World;
using System;
using System.Collections.Generic;
using System.Text;
using Console = System.Console;

namespace RpgGame.Console
{
    public sealed class GameLoop    // The main game loop - handles live input, updates the game state, and renders the world
    {
        // The world, player, and renderer are injected into the game loop to allow for separation of concerns and easier testing
        private readonly World _world;
        private readonly Player _player;
        private readonly ConsoleRenderer _renderer;
        private string _lastMessage = "";
        private int _selectedIndex = 0;

        public GameLoop(World world, Player player, ConsoleRenderer renderer)
        {
            _world = world;
            _player = player;
            _renderer = renderer;
        }

        public void Run()   // The main loop of the game - runs until the player chooses to quit
        {
            System.Console.CursorVisible = false;
            System.Console.Clear();

            bool running = true;    // The flag to control the game loop - set to false when the player chooses to quit

            while (running) // The main loop
            {
                if (System.Console.KeyAvailable)
                {
                    var key = System.Console.ReadKey(true).Key;

                    switch (key)    // Main swirtch to handle player input
                    {
                        // Movement
                        case ConsoleKey.W: 
                            _player.TryMove(_world, -1, 0); 
                            break;

                        case ConsoleKey.S: 
                            _player.TryMove(_world, 1, 0); 
                            break;

                        case ConsoleKey.A: 
                            _player.TryMove(_world, 0, -1); 
                            break;

                        case ConsoleKey.D: 
                            _player.TryMove(_world, 0, 1); 
                            break;

                        // Inventory actions
                        case ConsoleKey.Q:
                            DropSelected();
                            break;

                        case ConsoleKey.E:
                            _player.TryPickUp(_world, out _lastMessage);
                            break;

                        case ConsoleKey.UpArrow:
                            SelectPrev();
                            break;
                        case ConsoleKey.DownArrow:
                            SelectNext();
                            break;
                        case ConsoleKey.L:
                            EquipSelected("Equip Left");
                            break;
                        case ConsoleKey.R:
                            EquipSelected("Equip Right");
                            break;
                        case ConsoleKey.U:
                            _player.Hands.UnequipAllToInventory();
                            _lastMessage = "Unequipped all.";
                            break;                            
                        case ConsoleKey.D1:
                            _player.Hands.UnequipSlotToInventory(RpgGame.Core.Items.Equipping.HandSlot.Left);
                            _lastMessage = "Unequipped left.";
                            break;
                        case ConsoleKey.D2:
                            _player.Hands.UnequipSlotToInventory(RpgGame.Core.Items.Equipping.HandSlot.Right);
                            _lastMessage = "Unequipped right.";
                            break;

                        // Escape to exit
                        case ConsoleKey.Escape:
                            running = false;
                            break;
                    }
                }

                _renderer.Draw(_world, _player, _lastMessage);  // And here we redraw the world and player state after processing input
                Thread.Sleep(16);
            }
        }

        private void EquipLastToHand(RpgGame.Core.Items.Equipping.HandSlot slot)    // A function to equip the last item in the inventory to the specified hand - checks if the action is valid and updates the inventory and hands accordingly
        {
            var items = _player.Inventory.Items;
            if (items.Count == 0)
            {
                _lastMessage = "Inventory empty.";
                return;
            }

            // The last item
            var item = items[^1];

               // We need to equip only weapons.
              // To avoid RTTI, we’ll solve this next by making equippables provide actions.
             // For NOW (temporary), you can move weapons into a separate "WeaponInventory" list
            // OR (if allowed by your rules) cast via pattern matching is RTTI (banned).
            _lastMessage = "Next step: add equippable actions (no RTTI).";
        }

        private void SelectPrev()   // A function to select the previous item in the inventory - wraps around to the end if at the beginning
        {
            if (_player.Inventory.Items.Count == 0) 
            { 
                _selectedIndex = 0; 
                return; 
            }
            _selectedIndex = Math.Max(0, _selectedIndex - 1);
        }

        private void SelectNext()   // A function to select the next item in the inventory - wraps around to the beginning if at the end
        {
            int count = _player.Inventory.Items.Count;
            if (count == 0) 
            { 
                _selectedIndex = 0; 
                return; 
            }
            _selectedIndex = Math.Min(count - 1, _selectedIndex + 1);
        }

        private void EquipSelected(string label)    // A function to equip the selected item in the inventory to the specified hand - checks if the action is valid and updates the inventory and hands accordingly
        {
            var items = _player.Inventory.Items;
            if (items.Count == 0)
            {
                _lastMessage = "Inventory empty.";
                return;
            }

            if (_selectedIndex >= items.Count)
            {
                _selectedIndex = items.Count - 1;
            }

            var item = items[_selectedIndex];
            var actions = item.GetInventoryActions(_player).ToList();     // Get actions for the item, which should include equipping if it's equippable

            var action = actions.FirstOrDefault(a => a.Label == label); // Find the action that matches the label (e.g., "Equip Left" or "Equip Right")
            if (action is null)
            {
                _lastMessage = $"No action: {label}";
                return;
            }

             // Remove item from inventory BEFORE equipping, otherwise dupes
            // (hands store reference; inventory should not keep it)
            if (_player.Inventory.TryRemoveAt(_selectedIndex, out var removed) && removed is not null)
            {
                action.Execute();
                _lastMessage = $"{label}: {removed.Name}";
                if (_selectedIndex >= _player.Inventory.Items.Count)
                {
                    _selectedIndex = Math.Max(0, _player.Inventory.Items.Count - 1);
                }
            }
        }

        private void DropSelected() // A function to drop the selected item in the inventory onto the current tile - checks if the action is valid and updates the inventory and world accordingly
        {
            if (_player.Inventory.Items.Count == 0)
            {
                _lastMessage = "Inventory empty.";
                return;
            }

            if (_selectedIndex >= _player.Inventory.Items.Count)
            {
                _selectedIndex = _player.Inventory.Items.Count - 1;
            }

            if (_player.TryDropFromInventory(_world, _selectedIndex, out var msg))
            {
                _lastMessage = msg;
                if (_selectedIndex >= _player.Inventory.Items.Count)    // If we dropped the last item, move selection back
                {
                    _selectedIndex = Math.Max(0, _player.Inventory.Items.Count - 1);
                }
            }
            else
            {
                _lastMessage = msg;
            }
        }
    }
}
