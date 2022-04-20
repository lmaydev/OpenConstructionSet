using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations;

/// <summary>
/// Represents a folder containing mods.
/// </summary>
public interface IModFolder
{
    /// <summary>
    /// The <see cref="IModFolder"/>'s path.
    /// </summary>
    string Path { get; }

    /// <summary>
    /// The <see cref="ModFolderType"/> for this <see cref="IModFolder"/>.
    /// </summary>
    ModFolderType Type { get; }

    /// <summary>
    /// Gets the full path of the provided mod name or filename. e.g. example.mod or example
    /// </summary>
    /// <param name="modName">The mod's name or filename. e.g. example.mod or example</param>
    /// <param name="modId">
    /// The Id from the mod's info file. This is only required for <see
    /// cref="ModFolderType.Content"/> folders.
    /// </param>
    /// <returns>The full path of the provided mod.</returns>
    string GetModPath(string modName, uint modId = 0);

    /// <summary>
    /// Search the <see cref="IModFolder"/> for mods.
    /// </summary>
    /// <returns>A collection of <see cref="IModFile"/> s for the <see cref="IModFolder"/>.</returns>
    IEnumerable<IModFile> GetMods();

    /// <summary>
    /// Attempts to find the named mod in the <see cref="IModFolder"/>.
    /// </summary>
    /// <param name="modName">Name of the mod to find e.g. example or example.mod</param>
    /// <param name="file">Will contain the located <see cref="IModFile"/> if found.</param>
    /// <returns><c>true</c> if the mod could be found; otherwise, <c>false</c>.</returns>
    bool TryFind(string modName, [MaybeNullWhen(false)] out IModFile file);
}
