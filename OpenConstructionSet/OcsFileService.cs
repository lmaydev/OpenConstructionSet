using OpenConstructionSet.IO;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet;

public class OcsFileService : IOcsFileService
{
    private static readonly Lazy<OcsFileService> _default = new(() => new());

    public static OcsFileService Default => _default.Value;

    public void Write(OcsWriter writer, Header? header, int lastId, IEnumerable<Item> items)
    {
        writer.Write((int)FileType.Mod);

        writer.Write(header ?? new Header(1, "", ""));

        writer.Write(lastId);

        writer.Write(items);
    }

    public Header ReadHeader(OcsReader reader) => (FileType)reader.ReadInt() == FileType.Mod ? reader.ReadHeader() :
        throw new InvalidOperationException("The specified file is not a mod");

    public bool TryReadHeader(OcsReader reader, [MaybeNullWhen(false)] out Header header)
    {
        try
        {
            header = ReadHeader(reader);
            return true;
        }
        catch
        {
            header = null;
            return false;
        }
    }

    public bool Delete(ModFolder folder, string mod)
    {
        mod = mod.AddModExtension();

        if (!folder.Mods.TryGetValue(mod, out var file))
        {
            return false;
        }

        Delete(file);

        return true;
    }

    public bool Delete(ModFile file)
    {
        if (!File.Exists(file.FullName))
        {
            return false;
        }

        var directory = Path.GetDirectoryName(file.FullName);

        if (string.IsNullOrEmpty(directory))
        {
            return false;
        }

        // individual mod folder, burn it all
        if (directory == file.Info?.Id.ToString() || directory == Path.GetFileNameWithoutExtension(file.Name))
        {
            Directory.Delete(directory, true);
        }
        else
        {
            // Installation/data folder so only delete file
            File.Delete(file.FullName);
        }

        return true;
    }

    /// <summary>
    /// Returns the full path of a mod from its' name.
    /// If the mod has been discovered it's path will be used.
    /// If not the path will be created using the folder and mod path.
    /// </summary>
    /// <param name="modName">The file name of the mod. e.g. example.mod</param>
    /// <returns>The full path of a mod file.</returns>
    public string GetPath(ModFolder folder, string modName)
    {
        modName = modName.AddModExtension();

        return folder.Mods.ContainsKey(modName) ? folder.Mods[modName].FullName : GetPath(folder.FullName, modName);
    }

    private string GetPath(string folder, string modName) => Path.Combine(folder, Path.GetFileNameWithoutExtension(modName), modName.AddModExtension());
}
