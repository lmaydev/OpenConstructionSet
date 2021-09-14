//using OpenConstructionSet.Data.Enums;
//using OpenConstructionSet.Data.Models;
//using OpenConstructionSet.IO;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace OpenConstructionSet
//{
//    /// <summary>
//    /// Main OpenConstructionSet helper class
//    /// </summary>
//    public static class OpenConstructionSetHelper
//    {       

//        /// <summary>
//        /// Initializes a new mod, saves it and then returns the mods full path.
//        /// </summary>
//        /// <param name="header">Contains the meta data for the mod.</param>
//        /// <param name="mod">Mod name or path</param>
//        /// <param name="folder">Folder to save mod in. If folder is <c>null</c> the game's mod folder will be used.</param>
//        /// <param name="overwrite">If <c>true</c> existing mods will be overwritten.</param>
//        /// <returns>The full path of the mod.</returns>
//        public static string NewMod(Header header, string mod, GameFolder folder = null, bool overwrite = true)
//        {
//            mod = mod.AddModExtension();

//            string path;

//            if (File.Exists(mod))
//            {
//                path = mod;
//            }
//            else
//            {
//                if (folder == null)
//                {
//                    folder = LocalFolders.Mod;
//                }

//                path = folder.GetFullPath(mod);
//            }

//            return NewMod(header, path, overwrite);
//        }

//        /// <summary>
//        /// Initializes a new mod, saves it and then returns the mods full path.
//        /// </summary>
//        /// <param name="header">Contains the meta data for the mod.</param>
//        /// <param name="path">Mod path. e.g. path\to\mod\example.mod</param>
//        /// <param name="overwrite">If <c>true</c> existing mods will be overwritten.</param>
//        /// <returns>The full path of the mod.</returns>
//        private static string NewMod(Header header, string path, bool overwrite = true)
//        {
//            if (!overwrite && File.Exists(path))
//            {
//                throw new Exception($"Mods file already exists ({path})");
//            }

//            var dataFile = new DataFile(FileType.Mod, header, 0);

//            using (var writer = new OcsWriter(path))
//            {
//                ModFile.Write(dataFile, writer);
//            }

//            return path;
//        }

//        /// <summary>
//        /// Search the provided folders to resolve a mod name (e.g. example.mod) to a full path.
//        /// </summary>
//        /// <param name="folders">Collection of <see cref="GameFolder"/>s to search.</param>
//        /// <param name="mod">The name of the mod file. e.g. example.mod.</param>
//        /// <param name="path">If resolved this parameter will be set to the mod's full path</param>
//        /// <returns>Returns <c>true</c> if the full path was resolved</returns>
//        public static bool TryResolvePath(this IEnumerable<GameFolder> folders, string mod, out string path)
//        {
//            mod = mod.AddModExtension();

//            if (System.IO.File.Exists(mod))
//            {
//                path = mod;
//                return true;
//            }

//            foreach (var folder in folders)
//            {
//                if (folder.Mods.TryGetValue(mod, out path))
//                {
//                    return true;
//                }
//            }

//            path = null;
//            return false;
//        }

//        /// <summary>
//        /// Search the provided folders to resolve the presented mods.
//        /// Mods that cannot be resolved will be dropped. Unless throwIfMissing is <c>true</c>.
//        /// </summary>
//        /// <param name="folders">Collection of <see cref="GameFolder"/>s to search.</param>
//        /// <param name="mods">Collections of the names of the mod files. e.g. example.mod.</param>
//        /// <param name="throwIfMissing">If <c>true</c> missing mods will result in an exception.</param>
//        /// <returns></returns>
//        public static IEnumerable<string> ResolvePaths(this IEnumerable<GameFolder> folders, IEnumerable<string> mods, bool throwIfMissing = false)
//        {
//            var list = new List<string>();

//            foreach (var mod in mods)
//            {
//                if (folders.TryResolvePath(mod, out var path))
//                {
//                    list.Add(path);
//                }
//                else if (throwIfMissing)
//                {
//                    throw new FileNotFoundException("could not resolve mode path", mod);
//                }
//            }

//            return list;
//        }

//        /// <summary>
//        /// Resolve the depedencies of the provided mods and return a list of full filepaths of the mods and dependencies in load order.
//        /// The provided <see cref="GameFolder"/>s will be used to resolve mod names (example.mod) to full file paths. All dependencies will need to be resolved this way.
//        /// </summary>
//        /// <param name="folders">Collection of <see cref="GameFolder"/>s for use when resolving the full path and a mod name.</param>
//        /// <param name="mods">Collection of mods names and/or full filenames.</param>
//        /// <returns>A collection of full path's for the mods and their dependencies in load order.</returns>
//        public static IEnumerable<string> ResolveDependencyTree(this IEnumerable<GameFolder> folders, IEnumerable<string> mods)
//        {
//            var stack = new Stack<string>();
//            var resolved = new HashSet<string>();
//            var usedNames = new HashSet<string>();

//            // Resolve full path of each mod (ignoring duplicates) and push to the stack
//            foreach (var mod in mods)
//            {
//                if (!NameUsed(mod) && folders.TryResolvePath(mod, out var path))
//                {
//                    Push(path);
//                }
//            }

//            while (stack.Count > 0)
//            {
//                var current = stack.Pop();

//                var header = LoadHeader(current);

//                var unresolved = new List<string>();

//                foreach (var mod in header.Dependencies)
//                {
//                    // this mod is already on the stack/resolved so ignore it
//                    if (NameUsed(mod))
//                    {
//                        continue;
//                    }

//                    // new mod so resolve path and store
//                    if (folders.TryResolvePath(mod, out var path))
//                    {
//                        unresolved.Add(path);
//                    }
//                }

//                // if we have any unresolved dependencies push the current item back onto the stack followed by it's unresolved dependencies
//                if (unresolved.Count > 0)
//                {
//                    stack.Push(current);

//                    unresolved.ForEach(Push);
//                }
//                else
//                {
//                    // No unresolved dependencies so mark as resolved
//                    resolved.Add(current);
//                }
//            }

//            // List of full file paths in load order.
//            return resolved;

//            bool NameUsed(string name) => usedNames.Contains(Path.GetFileName(name));

//            bool UseName(string name) => usedNames.Add(Path.GetFileName(name));

//            void Push(string name)
//            {
//                stack.Push(name);
//                UseName(name);
//            }
//        }

//        /// <summary>
//        /// Load the meta data for the game's save folders.
//        /// </summary>
//        /// <returns>A collection of save folders representing the game's save folders.</returns>
//        public static IEnumerable<SaveFolder> LoadSaveFolders() => new[] { new SaveFolder("save"), new SaveFolder(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "kenshi", "save")) };

//        internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
//    }
//}