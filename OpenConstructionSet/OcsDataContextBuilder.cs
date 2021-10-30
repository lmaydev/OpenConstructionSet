using OpenConstructionSet.IO.Discovery;

namespace OpenConstructionSet;

/// <inheritdoc/>
public class OcsDataContextBuilder : IOcsDataContextBuilder
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
        // if installation is null try and discover one. If this returns null throw an exception
        var installation = options.Installation ?? discoveryService.DiscoverInstallation() ?? throw new Exception("Could not locate game");

        var baseMods = options.BaseMods is not null ? Resolve(options.BaseMods) : Enumerable.Empty<ModFile>();
        var activeMods = options.ActiveMods is not null ? Resolve(options.ActiveMods) : Enumerable.Empty<ModFile>();

        var baseItems = new Dictionary<string, Item>();
        var items = new Dictionary<string, Item>();

        var lastId = 0;

        var header = options.Header;
        var info = options.Info;

        ModFile ? last = null;

        if (options.LoadGameFiles == ModLoadType.Base)
        {
            LoadGameFiles(false);
        }

        if (options.LoadEnabledMods == ModLoadType.Base)
        {
            LoadEnabledMods(false);
        }

        baseMods.ForEach(m => ReadFile(m, false));

        items = baseItems.Values.ToDictionary(i => i.StringId, i => i.Duplicate());

        if (options.LoadGameFiles == ModLoadType.Active)
        {
            LoadGameFiles(true);
        }

        if (options.LoadEnabledMods == ModLoadType.Active)
        {
            LoadEnabledMods(true);
        }

        activeMods.DistinctBy(m => m.Name).ForEach(m => ReadFile(m, true));

        if (last is not null)
        {
            if (header is null)
            {
                header = last.Header;
            }

            if (info is null)
            {
                info = last.Info;
            }
        }

        return new OcsDataContext(ioService, installation, items, baseItems, options.Name, lastId, header, info);

        void ReadFile(ModFile file, bool active)
        {
            using var reader = new OcsReader(File.OpenRead(file.FullName));

            var type = (DataFileType)reader.ReadInt();

            if (type == DataFileType.Mod)
            {
                reader.ReadHeader();
            }

            lastId = Math.Max(lastId, reader.ReadInt());

            reader.ReadItems().ForEach(i => AddOrUpdate(i, active));

            if (active)
            {
                last = file;
            }
        }

        void AddOrUpdate(Item data, bool active)
        {
            var dictionary = active ? items : baseItems;

            if (data.IsDeleted())
            {
                dictionary.Remove(data.StringId);
                return;
            }

            if (dictionary.TryGetValue(data.StringId, out var item))
            {
                item.ApplyChanges(data);
            }
            else
            {
                dictionary[data.StringId] = data;
            }
        }

        void LoadGameFiles(bool active)
        {
            Resolve(OcsConstants.BaseMods).ForEach(m => ReadFile(m, active));
        }

        void LoadEnabledMods(bool active)
        {
            var mods = Resolve(installation.EnabledMods);
        }

        IEnumerable<ModFile> Resolve(IEnumerable<string> mods)
        {
            return resolver.Resolve(installation.ToModFolderArray(), mods, options.ThrowIfMissing).DistinctBy(m => m.Name);
        }
    }
}
