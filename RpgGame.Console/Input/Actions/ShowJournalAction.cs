using RpgGame.Core.Logging;

namespace RpgGame.Console.Input.Actions
{
    public sealed class ShowJournalAction : IGameAction
    {
        public string HelpText => "J - show full event log";
        public string HelpGroup => "System";

        public bool Matches(ConsoleKeyInfo keyInfo) => keyInfo.Key == ConsoleKey.J;
        public bool IsAvailable(GameContext context) => true;

        public void Execute(GameContext context)
        {
            System.Console.Clear();
            System.Console.WriteLine("== EVENT LOG ==");
            System.Console.WriteLine();

            foreach (var entry in GameLog.Current.Entries)
            {
                System.Console.WriteLine(entry);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to return to the dungeon.");
            System.Console.ReadKey(true);

            context.LastMessage = "Viewed event log.";
        }
    }
}
