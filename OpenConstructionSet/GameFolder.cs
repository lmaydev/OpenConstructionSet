using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenConstructionSet
{
    /// <summary>
    /// Represents and folder that contains mods.
    /// </summary>
    public class GameFolder
    {
        /// <summary>
        /// Used to specify the type.
        /// </summary>
        public GameFolderType Type { get; }

        /// <summary>
        /// The full path of the folder.
        /// </summary>
        public string FolderPath { get; }

        public IDictionary<string, string> Mods { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Returns the full path of a mod from its' name.
        /// </summary>
        /// <param name="mod">The file name of the mod. e.g. example.mod</param>
        /// <returns>The full path of a mod file.</returns>
        public string GetFullPath(string mod)
        {
            switch (Type)
            {
                case GameFolderType.Data:
                    return GetBasePath(mod);

                case GameFolderType.Mod:
                    return GetModPath(mod);

                default:
                    throw new InvalidOperationException($"Invalid {nameof(GameFolderType)} ({Type})");
            }
        }

        /// <summary>
        /// Deletes the given mod if it exists.
        /// </summary>
        /// <param name="mod">The file name of the mod. e.g. example.mod</param>
        public void Delete(string mod)
        {
            switch (Type)
            {
                case GameFolderType.Data:
                    File.Delete(GetBasePath(mod));
                    break;

                case GameFolderType.Mod:
                    Directory.Delete(GetModFolder(mod), true);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid {nameof(GameFolderType)} ({Type})");
            }
        }

        private string GetModFolder(string mod) => Path.Combine(FolderPath, Path.GetFileNameWithoutExtension(mod));

        private string GetModPath(string mod) => Path.Combine(GetModFolder(mod), mod);

        private string GetBasePath(string mod) => Path.Combine(FolderPath, mod);

        public GameFolder(string folder, GameFolderType type)
        {
            FolderPath = folder;
            Type = type;

            LoadMods();
        }

        public void LoadMods()
        {
            Mods.Clear();

            switch (Type)
            {
                case GameFolderType.Data:
                    foreach (var file in Directory.GetFiles(FolderPath, "*.mod").Union(Directory.GetFiles(FolderPath, "*.base")))
                    {
                        Mods.Add(Path.GetFileName(file), file);
                    }
                    break;
                case GameFolderType.Mod:
                    foreach (var folder in new DirectoryInfo(FolderPath).GetDirectories())
                    {
                        var mod = folder.Name + ".mod";

                        Mods.Add(mod, Path.Combine(folder.FullName, mod)); 
                    }
                    break;
                default:
                    break;
            }
        }
    }
}