using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenConstructionSet.IO
{
    /// <summary>
    /// Representation of a mod folder.
    /// Provides methods for discovery and working with the contained mods.
    /// </summary>
    public class ModFolder
    {
        /// <summary>
        /// The full path of the folder.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// A collection of mods in the folder, keyed by the mods name (e.g. example.mod)
        /// </summary>
        public Dictionary<string, ModFile> Mods { get; set; } = new();

        public ModFolder(string fullName)
        {
            FullName = fullName;
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
                path = new FileInfo(Mods[mod].FullName);
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

            if (directory.GetFiles("*.mod").Length == 1)
            {
                // Individual mod folder so delete everything
                directory.Delete(true);
            }
            else
            {
                // Installation/data folder so only delete file
                path.Delete();
            }
        }

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
                return Mods[mod].FullName;
            }

            return GetModPath(mod);
        }

        private string GetModFolder(string mod) => Path.Combine(FullName, Path.GetFileNameWithoutExtension(mod));

        private string GetModPath(string mod) => Path.Combine(GetModFolder(mod), mod.AddModExtension());

        /// <summary>
        /// Attempts to discover the mods and data folders relative to the working directory.
        /// </summary>
        /// <returns>A <c>ModFolders</c> instance containing the local folders if found; otherwise, <c>null</c></returns>
        public static ModFolders? DiscoverLocalFolders()
        {
            var folders = new ModFolders();

            var data = new DirectoryInfo("data\\");

            if (data.Exists)
            {
                folders.Data = Discover(data);
            }

            var mods = new DirectoryInfo("mods\\");

            if (mods.Exists)
            {
                folders.Mod = Discover(mods);
            }

            if (folders.Data == null && folders.Mod == null)
            {
                return null;
            }

            return folders;
        }

        /// <summary>
        /// Search the given folder for mods.
        /// </summary>
        /// <param name="folder">Path of the folder to search.</param>
        /// <returns>A <c>ModFolder</c> containing all discovered mods.</returns>
        public static ModFolder Discover(string folder) => Discover(new DirectoryInfo(folder));

        /// <summary>
        /// Search the given folder for mods.
        /// </summary>
        /// <param name="folder">The folder to search.</param>
        /// <returns>A <c>ModFolder</c> containing all discovered mods.</returns>
        public static ModFolder Discover(DirectoryInfo folder)
        {
            var result = new ModFolder(folder.FullName);

            AddRange(folder.GetFiles("*.mod").Select(ModFile.Discover));
            AddRange(folder.GetFiles("*.base").Select(ModFile.Discover));
            AddRange(folder.GetDirectories().SelectMany(d => d.GetFiles("*.mod").Select(ModFile.Discover)));

            return result;

            void AddRange(IEnumerable<ModFile> mods)
            {
                foreach (var mod in mods)
                {
                    result.Mods.Add(mod.Name, mod);
                }
            }
        }

        public static IEnumerable<ModFolder> Discover(IEnumerable<string> folders)
        {
            foreach (var folder in folders.Select(f => new DirectoryInfo(f)).Where(d => d.Exists))
            {
                yield return Discover(folder);
            }
        }
    }
}
