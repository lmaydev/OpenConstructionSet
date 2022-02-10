namespace OpenConstructionSet.Mods;

/// <summary>
/// Represents a mod file.
/// Provides methods for reading and writing the various asociated files and data.
/// </summary>
public interface IModFile
{
    /// <summary>
    /// The filename of the mod file.
    /// e.g. example.mod
    /// </summary>
    string Filename { get; }

    /// <summary>
    /// The name of the mod file.
    /// e.g. example
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The path of the mod file.
    /// e.g. \path\to\the\mod\example.mod
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Reads the data of this <see cref="IModFile"/>.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The data contained within the <see cref="IModFile"/>.</returns>
    Task<ModFileData> ReadDataAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Reads the <see cref="Header"/> of this <see cref="IModFile"/>.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The <see cref="Header"/> contained within the <see cref="IModFile"/>.</returns>
    Task<Header> ReadHeaderAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Reads the .info file of this <see cref="IModFile"/>.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The data contained within the <see cref="IModFile"/>'s .info file.</returns>
    Task<ModInfoData?> ReadInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes the provided data to the <see cref="IModFile"/>.
    /// </summary>
    /// <param name="data">The data to write to the <see cref="IModFile"/>.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>An awaitable <c>Task</c>.</returns>
    Task WriteDataAsync(ModFileData data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes the provided header to the <see cref="IModFile"/>.
    /// </summary>
    /// <param name="header">The <see cref="Header"/> to write to the <see cref="IModFile"/>.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>An awaitable <c>Task</c>.</returns>
    Task WriteHeaderAsync(Header header, CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes the provided info to the <see cref="IModFile"/>'s .info file.
    /// </summary>
    /// <param name="info">The <see cref="ModInfoData"/> to write to the <see cref="IModFile"/>.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>An awaitable <c>Task</c>.</returns>
    Task WriteInfoAsync(ModInfoData info, CancellationToken cancellationToken = default);
}
