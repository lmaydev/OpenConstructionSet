namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a mod file.
/// </summary>
/// <param name="FullName">Full path of the file.</param>
/// <param name="Header">Header of the mod.</param>
/// <param name="Info">Associated information.</param>
public sealed record ModFile(string FullName, Header Header, ModInfo? Info)
{
    private string? fileName, name;

    /// <summary>
    /// The name of the file.
    /// </summary>
    public string FileName => fileName ??= Path.GetFileName(FullName);

    /// <summary>
    /// The name of the mod.
    /// </summary>
    public string Name => name ??= Path.GetFileNameWithoutExtension(FullName);
}
