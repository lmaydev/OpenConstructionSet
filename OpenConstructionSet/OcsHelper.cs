﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using forgotten_construction_set;
using static forgotten_construction_set.GameData;

namespace OpenConstructionSet
{
    public static class OcsHelper
    {
        static OcsHelper() => WinFormsInfrastructure.Init();

        public readonly static string[] BaseMods = new string[] { "gamedata.base", "Newwworld.mod", "Dialogue.mod", "rebirth.mod" };

        /// <summary>
        /// Loads the provided mods into either the passed <c>GameData</c> object or a new one.
        /// </summary>
        /// <param name="modsFullFilename">Full file paths of the mods to load.</param>
        /// <param name="activeMod">Full file path of the active mod if required.</param>
        /// <param name="baseData">If not null the mods will be loaded into baseData.</c></param>
        /// <returns>A <c>GameData</c> object loaded with the specifed mods.</returns>
        public static GameData Load(IEnumerable<string> modsFullFilename, string activeMod = null, GameData baseData = null)
        {
            var gameData = baseData ?? new GameData();

            foreach (var mod in modsFullFilename)
            {
                gameData.load(mod, ModMode.BASE, true);
            }

            if (activeMod != null)
            {
                gameData.load(activeMod, ModMode.ACTIVE, true);
            }

            return gameData;
        }

        /// <summary>
        /// Initializes a new mod, saves it and then returns a <c>GameData</c> representing it.
        /// </summary>
        /// <param name="header">Contains the meta data for the mod.</param>
        /// <param name="folder">Folder to save mod in.</param>
        /// <param name="filename">Mod filename e.g. Example.mod</param>
        /// <returns></returns>
        public static GameData NewMod(Header header, ModFolder folder, string filename)
        {
            var gameData = new GameData
            {
                header = header
            };

            gameData.save(folder.GetFullFilename(filename));

            return gameData;
        }

        /// <summary>
        /// Attempt to find the default data and mods folders.
        /// </summary>
        /// <returns>A <see cref="DefaultFolders"/> containing (You guessed it) the default folders.</returns>
        public static bool TryFindDefaultFolders(out DefaultFolders defaultFolders)
        {
            if (!OcsSteamHelper.TryFindGameFolder(out var gameFolder))
            {
                defaultFolders = null;
                return false;
            }

            defaultFolders = new DefaultFolders()
            {
                Base = ModFolder.Base(Path.Combine(gameFolder, "data")),
                Mod = ModFolder.Mod(Path.Combine(gameFolder, "mods")),
            };

            return true;
        }

        /// <summary>
        /// Search the provided folders to resolve a mod name (Example.mod) to a full filename.
        /// </summary>
        /// <param name="modFilename">The name of the mod file. example.mod for example.</param>
        /// <param name="folders">Collection of <see cref="ModFolder"/>s to search.</param>
        /// <returns></returns>
        public static string ResolveFullFilename(string modFilename, IEnumerable<ModFolder> folders)
        {
            if (System.IO.File.Exists(modFilename))
                return modFilename;

            foreach (var folder in folders)
            {
                var file = folder.GetFullFilename(modFilename);

                if (System.IO.File.Exists(file))
                {
                    return file;
                }
            }

            return null;
        }

        /// <summary>
        /// Resolve the depedencies of the provided mods and return a list of full filepaths of the mods and dependencies in load order.
        /// The provided <c>folders</c> will be used to resolve mod names (example.mod) to full file paths. ALL dependencies will need to be resolved this way.
        /// </summary>
        /// <param name="mods">Collection of mods names and/or full filenames.</param>
        /// <param name="folders">Collection of <see cref="ModFolder"/>s for use when resolving the full path and a mod name.</param>
        /// <returns>A <c>List</c> of full filenames for the mods and their dependencies in load order.</returns>
        public static List<string> ResolveDependencyTree(IEnumerable<string> mods, IEnumerable<ModFolder> folders)
        {
            var stack = new Stack<string>();
            var resolved = new List<string>();

            // Resolve full filenames and add existing files to the stack
            mods.Select(m => ResolveFullFilename(m, folders)).Where(m => m != null).ToList().ForEach(m => stack.Push(m));

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (resolved.Contains(current))
                    continue;

                var header = loadHeader(current);

                // Select the full filename of each depedency and create a list from files that exist and aren't already resolved
                var unresolved = header.Dependencies.Select(m => ResolveFullFilename(m, folders)).Where(m => m != null).Except(resolved).ToList();

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