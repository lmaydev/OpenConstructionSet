using OpenConstructionSet.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace OpenConstructionSet
{
    public interface IOcsDiscoveryService
    {
        ModFolder? Discover(DirectoryInfo folder);
        ModFile? Discover(FileInfo file);
        IEnumerable<ModFile> DiscoverFiles(IEnumerable<string> files);
        IEnumerable<ModFolder> Discoverfolders(IEnumerable<string> folders);
        bool TryDiscoverFile(string path, [MaybeNullWhen(false)] out ModFile modFile);
        bool TryDiscoverFolder(DirectoryInfo folder, [MaybeNullWhen(false)] out ModFolder modFolder);
        bool TryDiscoverFolder(string folder, [MaybeNullWhen(false)] out ModFolder modFolder);
        Dictionary<string, ModFolders> TryFindAllGameFolders();
        bool TryFindGameFolders([MaybeNullWhen(false)] out ModFolders folders);
        bool TryFindGameFolders(string locatorId, [MaybeNullWhen(false)] out ModFolders folders);
    }
}