using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace OpenConstructionSet.IO;

public static class OcsIOHelper
{
    public static string GetInfoPath(string mod)
    {
        var folder = Path.GetDirectoryName(mod) ?? "";

        var name = Path.GetFileNameWithoutExtension(mod);

        return Path.Combine(folder, $"_{name}.info");
    }

    public static void WriteInfo(this ModInfo info, Stream stream) => new XmlSerializer(typeof(ModInfo)).Serialize(stream, info);

    public static ModInfo? ReadInfo(Stream stream) => new XmlSerializer(typeof(ModInfo)).Deserialize(stream) as ModInfo;

    /// <summary>
    /// Returns the full path of a mod from its' name.
    /// If the mod has been discovered it's path will be used.
    /// If not the path will be created using the folder and mod.
    /// </summary>
    /// <param name="mod">The file name of the mod. e.g. example.mod</param>
    /// <returns>The full path of a mod file.</returns>
    public static string GetModPath(ModFolder folder, string mod)
    {
        mod = mod.AddModExtension();

        return folder.Mods.ContainsKey(mod) ? folder.Mods[mod].FullName : GetModPath(folder.FullName, mod);
    }

    public static string GetModPath(string folder, string mod) => Path.Combine(folder, Path.GetFileNameWithoutExtension(mod), mod.AddModExtension());

    public static Header? ReadHeader(OcsReader reader) => (FileType)reader.ReadInt() == FileType.Mod ? reader.ReadHeader() : null;

    public static void WriteMod(this OcsWriter writer, Header? header, int lastId, IEnumerable<Item> items)
    {
        writer.Write((int)FileType.Mod);

        writer.Write(header ?? new());

        writer.Write(lastId);

        writer.Write(items);
    }

    public static bool CorrectModFolder(this ModFile mod)
    {
        var directory = Path.GetDirectoryName(mod.FullName);

        // Individual mod folder or content folder
        return directory == mod.Info?.Id.ToString() || directory == mod.Name;
    }

    internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
}
