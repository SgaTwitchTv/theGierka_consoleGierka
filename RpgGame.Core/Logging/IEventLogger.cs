namespace RpgGame.Core.Logging
{
    public interface IEventLogger
    {
        string LogFilePath { get; }              // Gets the file path where log entries are stored, allowing access to the log file for reading or other operations if needed.
        IReadOnlyList<string> Entries { get; }  // Gets the in-memory list of log entries, providing quick access to the logged events without needing to read from the file.
        IReadOnlyList<string> GetRecentEntries(int count);  // Retrieves a specified number of the most recent log entries, allowing for efficient access to recent events without needing to read the entire log.
        void Log(string message);   // Logs a new message, which will be implemented by concrete classes to handle the actual logging mechanism (e.g., writing to a file, storing in memory, etc.).
    }
}
