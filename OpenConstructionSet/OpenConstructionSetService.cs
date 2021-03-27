using System;
using System.Collections.Generic;
using System.Linq;
using forgotten_construction_set;
using static forgotten_construction_set.GameData;

namespace OpenConstructionSet
{
    /// <summary>
    /// Searches for the specified mod in the given folders.
    /// </summary>
    /// <param name="modFilename">Filename of the mod e.g. example.mod</param>
    /// <param name="folders">Folders to search.</param>
    /// <returns></returns>
    public delegate string ResolveModPath(string modFilename, IEnumerable<ModFolder> folders);

    /// <summary>
    /// Builds a queue of full mod paths to load.
    /// The last mod in the queue should be the first mod passed in (The active mod).
    /// </summary>
    /// <param name="mods">Collection of mods</param>
    /// <param name="resolveModPath">Resolves a mod filename (example.mod) to it's full path.</param>
    /// <returns></returns>
    public delegate Queue<string> ResolveDependencyTree(IEnumerable<string> mods, Func<string, string> resolveModPath);

    public class OpenConstructionSetService
    {
        static OpenConstructionSetService() => WinFormsInfrastructure.Init();

        public readonly static string[] BaseMods = new string[] { "gamedata.base", "Newwworld.mod", "Dialogue.mod", "rebirth.mod" };

        /// <summary>
        /// <see cref="ResolveModPath"/>
        /// </summary>
        public ResolveModPath ResolveModPathFunction { get; set; }

        /// <summary>
        /// <see cref="ResolveDependencyTree"/>
        /// </summary>
        public ResolveDependencyTree ResolveDependencyTreeFunction { get; set; }

        public OpenConstructionSetService(IEnumerable<ModFolder> modFolders = null, ResolveModPath resolveModPath = null, ResolveDependencyTree resolveDependencyTree = null)
        {
            ResolveModPathFunction = resolveModPath ?? new ResolveModPath(InternalResolveModPath);
            ResolveDependencyTreeFunction = resolveDependencyTree ?? new ResolveDependencyTree(InternalResolveDependencyTree);

            if (modFolders != null)
            {
                Folders.AddRange(modFolders);
            }
        }

        /// <summary>
        /// The locations to search when resolving a mod's filename to it's full path.
        /// </summary>
        public List<ModFolder> Folders { get; } = new List<ModFolder>();

        /// <summary>
        /// Loads the provided mods into either the passed <c>GameData</c> object or a new one.
        /// </summary>
        /// <param name="mods">Mods to load. If you're using an active mod it should be first in the list.</param>
        /// <param name="activeMod">If <c>true</c> the first item in <c>mods</c> will be loaded in <c>ModMode.ACTIVE</c> mode.</param>
        /// <param name="resolveReferences">If <c>true</c> all references will be resolved. This may take some time.</param>
        /// <param name="baseData">If not null the mods will be loaded into baseData.</c></param>
        /// <returns>A <c>GameData</c> object loaded with the specifed mods.</returns>
        public GameData Load(IEnumerable<string> mods, bool activeMod, GameData baseData = null, bool resolveReferences = false)
        {
            var gameData = baseData ?? new GameData();

            var loadOrder = ResolveDependencyTreeFunction(mods, s => ResolveModPathFunction(s, Folders));

            while (loadOrder.Count > 0)
            {
                var filename = loadOrder.Dequeue();

                var mode = loadOrder.Count == 0 && activeMod ? ModMode.ACTIVE : ModMode.BASE;

                gameData.load(filename, mode, true);
            }

            if (resolveReferences)
                gameData.resolveAllReferences();

            return gameData;
        }

        /// <summary>
        /// Initializes a new mod, saves it and then returns a <c>GameData</c> representing it.
        /// </summary>
        /// <param name="header">Contains the meta data for the mod.</param>
        /// <param name="folder">Folder to save mod in.</param>
        /// <param name="filename">Mod filename e.g. Example.mod</param>
        /// <returns></returns>
        public GameData InitMod(Header header, ModFolder folder, string filename)
        {
            var gameData = new GameData
            {
                header = header
            };

            gameData.save(folder.GetFilePath(filename));

            return gameData;
        }

        private static string InternalResolveModPath(string modFilename, IEnumerable<ModFolder> folders)
        {
            if (System.IO.File.Exists(modFilename))
                return modFilename;

            foreach (var folder in folders)
            {
                string file;

                file = folder.GetFilePath(modFilename);

                if (System.IO.File.Exists(file))
                {
                    return file;
                }
            }

            return null;
        }

        private static Queue<string> InternalResolveDependencyTree(IEnumerable<string> mods, Func<string, string> resolveModPath)
        {
            var stack = new Stack<string>();
            var resolved = new Queue<string>();

            mods.Select(resolveModPath).Where(m => m != null).ToList().ForEach(m => stack.Push(m));

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (resolved.Contains(current))
                    continue;

                var header = loadHeader(current);

                var unresolved = header.Dependencies.Select(resolveModPath).Except(resolved).Where(m => m != null).ToList();

                if (unresolved.Any())
                {
                    stack.Push(current);

                    unresolved.ForEach(d => stack.Push(d));
                }
                else
                {
                    resolved.Enqueue(current);
                }
            }

            return resolved;
        }
    }
}
;