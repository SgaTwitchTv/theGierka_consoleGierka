namespace RpgGame.Core.Logging
{
    public sealed class NullEventLogger : IEventLogger  // Implements a logger that does nothing, serving as a default or placeholder logger to avoid null reference issues when logging is not configured.
    {
        public string LogFilePath => "";
        public IReadOnlyList<string> Entries => Array.Empty<string>();

        public IReadOnlyList<string> GetRecentEntries(int count) => Array.Empty<string>();  // Returns an empty list of recent entries, as this logger does not store any log messages.

        public void Log(string message) // Does nothing when a log message is sent, effectively ignoring all log entries.
        {
        }
    }
}
