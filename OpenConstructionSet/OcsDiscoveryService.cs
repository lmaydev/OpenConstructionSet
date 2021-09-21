using OpenConstructionSet.IO;
using OpenConstructionSet.IO.Discovery;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet;

public class OcsDiscoveryService : IOcsDiscoveryService
{
    private static IEnumerable<IFolderLocator> GetFolderLocators() => new IFolderLocator[] { SteamFolderLocator.Default, GogFolderLocator.Default, LocalFolderLocator.Default };

    private static readonly Lazy<OcsDiscoveryService> _default = new(() => new(GetFolderLocators(), OcsModService.Default));

    public static OcsDiscoveryService Default => _default.Value;

    private readonly Dictionary<string, IFolderLocator> locators;
    private readonly IOcsModService modService;

    private string[] SupportedFolderLocators { get; }

    public OcsDiscoveryService(IEnumerable<IFolderLocator> locators, IOcsModService modService)
    {
        this.locators = locators.ToDictionary(l => l.Id);
        SupportedFolderLocators = locators.Select(l => l.Id).ToArray();

        this.modService = modService;
    }

    public Dictionary<string, GameFolders> FindAllGameFolders()
    {
        var result = new Dictionary<string, GameFolders>();

        foreach (var locator in SupportedFolderLocators)
        {
            if (TryFindGameFolders(locator, out var folders))
            {
                result.Add(locator, folders);
            }
        }

        return result;
    }

    public bool TryFindGameFolders(string locatorId, [MaybeNullWhen(false)] out GameFolders folders)
    {
        if (locatorId.Length == 0)
        {
            return TryFindGameFolders(out folders);
        }

        if (!locators.TryGetValue(locatorId, out var locator))
        {
            throw LocatorNotFound(locatorId);
        }

        if (!locator.TryFind(out var discovered))
        {
            folders = null;
            return false;
        }

        var data = DiscoverFolder(discovered.Data);
        var mod = DiscoverFolder(discovered.Mod);

        if (data is null || mod is null)
        {
            folders = null;
            return false;
        }

        var content = discovered.Content is null ? null : DiscoverFolder(discovered.Content);

        folders = new(new DirectoryInfo(discovered.Game), data, mod, content);
        return true;

        static Exception LocatorNotFound(string locatorId)
        {
            return new ArgumentException($"LocatorId \"{locatorId}\" was not found", nameof(locatorId));
        }
    }

    public bool TryFindGameFolders([MaybeNullWhen(false)] out GameFolders folders)
    {
        foreach (var locatorId in SupportedFolderLocators)
        {
            if (TryFindGameFolders(locatorId, out folders))
            {
                return true;
            }
        }

        folders = null;
        return false;
    }

    public ModFolder? DiscoverFolder(string folder)
    {
        if (!Directory.Exists(folder))
        {
            return null;
        }

        var result = new ModFolder(folder, new());

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

                result.Mods.Add(mod.Name, mod);
            }
        }

        return result;
    }

    public ModFile? DiscoverFile(string file)
    {
        if (!File.Exists(file))
        {
            return null;
        }

        using var reader = new OcsReader(new BinaryReader(File.OpenRead(file)));

        if (!modService.TryReadHeader(reader, out var header))
        {
            return null;
        }

        using var stream = File.OpenRead(OcsIOHelper.GetInfoFileName(file));

        return new(Path.GetFileName(file), file, header, OcsIOHelper.ReadInfo(stream));
    }
}
