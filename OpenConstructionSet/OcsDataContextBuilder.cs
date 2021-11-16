using OpenConstructionSet.IO.Discovery;

namespace OpenConstructionSet;

/// <summary>
/// Used to build game data and <see cref="OcsDataContext"/>s.
/// </summary>
public class OcsDataContextBuilder : IOcsDataContextBuilder, IOcsDataBuilder
{
    private static readonly Lazy<OcsDataContextBuilder> _default = new(() => new(OcsDiscoveryService.Default, OcsIOService.Default, ModNameResolver.Default));

    /// <summary>
    /// Lazy initiated singleton for when DI is not being used
    /// </summary>
    public static OcsDataContextBuilder Default => _default.Value;

    private readonly IOcsDiscoveryService discoveryService;
    private readonly IOcsIOService ioService;
    private readonly IModNameResolver resolver;

    /// <summary>
    /// Creates a new OcsDataContextBuilder instance.
    /// </summary>
    /// <param name="discoveryService">Used to read enabled mod list.</param>
    /// <param name="ioService">Used to read files.</param>
    /// <param name="resolver">Used to resolve mod names to full paths.</param>
    public OcsDataContextBuilder(IOcsDiscoveryService discoveryService, IOcsIOService ioService, IModNameResolver resolver)
    {
        this.discoveryService = discoveryService;
        this.ioService = ioService;
        this.resolver = resolver;
    }

    /// <inheritdoc />
    public OcsDataContext Build(OcsDataContexOptions options)
    {
        Installation installation = options switch
        {
            OcsDataContexOptions { Installation: not null } o => o.Installation,
            OcsDataContexOptions { InstallationName: not null } o => discoveryService.DiscoverInstallation(o.InstallationName) ?? throw new Exception($"Could not find installation ({o.InstallationName})"),
            _ => discoveryService.DiscoverInstallation() ?? throw new Exception("Could not find any installations"),
        };

        var baseItems = new Dictionary<string, Item>();

        var lastId = 0;

        ModFile? last = null;

        var activeMod = resolver.Resolve(installation.ToModFolderArray(), options.Name);

        ReadBaseMods();

        var items = baseItems.Values.ToDictionary(i => i.StringId, i => new DataItem(i));

        ReadActiveMods();

        var header = options.Header ?? last?.Header;
        var info = options.Info ?? last?.Info;

        return new OcsDataContext(ioService, installation, items, baseItems, options.Name, lastId, header, info);

        void ReadBaseMods()
        {
            var mods = new List<string>();

            if (options.LoadGameFiles == ModLoadType.Base)
            {
                mods.AddRange(OcsConstants.BaseMods);
            }

            if (options.LoadEnabledMods == ModLoadType.Base)
            {
                mods.AddRange(installation.EnabledMods);
            }

            if (options.BaseMods is not null)
            {
                mods.AddRange(options.BaseMods);
            }

            var modFiles = Resolve(mods, installation, options.ThrowIfMissing);

            ReadMods(modFiles, baseItems.AddOrUpdate, ref lastId, out _);
        }

        void ReadActiveMods()
        {
            var mods = new List<string>();

            if (options.LoadGameFiles == ModLoadType.Active)
            {
                mods.AddRange(OcsConstants.BaseMods);
            }

            if (options.LoadEnabledMods == ModLoadType.Active)
            {
                mods.AddRange(installation.EnabledMods);
            }

            if (options.ActiveMods is not null)
            {
                mods.AddRange(options.ActiveMods);
            }

            var modFiles = Resolve(mods, installation, options.ThrowIfMissing);

            ReadMods(modFiles, items.AddOrUpdate, ref lastId, out last);

            if (activeMod is not null)
            {
                lastId = Math.Max(lastId, ReadFile(activeMod, items.AddOrUpdate));
            }
        }
    }

    /// <inheritdoc />
    public DataFile Build(OcsDataOptions options)
    {
        var installation = options switch
        {
            OcsDataOptions { Installation: not null } o => o.Installation,
            OcsDataOptions { InstallationName: not null } o => discoveryService.DiscoverInstallation(o.InstallationName) ?? throw new Exception($"Could not find installation ({o.InstallationName})"),
            _ => discoveryService.DiscoverInstallation() ?? throw new Exception("Could not find any installations"),
        };

        var items = new Dictionary<string, Item>();

        var lastId = 0;

        var mods = new List<string>();

        if (options.LoadGameFiles)
        {
            mods.AddRange(OcsConstants.BaseMods);
        }

        if (options.LoadEnabledMods)
        {
            mods.AddRange(installation.EnabledMods);
        }

        if (options.Mods is not null)
        {
            mods.AddRange(options.Mods);
        }

        var modFiles = Resolve(mods, installation, options.ThrowIfMissing);

        ReadMods(modFiles, items.AddOrUpdate, ref lastId, out var last);

        return new(DataFileType.Mod, last?.Header, lastId, items.Values.ToList());
    }

    private static void ReadMods(IEnumerable<ModFile> mods, Action<Item> AddOrUpdate, ref int lastId, out ModFile? last)
    {
        last = null;

        foreach (var mod in mods)
        {
            lastId = Math.Max(lastId, ReadFile(mod, AddOrUpdate));

            last = mod;
        }
    }

    private static int ReadFile(ModFile file, Action<Item> AddOrUpdate)
    {
        using var reader = new OcsReader(File.OpenRead(file.FullName));

        var type = (DataFileType)reader.ReadInt();

        if (type == DataFileType.Mod)
        {
            reader.ReadHeader();
        }

        var lastId = reader.ReadInt();

        reader.ReadItems().ForEach(AddOrUpdate);

        return lastId;
    }

    private IEnumerable<ModFile> Resolve(IEnumerable<string> mods, Installation installation, bool throwIfMissing) => resolver.Resolve(installation.ToModFolderArray(), mods, throwIfMissing).DistinctBy(m => m.Name);
}
