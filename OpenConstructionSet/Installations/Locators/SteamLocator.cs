using Microsoft.Win32;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;

namespace OpenConstructionSet.Installations.Locators;

/// <summary>
/// Gog implementation of a <see cref="IInstallationLocator"/>
/// </summary>
[SupportedOSPlatform("windows")]
public class SteamLocator : IInstallationLocator
{
    /// <inheritdoc/>
    public string Id { get; } = "Steam";

    /// <inheritdoc/>
    public Task<IInstallation?> LocateAsync()
    {
        var folder = SteamFolder();

        if (string.IsNullOrWhiteSpace(folder))
        {
            return Task.FromResult<IInstallation?>(null);
        }

        string? gameFolder = null;
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
            return Task.FromResult<IInstallation?>(null);
        }

        return Task.FromResult<IInstallation?>(new Installation(Id, gameFolder, contentFolder is not null ? new ModFolder(contentFolder, ModFolderType.Content) : null));

        string SteamFolder()
        {
            try
            {
                var registryKey = Environment.Is64BitProcess ? @"SOFTWARE\Wow6432Node\Valve\Steam" : @"SOFTWARE\Valve\Steam";

                return Registry.LocalMachine.OpenSubKey(registryKey)?.GetValue("InstallPath", "")?.ToString() ?? "";
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