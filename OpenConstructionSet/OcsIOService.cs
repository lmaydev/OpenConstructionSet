using System;
using System.Collections.Generic;
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
    public void Write(OcsWriter writer, DataFile data)
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
    public void Write(Stream stream, ModInfo info) => new XmlSerializer(typeof(ModInfo)).Serialize(stream, info);

    /// <inheritdoc />
    public void Write(string file, IEnumerable<string> enabledMods) => File.WriteAllLines(file, enabledMods);

    /// <inheritdoc />
    public ModInfo? ReadInfo(Stream stream) => new XmlSerializer(typeof(ModInfo)).Deserialize(stream) as ModInfo;

    /// <inheritdoc />
    public List<string>? ReadEnabledMods(string file) => File.Exists(file) ? File.ReadAllLines(file).ToList() : null;

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
