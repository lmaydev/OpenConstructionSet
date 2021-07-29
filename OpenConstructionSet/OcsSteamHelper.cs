using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace OpenConstructionSet
{
    /// <summary>
    /// Helper used to retrieve the default folders from Steam
    /// </summary>
    public static class OcsSteamHelper
    {
        private static bool TryGetSteamFolder(out string folder)
        {
            try
            {
                var registryKey = Environment.Is64BitProcess ? @"SOFTWARE\Wow6432Node\Valve\Steam" : @"SOFTWARE\Valve\Steam";

                using (var key = Registry.LocalMachine.OpenSubKey(registryKey))
                {
                    folder = key.GetValue("InstallPath").ToString();
                    return true;
                }
            }
            catch
            {
            }

            folder = null;
            return false;
        }

        private static IEnumerable<string> GetLibraries()
        {
            if (!TryGetSteamFolder(out var steamFolder))
            {
                return Enumerable.Empty<string>();
            }

            var path = Path.Combine(steamFolder, "steamapps", "libraryfolders.vdf");

            // [whitespace] "[number]" [whitespace] "[library path]"
            const string pattern = "^\\s+\"\\d+\"\\s+\"(.+)\"";

            var libraries = new List<string> { steamFolder };

            foreach (var line in File.ReadLines(path))
            {
                var match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    libraries.Add(match.Groups[1].Value);
                }
            }

            return libraries;
        }

        private static bool TryFindGameFolder(out string path)
        {
            foreach (var library in GetLibraries())
            {
                path = Path.Combine(library, "steamapps", "common", "Kenshi");

                if (Directory.Exists(path))
                {
                    return true;
                }
            }

            path = null;
            return false;
        }

        /// <summary>
        /// Attempt to find the game's data and mods folders.
        /// </summary>
        /// <param name="folders">If found this will be set to a <see cref="GameFolders"/> containing (You guessed it) the game's folders.</param>
        /// <returns><c>true</c> if the game folders are found.</returns>
        public static bool TryFindGameFolders(out GameFolders folders)
        {
            if (!TryFindGameFolder(out var gameFolder))
            {
                folders = null;
                return false;
            }

            folders = new GameFolders()
            {
                Data = new GameFolder(Path.Combine(gameFolder, "data")),
                Mod = new GameFolder(Path.Combine(gameFolder, "mods")),
            };

            return true;
        }

        public static bool TryFindContentFolder(out GameFolder contentFolder)
        {
            foreach (var library in GetLibraries())
            {
                var path = Path.Combine(library, "steamapps", "workshop", "content", "233860");

                if (Directory.Exists(path))
                {
                    contentFolder = new GameFolder(path);
                    return true;
                }
            }

            contentFolder = null;
            return false;
        }
    }
}