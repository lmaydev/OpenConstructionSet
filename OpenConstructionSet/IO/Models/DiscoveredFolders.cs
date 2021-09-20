namespace OpenConstructionSet.IO;

public class DiscoveredFolders
{
    public DiscoveredFolders(string game, string? content)
    {
        Game = game;
        Content = content;
    }

    public string Game { get; set; }

    public string? Content { get; set; }

    public string Mod => Path.Combine(Game, "mods");

    public string Data => Path.Combine(Game, "mods");
}
