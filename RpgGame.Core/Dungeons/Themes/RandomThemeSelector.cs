namespace RpgGame.Core.Dungeons.Themes
{
    public static class RandomThemeSelector
    {
        public static IDungeonTheme Choose(Random random)   // The Choose method takes a Random object as a parameter and uses it to select a random dungeon theme from a predefined list of themes. This allows for variability in the dungeon experience each time the player enters a new dungeon, as they may encounter different themes with unique layouts, items, and enemies.
        {
            IDungeonTheme[] themes =
            {
                new LibraryTheme(),
                new FoundryTheme(),
                new TreasuryTheme()
            };

            return themes[random.Next(themes.Length)];
        }
    }
}
