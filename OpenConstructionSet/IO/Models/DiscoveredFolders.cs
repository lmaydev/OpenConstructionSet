namespace OpenConstructionSet.IO;

public class DiscoveredFolders
{
    public DiscoveredFolders(string game, string? content)
    {
        Game = game;
        Content = content;
    }

    public string Game { get; }

    public string? Content { get; }

    public string Mod => Path.Combine(Game, "mods");

    public string Data => Path.Combine(Game, "data");
}
