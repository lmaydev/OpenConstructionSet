using System.Xml.Serialization;

namespace OpenConstructionSet.Mods
{
    /// <summary>
    /// Represents a mod file.
    /// </summary>
    public class ModFile : IModFile
    {
        /// <summary>
        /// Creates a new <c>ModFileInfo</c> instance.
        /// </summary>
        /// <param name="path">The full path of the mod file.</param>
        public ModFile(string path)
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

        public virtual async Task<ModFileData> ReadDataAsync(CancellationToken cancellationToken = default)
        {
            var buffer = await File.ReadAllBytesAsync(Path, cancellationToken).ConfigureAwait(false);

            using var reader = new OcsReader(buffer);

            var type = (DataFileType)reader.ReadInt();

            return new(reader.ReadHeader(), reader.ReadInt(), reader.ReadItems().ToList(), await ReadInfoAsync(cancellationToken).ConfigureAwait(false));
        }

        public virtual Task<Header> ReadHeaderAsync(CancellationToken cancellationToken = default)
        {
            using var reader = new OcsReader(File.OpenRead(Path));

            return Task.FromResult((DataFileType)reader.ReadInt() == DataFileType.Mod ? reader.ReadHeader() : throw new InvalidDataException("Target file is not a valid mod"));
        }

        public virtual Task<ModFileInfo?> ReadInfoAsync(CancellationToken cancellationToken = default)
        {
            var infoPath = OcsPathHelper.GetInfoPath(Path);

            if (!File.Exists(infoPath))
            {
                return Task.FromResult<ModFileInfo?>(null);
            }

            using var stream = File.OpenRead(infoPath);

            var serialiser = new XmlSerializer(typeof(ModFileInfo));

            return Task.FromResult((ModFileInfo?)serialiser.Deserialize(stream));
        }

        public override string ToString() => $"{Filename} ({Path})";

        public virtual async Task WriteDataAsync(ModFileData data, CancellationToken cancellationToken = default)
        {
            using var writer = new OcsWriter(File.OpenWrite(Path));

            writer.Write((int)DataFileType.Mod);
            writer.Write(data.Header);
            writer.Write(data.LastId);
            writer.Write(data.Items);

            if (data.Info is not null)
            {
                await WriteInfoAsync(data.Info, cancellationToken).ConfigureAwait(false);
            }
        }

        public virtual async Task WriteHeaderAsync(Header header, CancellationToken cancellationToken = default)
        {
            var data = await ReadDataAsync(cancellationToken).ConfigureAwait(false) with { Header = header };

            await WriteDataAsync(data, cancellationToken).ConfigureAwait(false);
        }

        public virtual Task WriteInfoAsync(ModFileInfo info, CancellationToken cancellationToken = default)
        {
            using var stream = File.OpenWrite(OcsPathHelper.GetInfoPath(Path));

            var serialiser = new XmlSerializer(typeof(ModFileInfo));

            serialiser.Serialize(stream, info);

            return Task.CompletedTask;
        }
    }
}
