namespace OpenConstructionSet.Data;

/// <inheritdoc/>
public class DataFile : IDataFile
{
    /// <summary>
    /// Creates a new <see cref="DataFile"/> from the given path.
    /// </summary>
    /// <param name="path">The path of the data file e.g. \path\to\file\example.ext</param>
    public DataFile(string path)
    {
        Path = path;
        Filename = System.IO.Path.GetFileName(path);
        Name = System.IO.Path.GetFileNameWithoutExtension(path);
    }

    /// <inheritdoc/>
    public string Filename { get; }

    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc/>
    public string Path { get; }

    /// <inheritdoc/>
    public virtual async Task<DataFileData> ReadDataAsync(CancellationToken cancellationToken = default)
    {
        var buffer = await File.ReadAllBytesAsync(Path, cancellationToken).ConfigureAwait(false);

        using var reader = new OcsReader(buffer);

        var type = (DataFileType)reader.ReadInt();
        var header = type.IsModType() ? reader.ReadHeader(type) : null;
        var lastId = reader.ReadInt();

        return new(type, header, lastId, reader.ReadItems());
    }

    /// <inheritdoc/>
    public virtual Task WriteDataAsync(DataFileData data, CancellationToken cancellationToken = default)
    {
        using var writer = new OcsWriter(File.OpenWrite(Path));

        writer.Write((int)data.Type);

        if (data.Type.IsModType())
        {
            writer.Write(data.Header ?? new Header());
        }

        writer.Write(data.LastId);
        writer.Write(data.Items);

        return Task.CompletedTask;
    }
}
