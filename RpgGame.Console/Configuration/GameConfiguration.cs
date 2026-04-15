namespace RpgGame.Console.Configuration
{
    public sealed class GameConfiguration   // The 'sealed' keyword prevents other classes from inheriting from this class, which can be useful for configuration classes to ensure they are not extended in unintended ways.
    {
        public string PlayerName { get; set; } = "Hero";     // Default player name is set to "Hero". This can be overridden by the user when they provide their own configuration.
        public string LogDirectory { get; set; } = "logs";  // Default log directory is set to "logs". This can be overridden by the user when they provide their own configuration.
    }
}
