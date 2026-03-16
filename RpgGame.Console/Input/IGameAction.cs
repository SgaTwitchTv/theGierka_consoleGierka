using System;
using System.Collections.Generic;
using System.Text;

namespace RpgGame.Console.Input
{
    public interface IGameAction    // Interface for game actions that can be triggered by user input
    {
        string HelpText { get; }
        bool Matches(ConsoleKeyInfo keyInfo);
        void Execute(GameContext context);
    }
}
