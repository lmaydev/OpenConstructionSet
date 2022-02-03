namespace OpenConstructionSet.Data;

/// <summary>
/// Representation of a data file.
/// Provides methods for reading and writing to the file.
/// </summary>
public interface IDataFile
{
    /// <summary>
    /// The filename of the data file e.g. example.ext
    /// </summary>
    string Filename { get; }

    /// <summary>
    /// The name of the data file e.g. example
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The path of the data file e.g. \path\to\file\example.ext
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Reads the data from the file.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The data stored in the file.</returns>
    Task<DataFileData> ReadDataAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Writes the provided data to the file.
    /// </summary>
    /// <param name="data">The data to write to file.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>An awaitable task.</returns>
    Task WriteDataAsync(DataFileData data, CancellationToken cancellationToken = default);
}
