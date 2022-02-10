using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations;

/// <summary>
/// Representation of an installation of the game.
/// </summary>
public interface IInstallation
{
    /// <summary>
    /// An Optional content <see cref="IModFolder"/>.
    /// Currently used for the Steam Workshop folder.
    /// </summary>
    IModFolder? Content { get; }

    /// <summary>
    /// A <see cref="IModFolder"/> for the game's data folder.
    /// </summary>
    IModFolder Data { get; }

    /// <summary>
    /// The path of the file that stores the enabled mods.
    /// </summary>
    string EnabledModsFile { get; }

    /// <summary>
    /// Identifier of this <see cref="IInstallation"/>.
    /// </summary>
    string Identifier { get; }

    /// <summary>
    /// A <see cref="IModFolder"/> for the game's mods folder.
    /// </summary>
    IModFolder Mods { get; }

    /// <summary>
    /// The path of this <see cref="IInstallation"/>.
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Search all <see cref="IModFolder"/>s for mods.
    /// Searches in the order Data, Mod, Content (if not null).
    /// </summary>
    /// <returns>A collection of <see cref="IModFile"/>s for the <see cref="IInstallation"/>.</returns>
    IEnumerable<IModFile> GetMods();

    /// <summary>
    /// Reads the <see cref="EnabledModsFile"/> to get the currently enabled mod's filenames and their load order.
    /// e.g. example.mod
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A collection of mod filenames for the currently enabled mods in load order.</returns>
    Task<string[]> ReadEnabledModsAsync(CancellationToken cancellationToken = default);

    bool TryFind(string modName, uint id, [MaybeNullWhen(false)] out IModFile file);

    bool TryFind(string modName, [MaybeNullWhen(false)] out IModFile file);

    /// <summary>
    /// Writes the provided list of mod filename's to the <see cref="EnabledModsFile"/>.
    /// e.g. example.mod
    /// </summary>
    /// <param name="enabledMods">Collection of m od filenames e.g. example.mod</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>An awaitable <see cref="Task"/>.</returns>
    Task WriteEnabledModsAsync(IEnumerable<string> enabledMods, CancellationToken cancellationToken = default);
}
