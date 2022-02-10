using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations
{
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
        /// Gets the full path of the provided mod name or filename.
        /// e.g. example.mod or example
        /// </summary>
        /// <param name="modName">The mod's name or filename. e.g. example.mod or example</param>
        /// <param name="modId">The Id from the mod's info file. This is only required for <see cref="ModFolderType.Content"/>.</param>
        /// <returns>Thge full path of the provided mod.</returns>
        string GetModPath(string modName, uint modId = 0);

        /// <summary>
        /// Search the <see cref="IModFolder"/> for mods.
        /// </summary>
        /// <returns>A collection of <see cref="IModFile"/>s for the <see cref="IModFolder"/>.</returns>
        IEnumerable<IModFile> GetMods();

        bool TryFind(string modName, uint id, [MaybeNullWhen(false)] out IModFile file);

        bool TryFind(string modName, [MaybeNullWhen(false)] out IModFile file);
    }
}
