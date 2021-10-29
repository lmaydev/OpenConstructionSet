using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenConstructionSet;

/// <inheritdoc />
public class OcsIOService : IOcsIOService
{
    private static readonly Lazy<OcsIOService> _default = new(() => new());

    /// <summary>
    /// Lazy initiated singleton for when DI is not being used
    /// </summary>
    public static OcsIOService Default => _default.Value;

    /// <inheritdoc />
    public Header? ReadHeader(OcsReader reader) => (DataFileType)reader.ReadInt() == DataFileType.Mod ? reader.ReadHeader() : null;

    /// <inheritdoc />
    public DataFile? ReadDataFile(OcsReader reader)
    {
        var type = (DataFileType)reader.ReadInt();

        var header = type == DataFileType.Mod ? reader.ReadHeader() : null;

        var lastId = reader.ReadInt();

        var items = reader.ReadItems().ToList();

        return new(type, header, lastId, items);
    }

    /// <inheritdoc />
    public void Write(DataFile data, OcsWriter writer)
    {
        writer.Write((int)data.Type);

        if (data.Type == DataFileType.Mod)
        {
            writer.Write(data.Header ?? new());
        }

        writer.Write(data.LastId);
        writer.Write(data.Items);
    }

    /// <inheritdoc />
    public void Write(ModInfo info, Stream stream) => new XmlSerializer(typeof(ModInfo)).Serialize(stream, info);

    /// <inheritdoc />
    public ModInfo? ReadInfo(Stream stream) => new XmlSerializer(typeof(ModInfo)).Deserialize(stream) as ModInfo;

    /// <inheritdoc />
    public string[]? ReadEnabledMods(string file) => File.Exists(file) ? File.ReadAllLines(file) : null;

    /// <inheritdoc />
    public void SaveEnabledMods(string file, IEnumerable<string> enabledMods) => File.WriteAllLines(file, enabledMods);

    /// <inheritdoc />
    public void SaveEnabledMods(Installation installation)
    {
        var folder = installation.Data.FullName;

        if (!Directory.Exists(folder))
        {
            return;
        }

        var path = Path.Combine(folder, "mods.cfg");

        File.Delete(path);
        File.WriteAllLines(path, installation.EnabledMods);
    }
}

/// <summary>
/// Collection of wrapper function for the IO service.
/// Implemented as extension methods because they wrap a single method and this way they don't have to be added to the interface.
/// </summary>
public static class OcsIOExtensions
{
    private static bool TryOpenRead(string file, [MaybeNullWhen(false)] out Stream stream)
    {
        if (!File.Exists(file))
        {
            stream = null;
            return false;
        }

        stream = File.OpenRead(file);
        return true;
    }

    private static bool TryReadAll(string file, [MaybeNullWhen(false)] out byte[] data)
    {
        if (!File.Exists(file))
        {
            data = null;
            return false;
        }

        data = File.ReadAllBytes(file);
        return true;
    }

    private static bool TryCreateFile(string file, [MaybeNullWhen(false)] out Stream stream)
    {
        if (File.Exists(file))
        {
            File.Delete(file);
        }

        stream = File.Create(file);
        return true;
    }

    /// <summary>
    /// Write the <c>DataFile</c> to the specified file.
    /// </summary>
    /// <param name="service">Service to wrap.</param>
    /// <param name="data">The data to write to file.</param>
    /// <param name="file">The file to write to.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c></returns>
    public static bool Write(this IOcsIOService service, DataFile data, string file)
    {
        if (!TryCreateFile(file, out var stream))
        {
            return false;
        }

        using var writer = new OcsWriter(stream);

        service.Write(data, writer);

        return true;
    }

    /// <summary>
    /// Write the mod info file data to the specified file.
    /// </summary>
    /// <param name="service">Service to wrap.</param>
    /// <param name="info">The mod inf file data to write.</param>
    /// <param name="file">The file to write to.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c></returns>
    public static bool Write(this IOcsIOService service, ModInfo info, string file)
    {
        if (!TryCreateFile(file, out var stream))
        {
            return false;
        }

        service.Write(info, stream);

        stream.Dispose();

        return true;
    }

    /// <summary>
    /// Attempts to read the header of the provided file.
    /// </summary>
    /// <param name="service">Service to wrap.</param>
    /// <param name="file">The file to read.</param>
    /// <returns>The file's header if readable; otherwise, <c>null</c>.</returns>
    public static Header? ReadHeader(this IOcsIOService service, string file)
    {
        if (!TryOpenRead(file, out var stream))
        {
            return null;
        }

        using var reader = new OcsReader(stream);

        return service.ReadHeader(reader);
    }

    /// <summary>
    /// Attempts to read the specified data file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="file">The file to read.</param>
    /// <returns>A <c>DataFile</c> read from the file if readable; otherwise; <c>null</c>.</returns>
    public static DataFile? ReadDataFile(this IOcsIOService service, string file) => TryReadAll(file, out var data) ? service.ReadDataFile(new OcsReader(data)) : null;

    /// <summary>
    /// Attempts to read the provided mod info file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="file">The file to read.</param>
    /// <returns>A <c>ModInfo</c> read from the file if readable; otherwise, <c>null</c></returns>
    public static ModInfo? ReadInfo(this IOcsIOService service, string file)
    {
        if (!TryOpenRead(file, out var stream))
        {
            return null;
        }
        using (stream)
        {
            return service.ReadInfo(stream);
        }
    }
}
