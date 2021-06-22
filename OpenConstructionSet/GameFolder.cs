using System;
using System.IO;

namespace OpenConstructionSet
{
    public class GameFolder
    {
        public GameFolderType Type { get; set; }

        public string FolderPath { get; set; }

        public string GetFullFilename(string filename)
        {
            switch (Type)
            {
                case GameFolderType.Data:
                    return GetBasePath(filename);

                case GameFolderType.Mod:
                    return GetModPath(filename);

                default:
                    throw new InvalidOperationException($"Invalid {nameof(GameFolderType)} ({Type})");
            }
        }

        public void Delete(string filename)
        {
            switch (Type)
            {
                case GameFolderType.Data:
                    File.Delete(GetBasePath(filename));
                    break;

                case GameFolderType.Mod:
                    Directory.Delete(GetModFolder(filename), true);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid {nameof(GameFolderType)} ({Type})");
            }
        }

        private string GetModFolder(string filename) => Path.Combine(FolderPath, Path.GetFileNameWithoutExtension(filename));

        private string GetModPath(string filename) => Path.Combine(GetModFolder(filename), filename);

        private string GetBasePath(string filename) => Path.Combine(FolderPath, filename);

        private GameFolder(string folderPath, GameFolderType type)
        {
            FolderPath = folderPath;
            Type = type;
        }

        public static GameFolder Mod(string folderPath) => new GameFolder(folderPath, GameFolderType.Mod);

        public static GameFolder Base(string folderPath) => new GameFolder(folderPath, GameFolderType.Data);
    }
}