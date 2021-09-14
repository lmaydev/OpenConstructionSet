using OpenConstructionSet.Models;
using System.IO;
using System.Xml.Serialization;

namespace OpenConstructionSet.IO
{
    public static class OcsModInfoFile
    {
        public static string GetInfoFileName(string modPath)
        {
            var folder = Path.GetDirectoryName(modPath);

            var name = Path.GetFileNameWithoutExtension(modPath);

            return Path.Combine(folder, $"_{name}.info");
        }

        public static void Write(string path, ModInfo info, bool modPath = false)
        {
            if (modPath)
            {
                path = GetInfoFileName(path);
            }

            using var stream = File.OpenWrite(path);

            new XmlSerializer(typeof(ModInfo)).Serialize(stream, info);
        }

        public static bool TryWrite(string path, ModInfo info, bool modPath = false)
        {
            try
            {
                Write(path, info, modPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ModInfo? Read(string path, bool modPath = false)
        {
            if (modPath)
            {
                path = GetInfoFileName(path);
            }

            if (!File.Exists(path))
            {
                return null;
            }

            using var stream = File.OpenRead(path);

            return (ModInfo)new XmlSerializer(typeof(ModInfo)).Deserialize(stream);
        }

        public static bool TryRead(string path, out ModInfo info, bool modPath = false)
        {
            try
            {
                info = Read(path, modPath)!;
                return info is not null;
            }
            catch
            {
                info = null!;
                return false;
            }
        }
    }
}
