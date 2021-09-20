using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace OpenConstructionSet.IO.Discovery
{
    public class SteamFolderLocator : IFolderLocator
    {
        private static readonly Lazy<SteamFolderLocator> _default = new(() => new());

        public static SteamFolderLocator Default => _default.Value;

        public string Id { get; } = "steam";

        public bool TryFind([MaybeNullWhen(false)] out DiscoveredFolders folders)
        {
            string folder = SteamFolder();

            if (string.IsNullOrWhiteSpace(folder))
            {
                folders = null;
                return false;
            }

            var gameFolder = "";
            string? contentFolder = null;

            foreach (var library in Libraries())
            {
                var path = Path.Combine(library, "steamapps", "common", "Kenshi");

                if (Directory.Exists(path))
                {
                    gameFolder = path;
                }

                path = Path.Combine(library, "steamapps", "workshop", "content", "233860");

                if (Directory.Exists(path))
                {
                    contentFolder = path;
                }
            }

            if (string.IsNullOrWhiteSpace(gameFolder))
            {
                folders = null;
                return false;
            }

            folders = new DiscoveredFolders(Path.Combine(gameFolder, "mods"), Path.Combine(gameFolder, "data"), contentFolder);
            return true;

            string SteamFolder()
            {
                try
                {
                    var registryKey = Environment.Is64BitProcess ? @"SOFTWARE\Wow6432Node\Valve\Steam" : @"SOFTWARE\Valve\Steam";

                    using var key = Registry.LocalMachine.OpenSubKey(registryKey);

                    return key?.GetValue("InstallPath")?.ToString() ?? "";
                }
                catch
                {
                    return "";
                }
            }

            IEnumerable<string> Libraries()
            {
                var path = Path.Combine(folder, "steamapps", "libraryfolders.vdf");

                // [whitespace] "[number]" [whitespace] "[library path]"
                const string pattern = "^\\s+\"\\d+\"\\s+\"(.+)\"";

                var libraries = new List<string> { folder };

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
                        var library = match.Groups[1].Value;

                        if (!Directory.Exists(library))
                        {
                            continue;
                        }

                        libraries.Add(library);
                    }
                }

                return libraries;
            }
        }
    }
}
