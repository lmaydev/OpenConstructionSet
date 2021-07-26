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

            if (Mods.ContainsKey(mod))
            {
                return Mods[mod];
            }

            return GetModPath(mod);
        }

        /// <summary>
        /// Deletes the given mod if it exists.
        /// </summary>
        /// <param name="mod">The file name of the mod. e.g. example.mod</param>
        public void Delete(string mod)
        {
            mod = mod.AddModExtension();

            FileInfo path;

            if (Mods.ContainsKey(mod))
            {
                path = new FileInfo(Mods[mod]);
            }
            else
            {
                path = new FileInfo(GetModPath(mod));
            }

            if (!path.Exists)
            {
                return;
            }

            var directory = path.Directory;

            if (directory.Name.Equals(Path.GetFileNameWithoutExtension(path.Name), StringComparison.OrdinalIgnoreCase))
            {
                directory.Delete(true);
            }
            else
            {
                path.Delete();
            }
        }

        private string GetModFolder(string mod) => Path.Combine(FolderPath, Path.GetFileNameWithoutExtension(mod));

        private string GetModPath(string mod) => Path.Combine(GetModFolder(mod), mod.AddModExtension());

        /// <summary>
        /// Constructs a <c>GameFolder</c>.
        /// </summary>
        /// <param name="folder">Path of the folder.</param>
        /// <param name="populate">If <c>true</c> the <see cref="Mods"/> property will be populated from disk.</param>
        public GameFolder(string folder, bool populate = true)
        {
            FolderPath = folder;

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

            var folderInfo = new DirectoryInfo(FolderPath);

            // Add all .mod and .base files in the root of the folder
            foreach (var file in folderInfo.GetFiles("*.mod").Union(folderInfo.GetFiles("*.base")))
            {
                Mods.Add(file.Name, file.FullName);
            }

            // Add all .mod files in sub folders
            foreach (var file in folderInfo.GetDirectories().SelectMany(d => d.GetFiles("*.mod")))
            {
                Mods.Add(file.Name, file.FullName);
            }
        }
    }
}