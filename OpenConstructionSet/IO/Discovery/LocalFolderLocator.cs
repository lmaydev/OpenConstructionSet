using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.IO.Discovery;

public class LocalFolderLocator : IFolderLocator
{
    private static readonly Lazy<LocalFolderLocator> _default = new(() => new());

    public static LocalFolderLocator Default => _default.Value;

    public string Id { get; } = "local";

    public bool TryFind([MaybeNullWhen(false)] out DiscoveredFolders folders)
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
