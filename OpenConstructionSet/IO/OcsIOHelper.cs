using System.Xml.Serialization;

namespace OpenConstructionSet.IO;

public static class OcsIOHelper
{
    public static string GetInfoFileName(string mod)
    {
        var folder = Path.GetDirectoryName(mod) ?? "";

        var name = Path.GetFileNameWithoutExtension(mod);

        return Path.Combine(folder, $"_{name}.info");
    }

    public static void WriteInfo(this ModInfo info, Stream stream) => new XmlSerializer(typeof(ModInfo)).Serialize(stream, info);

    public static ModInfo? ReadInfo(Stream stream) => new XmlSerializer(typeof(ModInfo)).Deserialize(stream) as ModInfo;

    internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
}
