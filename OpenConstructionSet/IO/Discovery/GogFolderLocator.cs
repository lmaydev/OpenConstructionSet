using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace OpenConstructionSet.IO.Discovery
{
    public class GogFolderLocator : IFolderLocator
    {
        const string Key64 = @"SOFTWARE\WOW6432Node\GOG.com\Games\1193046833";
        const string Key32 = @"SOFTWARE\GOG.com\Games\1193046833";

        public string Id { get; } = "gog";

        public bool TryFind([MaybeNullWhen(false)] out DiscoveredFolders folders)
        {
            var registryKey = Registry.LocalMachine.OpenSubKey(Environment.Is64BitProcess ? Key64 : Key32);

            if (registryKey is null)
            {
                folders = null;
                return false;
            }

            var gameFolder = registryKey.GetValue("path", "")?.ToString();

            if (string.IsNullOrEmpty(gameFolder))
            {
                folders = null;
                return false;
            }

            folders = new DiscoveredFolders(Path.Combine(gameFolder, "mods"), Path.Combine(gameFolder, "data"), null);
            return true;
        }
    }
}
