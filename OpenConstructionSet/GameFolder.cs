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
        public string FolderPath { get; }

        /// <summary>
        /// Returns the full path of a mod from its' name.
        /// </summary>
        /// <param name="modFilename">The file name of the mod. e.g. example.mod</param>
        /// <returns>The full path of a mod file.</returns>
        public string GetFullPath(string modFilename)
        {
            switch (Type)
            {
                case GameFolderType.Data:
                    return GetBasePath(modFilename);

                case GameFolderType.Mod:
                    return GetModPath(modFilename);

                default:
                    throw new InvalidOperationException($"Invalid {nameof(GameFolderType)} ({Type})");
            }
        }

        /// <summary>
        /// Deletes the given mod if it exists.
        /// </summary>
        /// <param name="modFilename">The file name of the mod. e.g. example.mod</param>
        public void Delete(string modFilename)
        {
            switch (Type)
            {
                case GameFolderType.Data:
                    File.Delete(GetBasePath(modFilename));
                    break;

                case GameFolderType.Mod:
                    Directory.Delete(GetModFolder(modFilename), true);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid {nameof(GameFolderType)} ({Type})");
            }
        }

        private string GetModFolder(string modFilename) => Path.Combine(FolderPath, Path.GetFileNameWithoutExtension(modFilename));

        private string GetModPath(string modFilename) => Path.Combine(GetModFolder(modFilename), modFilename);

        private string GetBasePath(string modFilename) => Path.Combine(FolderPath, modFilename);

        private GameFolder(string folderPath, GameFolderType type)
        {
            FolderPath = folderPath;
            Type = type;
        }

        /// <summary>
        /// Creates a new <see cref="GameFolderType.Mod"/> <see cref="GameFolder"/> instance.
        /// </summary>
        /// <param name="folderPath">Full path of the folder.</param>
        /// <returns>A <see cref="GameFolderType.Mod"/> <see cref="GameFolder"/> with the given path. </returns>
        public static GameFolder Mod(string folderPath) => new GameFolder(folderPath, GameFolderType.Mod);

        /// <summary>
        /// Creates a new <see cref="GameFolderType.Data"/> <see cref="GameFolder"/> instance.
        /// </summary>
        /// <param name="folderPath">Full path of the folder.</param>
        /// <returns>A <see cref="GameFolderType.Data"/> <see cref="GameFolder"/> with the given path. </returns>
        public static GameFolder Data(string folderPath) => new GameFolder(folderPath, GameFolderType.Data);
    }
}