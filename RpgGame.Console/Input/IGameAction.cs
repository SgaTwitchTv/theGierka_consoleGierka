using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input
{
    public interface IGameAction    // Interface for game actions that can be triggered by user input
    {
        string HelpText { get; }
        string HelpGroup { get; }
        bool Matches(ConsoleKeyInfo keyInfo);
        bool IsAvailable(GameContext context);
        void Execute(GameContext context);
    }
}
