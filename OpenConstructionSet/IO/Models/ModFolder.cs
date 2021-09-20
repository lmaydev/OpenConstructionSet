namespace OpenConstructionSet.IO;

/// <summary>
/// Representation of a mod folder.
/// Provides methods for discovery and working with the contained mods.
/// </summary>
public class ModFolder : IEquatable<ModFolder?>
{
    /// <summary>
    /// The full path of the folder.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// A collection of mods in the folder, keyed by the mods name (e.g. example.mod)
    /// </summary>
    public Dictionary<string, ModFile> Mods { get; set; } = new();

    public ModFolder(string fullName) => FullName = fullName;

    public override bool Equals(object? obj) => Equals(obj as ModFolder);

    public bool Equals(ModFolder? other) => other != null &&
               FullName == other.FullName;

    public override int GetHashCode() => 733961487 + EqualityComparer<string>.Default.GetHashCode(FullName);

    public static bool operator ==(ModFolder? left, ModFolder? right) => EqualityComparer<ModFolder?>.Default.Equals(left, right);

    public static bool operator !=(ModFolder? left, ModFolder? right) => !(left == right);
}
