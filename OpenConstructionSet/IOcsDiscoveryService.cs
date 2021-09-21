using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet;

public interface IOcsDiscoveryService
{
    ModFile? DiscoverFile(string file);
    ModFolder? DiscoverFolder(string folder);
    Dictionary<string, GameFolders> FindAllGameFolders();
    bool TryFindGameFolders([MaybeNullWhen(false)] out GameFolders folders);
    bool TryFindGameFolders(string locatorId, [MaybeNullWhen(false)] out GameFolders folders);
}