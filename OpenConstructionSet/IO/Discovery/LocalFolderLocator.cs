using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace OpenConstructionSet.IO.Discovery
{
    public class LocalFolderLocator : IFolderLocator
    {
        public string Id { get; } = "local";

        public bool TryFind([MaybeNullWhen(false)] out DiscoveredFolders folders)
        {
            if (!Directory.Exists("data") && !Directory.Exists("mods"))
            {
                folders = null;
                return false;
            }

            folders = new("mods", "data", null);
            return true;
        }
    }
}
