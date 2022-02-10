using System.Runtime.Versioning;
using Microsoft.Win32;

namespace OpenConstructionSet.Installations.Locators;

/// <summary>
/// Gog implementation of a <see cref="IInstallationLocator"/>
/// </summary>
[SupportedOSPlatform("windows")]
public class GogLocator : IInstallationLocator
{
    private const string Key32 = @"SOFTWARE\GOG.com\Games\1193046833";
    private const string Key64 = @"SOFTWARE\WOW6432Node\GOG.com\Games\1193046833";

    /// <inheritdoc/>
    public string Id { get; } = "Gog";

    /// <inheritdoc/>
    public Task<IInstallation?> LocateAsync()
    {
        var key = Environment.Is64BitProcess ? Key64 : Key32;

        var path = Registry.LocalMachine.OpenSubKey(key)?.GetValue("path", "")?.ToString();

        if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
        {
            return Task.FromResult<IInstallation?>(null);
        }

        return Task.FromResult<IInstallation?>(new Installation(Id, path, null));
    }
}
