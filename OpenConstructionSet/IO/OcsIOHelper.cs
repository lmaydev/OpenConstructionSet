using System.Xml.Serialization;

namespace OpenConstructionSet.IO;

/// <summary>
/// A collection of helper functions for dealing with the game's files.
/// </summary>
public static class OcsIOHelper
{
    /// <summary>
    /// Gets the path of the info file for the given mod file.
    /// </summary>
    /// <param name="mod">The file to get the info file name for.</param>
    /// <returns>The path of the info file for the specified mod.</returns>
    public static string GetInfoPath(string mod)
    {
        var folder = Path.GetDirectoryName(mod) ?? "";

        var name = Path.GetFileNameWithoutExtension(mod);

        return Path.Combine(folder, $"_{name}.info");
    }

    /// <summary>
    /// Write the mod info to the stream.
    /// </summary>
    /// <param name="info">Mod info to be written.</param>
    /// <param name="stream">Stream to write to.</param>
    public static void WriteInfo(this ModInfo info, Stream stream) => new XmlSerializer(typeof(ModInfo)).Serialize(stream, info);

    /// <summary>
    /// Read the mod info from the given stream.
    /// </summary>
    /// <param name="stream">Stream to read from.</param>
    /// <returns>The mod info read from the stream.</returns>
    public static ModInfo? ReadInfo(Stream stream) => new XmlSerializer(typeof(ModInfo)).Deserialize(stream) as ModInfo;

    /// <summary>
    /// Returns the full path of a mod from its' name.
    /// If the mod has been discovered it's path will be used.
    /// If not the path will be created using the folder and mod.
    /// </summary>
    /// <param name="folder">The mod folder.</param>
    /// <param name="mod">The file name of the mod. e.g. example.mod</param>
    /// <returns>The full path of a mod file.</returns>
    public static string GetModPath(ModFolder folder, string mod)
    {
        mod = mod.AddModExtension();

        return folder.Mods.ContainsKey(mod) ? folder.Mods[mod].FullName : GetModPath(folder.FullName, mod);
    }

    /// <summary>
    /// Get the full path for the named mod in the given folder.
    /// </summary>
    /// <param name="folder">The folder that will contain the mod.</param>
    /// <param name="mod">The name of the mod e.g. example.mod</param>
    /// <returns>The path of thge named mod in the given folder.</returns>
    public static string GetModPath(string folder, string mod) => Path.Combine(folder, Path.GetFileNameWithoutExtension(mod), mod.AddModExtension());

    /// <summary>
    /// Attempts to read the header of the given mod file.
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    public static Header? ReadHeader(OcsReader reader) => (FileType)reader.ReadInt() == FileType.Mod ? reader.ReadHeader() : null;

    /// <summary>
    /// Reads the full mod file referenced by the reader.
    /// </summary>
    /// <param name="reader">Used to read the mod file.</param>
    /// <returns>The header, last id and items from the mod.</returns>
    /// <exception cref="InvalidDataException">Not a mod file</exception>
    public static (Header header, int lastId, Dictionary<string, Item> items) ReadMod(this OcsReader reader)
    {
        var type = (FileType)reader.ReadInt();

        return type == FileType.Mod
            ? (reader.ReadHeader(), reader.ReadInt(), reader.ReadItems().ToDictionary(i => i.StringId))
            : throw new InvalidDataException("Not a mod file");
    }

    /// <summary>
    /// Write the mod to the given writer.
    /// </summary>
    /// <param name="writer">Used to write the mod.</param>
    /// <param name="header">The header of the mod.</param>
    /// <param name="lastId">The LastId used.</param>
    /// <param name="items">Collection of items from the mod.</param>
    public static void WriteMod(this OcsWriter writer, Header? header, int lastId, IEnumerable<Item> items)
    {
        writer.Write((int)FileType.Mod);

        writer.Write(header ?? new());

        writer.Write(lastId);

        writer.Write(items);
    }

    /// <summary>
    /// Reads the save file referenced by the reader.
    /// </summary>
    /// <param name="reader">Used to read the save file.</param>
    /// <returns>The last id and items from the save file.</returns>
    /// <exception cref="InvalidDataException">Not a save file</exception>
    public static (int lastId, Dictionary<string, Item> items) ReadSave(this OcsReader reader)
    {
        var type = (FileType)reader.ReadInt();

        return type == FileType.Save
            ? (reader.ReadInt(), reader.ReadItems().ToDictionary(i => i.StringId))
            : throw new InvalidDataException("Not a save file");
    }

    /// <summary>
    /// Write the save file to the given writer.
    /// </summary>
    /// <param name="writer">Used to write the save.</param>
    /// <param name="lastId">The LastId used.</param>
    /// <param name="items">Collection of items from the mod.</param>
    public static void WriteSave(this OcsWriter writer, int lastId, IEnumerable<Item> items)
    {
        writer.Write((int)FileType.Save);

        writer.Write(lastId);

        writer.Write(items);
    }

    /// <summary>
    /// Determines if the mod is in a standard folder structure. 
    /// </summary>
    /// <param name="mod">The name of the mod e.g. example.mod</param>
    /// <returns><c>true</c> if the mod is in a standard folder structure.</returns>
    public static bool CorrectModFolder(this ModFile mod)
    {
        var directory = Path.GetDirectoryName(mod.FullName);

        // Individual mod folder or content folder
        return directory == mod.Info?.Id.ToString() || directory == mod.Name;
    }

    internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
}
