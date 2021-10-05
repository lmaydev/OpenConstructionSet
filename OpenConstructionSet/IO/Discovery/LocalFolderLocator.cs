using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.IO.Discovery;

/// <summary>
/// Implementation of a <see cref="IInstallationLocator"/> that looks for the folders in the working directory.
/// </summary>
public class LocalFolderLocator : IInstallationLocator
{
    private static readonly Lazy<LocalFolderLocator> _default = new(() => new());

    /// <summary>
    /// Lazy initiated singlton for when DI is not being used
    /// </summary>
    public static LocalFolderLocator Default => _default.Value;

    /// <inheritdoc/>
    public string Id { get; } = "Local";

    /// <inheritdoc/>
    public bool TryFind([MaybeNullWhen(false)] out LocatedFolders folders)
    {
        if (!Directory.Exists("data") || !Directory.Exists("mods"))
        {
            folders = null;
            return false;
        }

        folders = new(Path.GetFullPath("."), null);
        return true;
    }
}
