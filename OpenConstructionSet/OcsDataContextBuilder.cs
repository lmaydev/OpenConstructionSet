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
    public OcsDataContext Build(string name, bool throwIfMissing = true, Installation? installation = null, IEnumerable<string>? baseMods = null,
        IEnumerable<string>? activeMods = null, Header? header = null, ModInfo? info = null, ModLoadType loadGameFiles = ModLoadType.None,
        ModLoadType loadEnabledMods = ModLoadType.None)
    {
        // if installation is null try and discover one. If this returns null throw an exception
        installation ??= discoveryService.FindInstallation() ?? throw new Exception("Could not locate game");

        var baseModFiles = baseMods is not null ? Resolve(baseMods) : Enumerable.Empty<ModFile>();
        var activeModFiles = activeMods is not null ? Resolve(activeMods) : Enumerable.Empty<ModFile>();

        var baseItems = new Dictionary<string, Item>();
        var items = new Dictionary<string, Item>();

        var lastId = 0;

        ModFile? last = null;

        if (loadGameFiles == ModLoadType.Base)
        {
            LoadGameFiles(false);
        }

        if (loadEnabledMods == ModLoadType.Base)
        {
            LoadEnabledMods(false);
        }

        baseModFiles.ForEach(m => ReadFile(m, false));

        items = baseItems.Values.ToDictionary(i => i.StringId, i => i.Duplicate());

        if (loadGameFiles == ModLoadType.Active)
        {
            LoadGameFiles(true);
        }

        if (loadEnabledMods == ModLoadType.Active)
        {
            LoadEnabledMods(true);
        }

        activeModFiles.DistinctBy(m => m.Name).ForEach(m => ReadFile(m, true));

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

        return new OcsDataContext(ioService, installation, items, baseItems, name, lastId, header, info);

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
            return resolver.Resolve(installation.ToModFolderArray(), mods, throwIfMissing).DistinctBy(m => m.Name);
        }
    }
}
