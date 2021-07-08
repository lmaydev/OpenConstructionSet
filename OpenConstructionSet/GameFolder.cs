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

        /// <summary>
        /// Collection of mod paths key'd to their filename.
        /// Call <see cref="Populate"/> to refresh this collection from disk.
        /// </summary>
        public IDictionary<string, string> Mods { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Returns the full path of a mod from its' name.
        /// </summary>
        /// <param name="mod">The file name of the mod. e.g. example.mod</param>
        /// <returns>The full path of a mod file.</returns>
        public string GetFullPath(string mod)
        {
            mod = mod.AddModExtension();

            switch (Type)
            {
                case GameFolderType.Data:
                    return GetBasePath(mod);

                case GameFolderType.Mod:
                case GameFolderType.Both:
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
            mod = mod.AddModExtension();

            if ((Type & GameFolderType.Mod) != 0)
            {
                var dir = GetModPath(mod);

                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
            }

            if ((Type & GameFolderType.Data) != 0)
            {
                File.Delete(GetBasePath(mod));
            }
        }

        private string GetModFolder(string mod) => Path.Combine(FolderPath, Path.GetFileNameWithoutExtension(mod));

        private string GetModPath(string mod) => Path.Combine(GetModFolder(mod), mod);

        private string GetBasePath(string mod) => Path.Combine(FolderPath, mod);

        /// <summary>
        /// Constructs a <c>GameFolder</c>.
        /// </summary>
        /// <param name="folder">Path of the folder.</param>
        /// <param name="type">The <see cref="GameFolderType"/> determines how mods are loaded from the folder.</param>
        /// <param name="populate">If <c>true</c> the <see cref="Mods"/> property will be populated from disk.</param>
        public GameFolder(string folder, GameFolderType type, bool populate = true)
        {
            FolderPath = folder;
            Type = type;

            if (populate)
            {
                Populate();
            }
        }

        /// <summary>
        /// Refresh the <see cref="Mods"/> property from disk.
        /// </summary>
        public void Populate()
        {
            Mods.Clear();

            if (!Directory.Exists(FolderPath))
            {
                return;
            }

            if ((Type & GameFolderType.Mod) != 0)
            {
                foreach (var folder in new DirectoryInfo(FolderPath).GetDirectories())
                {
                    var mod = folder.Name + ".mod";

                    var path = Path.Combine(folder.FullName, mod);

                    if (File.Exists(path))
                    {
                        Mods.Add(mod, path);
                    }
                }
            }

            if ((Type & GameFolderType.Data) != 0)
            {
                foreach (var file in Directory.GetFiles(FolderPath, "*.mod").Union(Directory.GetFiles(FolderPath, "*.base")))
                {
                    Mods.Add(Path.GetFileName(file), file);
                }
            }
        }
    }
}