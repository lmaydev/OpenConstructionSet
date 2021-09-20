using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.IO.Discovery
{
    public interface IFolderLocator
    {
        string Id { get; }

        bool TryFind([MaybeNullWhen(false)] out DiscoveredFolders folders);
    }
}
