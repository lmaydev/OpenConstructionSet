namespace OpenConstructionSet.Models;

/// <summary>
/// Representation of a mod folder.
/// Provides methods for discovery and working with the contained mods.
/// </summary>
public record ModFolder(string FullName, Dictionary<string, ModFile> Mods);
