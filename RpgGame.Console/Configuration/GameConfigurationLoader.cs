using System.Text.Json;

namespace RpgGame.Console.Configuration
{
    public static class GameConfigurationLoader // GameConfigurationLoader is a static class that provides a method to load the game configuration from a JSON file. It ensures that the configuration file exists, is valid, and contains the necessary properties before returning a GameConfiguration object.
    {
        public static GameConfiguration Load(string path)   // The Load method takes a file path as an argument and attempts to read and deserialize the JSON configuration file at that path. It performs several checks to ensure the file exists, is valid, and contains the required properties before returning a GameConfiguration object.
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Configuration file not found: {path}");
            }

            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<GameConfiguration>(json, new JsonSerializerOptions  // Deserialize the JSON content into a GameConfiguration object using System.Text.Json. The JsonSerializerOptions is configured to ignore case when matching property names, allowing for more flexibility in the JSON file's formatting.
            {
                PropertyNameCaseInsensitive = true
            });

            if (config == null)
            {
                throw new InvalidOperationException("Configuration file is empty or invalid.");
            }

            if (string.IsNullOrWhiteSpace(config.PlayerName))
            {
                throw new InvalidOperationException("Configuration must specify PlayerName.");
            }

            if (string.IsNullOrWhiteSpace(config.LogDirectory))
            {
                throw new InvalidOperationException("Configuration must specify LogDirectory.");
            }

            return config;
        }
    }
}
