namespace OpenConstructionSet.Data
{
    public class DataFile : IDataFile
    {
        public DataFile(string path)
        {
            Path = path;
            Filename = System.IO.Path.GetFileName(path);
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
        }

        /// <summary>
        /// The mod's filename. e.g. example.mod
        /// </summary>
        public string Filename { get; }

        /// <summary>
        /// The mod's name e.g. example
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The full path of the mod file.
        /// </summary>
        public string Path { get; }

        public virtual async Task<DataFileData> ReadDataAsync(CancellationToken cancellationToken = default)
        {
            var buffer = await File.ReadAllBytesAsync(Path, cancellationToken).ConfigureAwait(false);

            using var reader = new OcsReader(buffer);

            return new((DataFileType)reader.ReadInt(), reader.ReadInt(), reader.ReadItems().ToList());
        }

        public virtual Task WriteDataAsync(DataFileData data, CancellationToken cancellationToken = default)
        {
            using var writer = new OcsWriter(File.OpenWrite(Path));

            writer.Write((int)data.Type);
            writer.Write(data.LastId);
            writer.Write(data.Items);

            return Task.CompletedTask;
        }
    }
}
