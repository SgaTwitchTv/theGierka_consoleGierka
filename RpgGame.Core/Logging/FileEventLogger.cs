using System.Globalization;

namespace RpgGame.Core.Logging
{
    public sealed class FileEventLogger : IEventLogger  // Implements a logger that writes events to a file and keeps an in-memory list of entries.
    {
        private readonly List<string> _entries = new(); // In-memory list to store log entries for quick access.
        private readonly object _lock = new();         // Lock object to ensure thread safety when accessing the entries list.

        public string LogFilePath { get; }
        public IReadOnlyList<string> Entries => _entries;

        public FileEventLogger(string logDirectory, string playerName, DateTime startedAt)  // Constructor that initializes the logger by creating a unique log file and writing the initial game start entry.
        {
            Directory.CreateDirectory(logDirectory);
            LogFilePath = CreateUniqueLogPath(logDirectory, playerName, startedAt);

            using var stream = new FileStream(LogFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            using var writer = new StreamWriter(stream);
            writer.WriteLine($"Game started for {playerName} at {startedAt:yyyy-MM-dd HH:mm:ss}");
        }

        public IReadOnlyList<string> GetRecentEntries(int count)    // Retrieves the most recent log entries, ensuring thread safety while accessing the entries list.
        {
            lock (_lock)
            {
                return _entries.Skip(Math.Max(0, _entries.Count - count)).ToList();
            }
        }

        public void Log(string message) // Logs a new message by adding it to the in-memory list and appending it to the log file, ensuring thread safety during the operation.
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] {message}";

            lock (_lock)
            {
                _entries.Add(entry);
                File.AppendAllLines(LogFilePath, new[] { entry });
            }
        }

        private static string CreateUniqueLogPath(string logDirectory, string playerName, DateTime startedAt)   // Generates a unique log file path based on the player's name and the start time, ensuring that existing files are not overwritten by appending a numeric suffix if necessary.
        {
            string safeName = MakeSafeFileName(playerName);
            string stamp = startedAt.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
            string baseName = $"{safeName}_{stamp}";
            string path = Path.Combine(logDirectory, $"{baseName}.log");

            int suffix = 1;
            while (File.Exists(path))
            {
                path = Path.Combine(logDirectory, $"{baseName}_{suffix}.log");
                suffix++;
            }

            return path;
        }

        private static string MakeSafeFileName(string value)    // Converts a player name into a safe file name by replacing invalid characters with underscores and trimming whitespace, ensuring that the resulting name is valid for use as a file name.
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var safeChars = value.Select(ch => invalidChars.Contains(ch) ? '_' : ch).ToArray();
            string safeName = new string(safeChars).Trim();

            return string.IsNullOrWhiteSpace(safeName) ? "Player" : safeName;
        }
    }
}
