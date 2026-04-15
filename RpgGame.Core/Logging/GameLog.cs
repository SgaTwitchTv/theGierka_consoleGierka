namespace RpgGame.Core.Logging
{
    public static class GameLog // Provides a static interface for logging game events, allowing configuration of the underlying logger and writing log messages through a centralized point.
    {
        private static IEventLogger _current = new NullEventLogger();   // Default logger that does nothing, ensuring that logging calls do not fail if the logger is not configured.

        public static IEventLogger Current => _current; // Exposes the current logger instance, allowing other parts of the application to access it if needed.

        public static void Configure(IEventLogger logger)   // Configures the logging system by setting the current logger instance, allowing the application to switch to a different logging implementation (e.g., file-based) as needed.
        {
            _current = logger;
        }

        public static void Write(string message)    // Writes a log message using the current logger, providing a simple interface for other parts of the application to log events without needing to know the details of the logging implementation.
        {
            _current.Log(message);
        }
    }
}
