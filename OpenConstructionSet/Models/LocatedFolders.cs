namespace OpenConstructionSet.IO;

/// <summary>
/// Represents the results of searching for a game folder.
/// </summary>
/// <param name="Installation">Root folder of the game. Contains the main exexutables.</param>
/// <param name="Content">Optional content folder. e.g. the steam workshop folder</param>
public record LocatedFolders(string Installation, string? Content)
{
    private string? mod, data, save;

    /// <summary>
    /// The mod folder of this installation.
    /// </summary>
    public string Mod => mod ??= Path.Combine(Installation, "mods");

    /// <summary>
    /// The data folder of this installation.
    /// </summary>
    public string Data => data ??= Path.Combine(Installation, "data");

    /// <summary>
    /// The save folder of this installation.
    /// </summary>
    public string Save => save ??= Path.Combine(Installation, "save");
}
