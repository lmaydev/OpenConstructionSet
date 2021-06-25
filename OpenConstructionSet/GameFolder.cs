using System;
using System.IO;

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
        public string Folder { get; }

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

        private string GetModFolder(string mod) => Path.Combine(Folder, Path.GetFileNameWithoutExtension(mod));

        private string GetModPath(string mod) => Path.Combine(GetModFolder(mod), mod);

        private string GetBasePath(string mod) => Path.Combine(Folder, mod);

        private GameFolder(string folder, GameFolderType type)
        {
            Folder = folder;
            Type = type;
        }

        /// <summary>
        /// Creates a new <see cref="GameFolderType.Mod"/> <see cref="GameFolder"/> instance.
        /// </summary>
        /// <param name="folder">Full path of the folder.</param>
        /// <returns>A <see cref="GameFolderType.Mod"/> <see cref="GameFolder"/> with the given path. </returns>
        public static GameFolder Mod(string folder) => new GameFolder(folder, GameFolderType.Mod);

        /// <summary>
        /// Creates a new <see cref="GameFolderType.Data"/> <see cref="GameFolder"/> instance.
        /// </summary>
        /// <param name="folder">Full path of the folder.</param>
        /// <returns>A <see cref="GameFolderType.Data"/> <see cref="GameFolder"/> with the given path. </returns>
        public static GameFolder Data(string folder) => new GameFolder(folder, GameFolderType.Data);
    }
}