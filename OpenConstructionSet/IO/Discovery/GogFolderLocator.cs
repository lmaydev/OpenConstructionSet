using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.IO.Discovery;

/// <summary>
/// Gog implementation of a <see cref="IInstallationLocator"/>
/// </summary>
public class GogFolderLocator : IInstallationLocator
{
    private static readonly Lazy<GogFolderLocator> _default = new(() => new());

    /// <summary>
    /// Lazy initiated singleton for when DI is not being used
    /// </summary>
    public static GogFolderLocator Default => _default.Value;

    private const string Key64 = @"SOFTWARE\WOW6432Node\GOG.com\Games\1193046833";
    private const string Key32 = @"SOFTWARE\GOG.com\Games\1193046833";

    /// <inheritdoc/>
    public string Id { get; } = "Gog";

    /// <inheritdoc/>
    public bool TryFind([MaybeNullWhen(false)] out LocatedFolders folders)
    {
        var registryKey = Registry.LocalMachine.OpenSubKey(Environment.Is64BitProcess ? Key64 : Key32);

        if (registryKey is null)
        {
            folders = null;
            return false;
        }

        var gameFolder = registryKey.GetValue("path", "")?.ToString();

        if (string.IsNullOrEmpty(gameFolder) || !Directory.Exists(gameFolder))
        {
            folders = null;
            return false;
        }

        folders = new LocatedFolders(gameFolder, null);
        return true;
    }
}
