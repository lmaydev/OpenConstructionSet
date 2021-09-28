using OpenConstructionSet.IO;
using OpenConstructionSet.IO.Discovery;

namespace OpenConstructionSet;

public class OcsService : IOcsService
{
    private static readonly Lazy<OcsService> _default = new(() => new(new IFolderLocator[]
    {
        SteamFolderLocator.Default,
        GogFolderLocator.Default,
        LocalFolderLocator.Default
    }));

    public static OcsService Default => _default.Value;

    private readonly Dictionary<string, IFolderLocator> locators;

    private string[] SupportedFolderLocators { get; }

    public OcsService(IEnumerable<IFolderLocator> locators)
    {
        this.locators = locators.ToDictionary(l => l.Id);
        SupportedFolderLocators = locators.Select(l => l.Id).ToArray();
    }

    public Dictionary<string, GameFolders> FindAllGameFolders()
    {
        var result = new Dictionary<string, GameFolders>();

        foreach (var locator in SupportedFolderLocators)
        {
            var folders = FindGameFolders(locator);

            if (folders is not null)
            {
                result.Add(locator, folders);
            }
        }

        return result;
    }

    public GameFolders? FindGameFolders(string locatorId)
    {
        if (!locators.TryGetValue(locatorId, out var locator))
        {
            return null;
        }

        if (!locator.TryFind(out var discovered))
        {
            return null;
        }

        var data = DiscoverFolder(discovered.Data);
        var mod = DiscoverFolder(discovered.Mod);

        if (data is null || mod is null)
        {
            return null;
        }

        var content = discovered.Content is null ? null : DiscoverFolder(discovered.Content);

        return new(discovered.Game, data, mod, content);
    }

    public GameFolders? FindGameFolders() => SupportedFolderLocators.Select(FindGameFolders).FirstOrDefault(f => f is not null);

    public ModFolder? DiscoverFolder(string folder)
    {
        if (!Directory.Exists(folder))
        {
            return null;
        }

        var result = new ModFolder(folder, new(StringComparer.OrdinalIgnoreCase));

        AddRange(Directory.GetFiles(folder, "*.base").Select(DiscoverFile));
        AddRange(Directory.GetFiles(folder, "*.mod").Select(DiscoverFile));
        // all mod files in a sub folder
        AddRange(Directory.GetDirectories(folder).SelectMany(f => Directory.GetFiles(f, "*.mod")).Select(DiscoverFile));

        void AddRange(IEnumerable<ModFile?> mods)
        {
            foreach (var mod in mods)
            {
                if (mod is null)
                {
                    continue;
                }

                result.Mods.Add(mod.FileName, mod);
            }
        }

        return result;
    }

    public ModFile? DiscoverFile(string file)
    {
        file = Path.GetFullPath(file);

        if (!File.Exists(file))
        {
            return null;
        }

        var header = ReadHeader(file);

        if (header is null)
        {
            return null;
        }

        var infoPath = OcsIOHelper.GetInfoPath(file);

        ModInfo? info = null;

        if (File.Exists(infoPath))
        {
            using var stream = File.OpenRead(infoPath);
            info = OcsIOHelper.ReadInfo(stream);
        }

        return new(file, header, info);
    }

    public string[] ReadLoadOrder(ModFolder folder)
    {
        var path = Path.Combine(folder.FullName, "mods.cfg");

        return File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>();
    }

    public bool SaveLoadOrder(ModFolder folder, string[] loadOrder)
    {
        var path = Path.Combine(folder.FullName, "mods.cfg");

        File.Delete(path);
        File.WriteAllLines(path, loadOrder);
        return true;
    }

    public Header? ReadHeader(string path)
    {
        path = path.AddModExtension();

        if (!File.Exists(path))
        {
            return null;
        }

        using var reader = new OcsReader(File.OpenRead(path));

        return OcsIOHelper.ReadHeader(reader);
    }
}
