﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace OpenConstructionSet
{
    public static class OcsSteamHelper
    {
        private static string GetSteamFolder()
        {
            try
            {
                var registryKey = Environment.Is64BitProcess ? @"SOFTWARE\Wow6432Node\Valve\Steam" : @"SOFTWARE\Valve\Steam";

                using (var key = Registry.LocalMachine.OpenSubKey(registryKey))
                {
                    return key.GetValue("InstallPath").ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to find Steam folder", ex);
            }
        }

        private static IEnumerable<string> GetLibraries()
        {
            var steamFolder = GetSteamFolder();

            var path = Path.Combine(steamFolder, "steamapps", "libraryfolders.vdf");

            // [whitespace] "[number]" [whitespace] "[library path]"
            const string pattern = "^\\s+\"\\d+\"\\s+\"(.+)\"";

            foreach (var line in File.ReadLines(path))
            {
                var match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    yield return match.Groups[1].Value;
                }
            }

            yield return steamFolder;
        }

        public static bool TryFindGameFolder(out string path)
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
    }
}