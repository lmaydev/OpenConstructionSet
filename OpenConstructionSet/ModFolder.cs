using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace OpenConstructionSet
{
    public class ModFolder
    {
        public ModFolderType Type { get; set; }

        public string FolderPath { get; set; }

        public string GetFilePath(string modFilename)
        {
            switch (Type)
            {
                case ModFolderType.Base:
                    return BasePath();

                case ModFolderType.Mod:
                    return ModPath();

                default:
                    throw new InvalidOperationException($"Invalid {nameof(ModFolderType)} ({Type})");
            }

            string ModPath() => Path.Combine(FolderPath, Path.GetFileNameWithoutExtension(modFilename), modFilename);

            string BasePath() => Path.Combine(FolderPath, modFilename);
        }

        public static (ModFolder Base, ModFolder Mod) ResolveDefaultFolders()
        {
            var steamFolder = GetSteamFolder();
            var libraries = GetLibraries();

            foreach (var library in libraries)
            {
                if (FindKenshi(library, out var path))
                {
                    return (new ModFolder { Type = ModFolderType.Base, FolderPath = System.IO.Path.Combine(path, "data") },
                        new ModFolder { Type = ModFolderType.Mod, FolderPath = System.IO.Path.Combine(path, "mods") });
                }
            }

            throw new Exception("Default folders could not be found");

            string GetSteamFolder()
            {
                var registryKey = Environment.Is64BitProcess ? @"SOFTWARE\Wow6432Node\Valve\Steam" : @"SOFTWARE\Valve\Steam";

                using (var key = Registry.LocalMachine.OpenSubKey(registryKey))
                {
                    return key.GetValue("InstallPath").ToString();
                }
            }

            IEnumerable<string> GetLibraries()
            {
                var path = System.IO.Path.Combine(steamFolder, "steamapps", "libraryfolders.vdf");

                // [whitespace] "[number]" [whitespace] "[library path]"
                var pattern = "^\\s+\"\\d+\"\\s+\"(.+)\"";

                foreach (var line in File.ReadLines(path))
                {
                    var match = Regex.Match(line, pattern);

                    if (match.Success)
                    {
                        yield return match.Groups[1].Value;
                    }
                }
            }

            bool FindKenshi(string library, out string path)
            {
                path = System.IO.Path.Combine(library, "steamapps", "common", "Kenshi");

                return Directory.Exists(path);
            }
        }
    }
}