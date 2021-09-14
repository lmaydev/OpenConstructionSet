using Microsoft.Win32;
using OpenConstructionSet.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

                using var key = Registry.LocalMachine.OpenSubKey(registryKey);

                folder = key?.GetValue("InstallPath")?.ToString() ?? "";
            }
            catch
            {
            }

            folder = "";
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

            IEnumerable<string> lines;

            try
            {
                lines = File.ReadLines(path);
            }
            catch
            {
                return Enumerable.Empty<string>();
            }

            foreach (var line in lines)
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
            try
            {
                foreach (var library in GetLibraries())
                {
                    path = Path.Combine(library, "steamapps", "common", "Kenshi");

                    if (Directory.Exists(path))
                    {
                        return true;
                    }
                }
            }
            catch
            {
            }

            path = "";
            return false;
        }

        public static ModFolders? FindGameFolders()
        {
            if (!TryFindGameFolder(out var gameFolder))
            {
                return null;
            }

            return new()
            {
                Data = ModFolder.Discover(Path.Combine(gameFolder, "data")),
                Mod = ModFolder.Discover(Path.Combine(gameFolder, "mods")),
            };
        }

        public static ModFolder? FindContentFolder()
        {
            foreach (var library in GetLibraries())
            {
                var path = Path.Combine(library, "steamapps", "workshop", "content", "233860");

                if (Directory.Exists(path))
                {
                    return ModFolder.Discover(path);
                }
            }

            return null;
        }
    }
}