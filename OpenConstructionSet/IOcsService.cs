namespace OpenConstructionSet;

public interface IOcsService
{
    ModFile? DiscoverFile(string file);
    ModFolder? DiscoverFolder(string folder);
    Dictionary<string, GameFolders> FindAllGameFolders();
    GameFolders? FindGameFolders();
    GameFolders? FindGameFolders(string locatorId);
    Header? ReadHeader(string path);
    string[] ReadLoadOrder(IEnumerable<ModFolder> folders);
    bool SaveLoadOrder(IEnumerable<ModFolder> folders, string[] loadOrder);
}