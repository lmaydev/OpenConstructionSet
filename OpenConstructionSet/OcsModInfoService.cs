using OpenConstructionSet.Models;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace OpenConstructionSet
{
    public class OcsModInfoService : IOcsModInfoService
    {
        private static readonly Lazy<OcsModInfoService> _default = new(() => new());

        public static OcsModInfoService Default
        {
            get => _default.Value;
        }

        public string GetInfoFileName(string modPath)
        {
            var folder = Path.GetDirectoryName(modPath);

            if (folder is null)
            {
                throw new ArgumentException("Could not determine directory for file \"{modPath}\"", nameof(modPath));
            }

            var name = Path.GetFileNameWithoutExtension(modPath);

            return Path.Combine(folder, $"_{name}.info");
        }

        public void Write(string path, ModInfo info, bool modPath = false)
        {
            if (modPath)
            {
                path = GetInfoFileName(path);
            }

            using var stream = File.OpenWrite(path);

            new XmlSerializer(typeof(ModInfo)).Serialize(stream, info);
        }

        public bool TryWrite(string path, ModInfo info, bool modPath = false)
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

        public ModInfo? Read(string path, bool modPath = false)
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

            var value = new XmlSerializer(typeof(ModInfo)).Deserialize(stream);

            if (value is not null && value is ModInfo info)
            {
                return info;
            }

            return null;
        }

        public bool TryRead(string path, [MaybeNullWhen(false)] out ModInfo info, bool modPath = false)
        {
            try
            {
                info = Read(path, modPath)!;
                return info is not null;
            }
            catch
            {
                info = null;
                return false;
            }
        }
    }
}
