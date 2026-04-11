using RpgGame.Console.Rendering;
using RpgGame.Core.Entities;
using RpgGame.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console = System.Console;
using RpgGame.Console.Input;
using RpgGame.Console.Input.Actions;

namespace RpgGame.Console
{
    public sealed class GameLoop    // The main game loop - handles live input, updates the game state, and renders the world
    {
        private readonly ConsoleRenderer _renderer;             // Renderer to draw the world and player state to the console
        private readonly GameContext _context;                 // The game context that holds the world, player, and other state information needed for the game loop
        private readonly List<IGameAction> _actions;          // A list of game actions that can be performed based on player input - each action knows how to match input and execute itself
        private readonly List<string> _strategyInstructions; // Additional instructions from the dungeon strategy to display in the help text
        public GameLoop(World world, Player player, ConsoleRenderer renderer, IEnumerable<string> strategyInstructions)
        {
            _renderer = renderer;
            _context = new GameContext(world, player);
            _strategyInstructions = strategyInstructions.ToList();

            _actions = new List<IGameAction>    // Initialize the list of available game actions - these will be checked against player input each frame to determine what action to execute
            {
                new MoveUpAction(),
                new MoveDownAction(),
                new MoveLeftAction(),
                new MoveRightAction(),
                new PickUpAction(),
                new NormalAttackAction(),
                new StealthAttackAction(),
                new MagicalAttackAction(),
                new SelectNextEnemyAction(),
                new SelectPrevInventoryAction(),
                new SelectNextInventoryAction(),
                new EquipLeftAction(),
                new EquipRightAction(),
                new UnequipLeftAction(),
                new UnequipRightAction(),
                new UnequipAllAction(),
                new DropSelectedAction(),
                new QuitAction()
            };
        }

        public void Run()   // The main method to start the game loop - will continue running until the game is over or the player quits
        {
            System.Console.CursorVisible = false;
            System.Console.Clear();

            while (_context.IsRunning) // Main game loop - continues until the game is over or the player quits
            {
                // Draw the current state of the world, player, and any messages to the console
                _renderer.Draw(_context.World, _context.Player, _context.LastMessage, _context.SelectedInventoryIndex, _context.SelectedEnemyIndex, GetHelpText(), _context.IsGameOver);

                var keyInfo = System.Console.ReadKey(true);

                var action = _actions.FirstOrDefault(a => a.Matches(keyInfo));

                if (action != null)
                {
                    action.Execute(_context);
                    NormalizeSelections();
                }
                else
                {
                    _context.LastMessage = "NOT ASSIGNED";
                }
            }

            _renderer.Draw(_context.World, _context.Player, _context.LastMessage, _context.SelectedInventoryIndex, _context.SelectedEnemyIndex, GetHelpText(), _context.IsGameOver);

            if (_context.IsGameOver)
            {
                System.Console.ReadKey(true);
            }
        }

        private void NormalizeSelections() // Ensures that the selected inventory and enemy indices are always valid after any action is performed - prevents out of range errors when the player picks up or drops items, or when enemies are defeated
        {
            int inventoryCount = _context.Player.Inventory.Items.Count;
            if (inventoryCount == 0)
            {
                _context.SelectedInventoryIndex = 0;
            }
            else
            {
                _context.SelectedInventoryIndex = Math.Clamp(_context.SelectedInventoryIndex, 0, inventoryCount - 1);
            }

            int enemyCount = RpgGame.Core.Combat.CombatResolver.GetAdjacentEnemies(_context.World, _context.Player).Count;
            if (enemyCount == 0)
            {
                _context.SelectedEnemyIndex = 0;
            }
            else
            {
                _context.SelectedEnemyIndex = Math.Clamp(_context.SelectedEnemyIndex, 0, enemyCount - 1);
            }
        }

        private string GetHelpText()
        {
            var help = new List<string>();
            var availableActions = _actions.Where(a => a.IsAvailable(_context)).ToList();

            var movementHelp = availableActions
                .Where(a => a.HelpGroup == "Movement")
                .Select(a => a.HelpText)
                .Distinct()
                .ToList();

            if (movementHelp.Count > 0)
            {
                help.Add(string.Join(" | ", movementHelp));
            }

            foreach (var actionHelp in availableActions
                .Where(a => a.HelpGroup == "Actions")
                .Select(a => a.HelpText)
                .Distinct())
            {
                help.Add(actionHelp);
            }

            foreach (var actionHelp in availableActions
                .Where(a => a.HelpGroup == "Combat")
                .Select(a => a.HelpText)
                .Distinct())
            {
                help.Add(actionHelp);
            }

            foreach (var actionHelp in availableActions
                .Where(a => a.HelpGroup == "Inventory")
                .Select(a => a.HelpText)
                .Distinct())
            {
                help.Add(actionHelp);
            }

            foreach (var actionHelp in availableActions
                .Where(a => a.HelpGroup == "System")
                .Select(a => a.HelpText)
                .Distinct())
            {
                help.Add(actionHelp);
            }

            // Strategy instructions (optional)
            foreach (var s in _strategyInstructions)
            {
                if (!string.IsNullOrWhiteSpace(s) && !help.Contains(s))
                {
                    help.Add(s);
                }
            }

            return string.Join(Environment.NewLine, help.Distinct());
        }
    }
}
