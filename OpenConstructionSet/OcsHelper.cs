using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using forgotten_construction_set;
using static forgotten_construction_set.GameData;

namespace OpenConstructionSet
{
    public static class OcsHelper
    {
        static OcsHelper() => OcsWinformsHelper.Init();

        public readonly static string[] BaseMods = new string[] { "gamedata.base", "Newwworld.mod", "Dialogue.mod", "rebirth.mod" };

        /// <summary>
        /// Builds a <c>GameData</c> object by loading the given <c>mods</c> from the provided <c>folders</c>.
        /// </summary>
        /// <param name="mods">Collection of mods to be loaded. Both names (e.g. example.mod) and full paths are accetped.</param>
        /// <param name="folders">
        /// Collection of folders to search when resolving a mod's name to it's full path.
        /// All dependencies will be resolved this way.
        /// If <c>folders</c> is null the game folders will be used.
        /// </param>
        /// <param name="activeMod">Name or full path of the mod to load as active. Both a name (e.g. example.mod) and a full path are accetped.</param>
        /// <param name="resolveDependencies">If <c>true</c> dependencies will will be resolved and mods loaded in order.</param>
        /// <param name="loadGameFiles">If <c>true</c> the game's data files will be loaded.</param>
        /// <returns>The built <c>GameData</c>.</returns>
        public static GameData Load(IEnumerable<string> mods, string activeMod = null, IEnumerable<GameFolder> folders = null, bool resolveDependencies = true, bool loadGameFiles = true)
        {
            if (folders == null)
            {
                if (OcsSteamHelper.TryFindGameFolders(out var gameFolders))
                {
                    folders = gameFolders.ToArray();
                }
                else
                {
                    throw new Exception("Failed to find default game folders");
                }
            }

            var toLoad = new List<string>(mods);
            
            if (loadGameFiles)
            {
                toLoad.AddRange(BaseMods);
            }

            if (activeMod != null && !toLoad.Any(m => m == activeMod || m.EndsWith(Path.GetFileName(activeMod))))
            {
                toLoad.Insert(0, activeMod);
            }

            var loadOrder = resolveDependencies ? ResolveDependencyTree(toLoad, folders) : ResolvePaths(toLoad, folders);

            var gameData = new GameData();

            foreach (var mod in loadOrder)
            {
                var mode = activeMod != null && Path.GetFileName(mod) == Path.GetFileName(activeMod) ? ModMode.ACTIVE : ModMode.BASE;

                gameData.load(mod, mode, true);
            }

            return gameData;
        }

        /// <summary>
        /// Initializes a new mod, saves it and then returns the mods full path.
        /// </summary>
        /// <param name="header">Contains the meta data for the mod.</param>
        /// <param name="mod">Mod filename. e.g. example.mod</param>
        /// <param name="folder">Folder to save mod in. If folder is <c>null</c> the game's mod folder will be used.</param>
        /// <returns>The full path of the mod.</returns>
        public static string NewMod(Header header, string mod, GameFolder folder = null, bool deleteExisting = true)
        {
            if (folder == null)
            {
                if (!OcsSteamHelper.TryFindGameFolders(out var gameFolders))
                {
                    throw new Exception("Failed to find default game folders");
                }

                folder = gameFolders.Mod;
            }

            var path = folder.GetFullPath(mod);

            if (!deleteExisting && System.IO.File.Exists(path))
            {
                throw new Exception("Mod already exists");
            }

            folder.Delete(mod);

            var gameData = new GameData
            {
                header = header
            };

            gameData.save(path);

            return path;
        }

        /// <summary>
        /// Search the provided folders to resolve a mod name (e.g. example.mod) to a full path.
        /// </summary>
        /// <param name="mod">The name of the mod file. e.g. example.mod.</param>
        /// <param name="folders">Collection of <see cref="GameFolder"/>s to search.</param>
        /// <param name="path">If resolved this parameter will be set to the mod's full path</param>
        /// <returns>Returns <c>true</c> if the full path was resolved</returns>
        public static bool TryResolvePath(string mod, IEnumerable<GameFolder> folders, out string path)
        {
            if (System.IO.File.Exists(mod))
            {
                path = mod;
                return true;
            }

            foreach (var folder in folders)
            {
                var file = folder.GetFullPath(mod);

                if (System.IO.File.Exists(file))
                {
                    path = file;
                    return true;
                }
            }

            path = null;
            return false;
        }

        /// <summary>
        /// Search the provided folders to resolve the presented mods.
        /// Mods that cannot be resolved will be dropped. Unless throwIfMissing is <c>true</c>.
        /// </summary>
        /// <param name="mods">Collections of the names of the mod files. e.g. example.mod.</param>
        /// <param name="folders">Collection of <see cref="GameFolder"/>s to search.</param>
        /// <param name="throwIfMissing">If <c>true</c> missing mods will result in an exception.</param>
        /// <returns></returns>
        public static IEnumerable<string> ResolvePaths(IEnumerable<string> mods, IEnumerable<GameFolder> folders, bool throwIfMissing = false)
        {
            var list = new List<string>();

            foreach (var mod in mods)
            {
                if (TryResolvePath(mod,folders, out var path))
                {
                    list.Add(path);
                }
                else if (throwIfMissing)
                {
                    throw new FileNotFoundException("could not resolve mode path", mod);
                }
            }

            return list;
        }

        /// <summary>
        /// Resolve the depedencies of the provided mods and return a list of full filepaths of the mods and dependencies in load order.
        /// The provided <see cref="GameFolder"/>s will be used to resolve mod names (example.mod) to full file paths. All dependencies will need to be resolved this way.
        /// </summary>
        /// <param name="mods">Collection of mods names and/or full filenames.</param>
        /// <param name="folders">Collection of <see cref="GameFolder"/>s for use when resolving the full path and a mod name.</param>
        /// <returns>A collection of full path's for the mods and their dependencies in load order.</returns>
        public static IEnumerable<string> ResolveDependencyTree(IEnumerable<string> mods, IEnumerable<GameFolder> folders)
        {
            var stack = new Stack<string>();
            var resolved = new HashSet<string>();
            var resolvedPaths = new Dictionary<string, string>();

            // Resolve full filenames and add existing files to the stack
            foreach (var mod in mods)
            {
                if (TryResolvePath(mod, folders, out var fullName))
                {
                    stack.Push(fullName);
                }
            }

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (resolved.Contains(current))
                    continue;

                var header = loadHeader(current);

                var unresolved = new List<string>();

                foreach (var mod in header.Dependencies)
                {
                    // Only add mods that exist in the folders and haven't already been resolved
                    if (TryResolvePath(mod, folders, out var fullName) && !resolved.Contains(fullName))
                    {
                        unresolved.Add(fullName);
                    }
                }

                // if we have any unresolved dependencies push the current item back onto the stack followed by the dependencies
                if (unresolved.Count > 0)
                {
                    stack.Push(current);

                    unresolved.ForEach(d => stack.Push(d));
                }
                else
                {
                    // No unresolved dependencies so mark as resolved
                    resolved.Add(current);
                }
            }

            // List of full file paths in load order.
            return resolved;
        }
    }
}
;