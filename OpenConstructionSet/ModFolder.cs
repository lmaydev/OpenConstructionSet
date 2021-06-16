using System;
using System.IO;

namespace OpenConstructionSet
{
    public class ModFolder
    {
        public ModFolderType Type { get; set; }

        public string FolderPath { get; set; }

        public string GetFullFilename(string filename)
        {
            switch (Type)
            {
                case ModFolderType.Base:
                    return GetBasePath(filename);

                case ModFolderType.Mod:
                    return GetModPath(filename);

                default:
                    throw new InvalidOperationException($"Invalid {nameof(ModFolderType)} ({Type})");
            }
        }

        public void Delete(string filename)
        {
            switch (Type)
            {
                case ModFolderType.Base:
                    File.Delete(GetBasePath(filename));
                    break;

                case ModFolderType.Mod:
                    Directory.Delete(GetModFolder(filename), true);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid {nameof(ModFolderType)} ({Type})");
            }
        }

        private string GetModFolder(string filename) => Path.Combine(FolderPath, Path.GetFileNameWithoutExtension(filename));

        private string GetModPath(string filename) => Path.Combine(GetModFolder(filename), filename);

        private string GetBasePath(string filename) => Path.Combine(FolderPath, filename);

        private ModFolder(string folderPath, ModFolderType type)
        {
            FolderPath = folderPath;
            Type = type;
        }

        public static ModFolder Mod(string folderPath) => new ModFolder(folderPath, ModFolderType.Mod);

        public static ModFolder Base(string folderPath) => new ModFolder(folderPath, ModFolderType.Base);
    }
}