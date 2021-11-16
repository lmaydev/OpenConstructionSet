namespace OpenConstructionSet.Models;

/// <summary>
/// Represents the game's save folder.
/// </summary>
public sealed record SaveFolder(string FolderPath)
{
    /// <summary>
    /// A collection of <see cref="Save"/>s.
    /// </summary>
    public List<Save> Saves { get; } = new();
}
