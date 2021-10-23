using OpenConstructionSet.IO;
using OpenConstructionSet.IO.Discovery;

namespace OpenConstructionSet;

/// <inheritdoc/>
public class OcsDataContextBuilder : IOcsDataContextBuilder
{
    private static readonly Lazy<OcsDataContextBuilder> _default = new(() => new(OcsService.Default, ModNameResolver.Default));

    /// <summary>
    /// Lazy initiated singlton for when DI is not being used
    /// </summary>
    public static OcsDataContextBuilder Default => _default.Value;

    private readonly IOcsService ocsService;
    private readonly IModNameResolver resolver;

    /// <summary>
    /// Creates a new OcsDataContextBuilder instance.
    /// </summary>
    /// <param name="ocsService">Used to read enabled mod list.</param>
    /// <param name="resolver">Used to resolve mod names to full paths.</param>
    public OcsDataContextBuilder(IOcsService ocsService, IModNameResolver resolver)
    {
        this.ocsService = ocsService;
        this.resolver = resolver;
    }

    /// <summary>
    /// Builds a <see cref="OcsDataContext"/> from the provided options
    /// </summary>
    /// <param name="name">The name of the mod e.g. example.mod</param>
    /// <param name="throwIfMissing">If <c>true</c> missing mods will cause exceptions to be thrown.</param>
    /// <param name="folders">A collection of folders used when resolving mod names. If loading game files <c>folders</c> can not be <c>null</c>.</param>
    /// <param name="baseMods">A collection of mods to load as the base data.</param>
    /// <param name="activeMods">A collection of mods to load as active. When saving data from these mods will be saved along with any changes.</param>
    /// <param name="header">Header for the new mod.</param>
    /// <param name="info">Values for the mod's info file.</param>
    /// <param name="loadGameFiles">If not <c>None</c> the base game files will be loaded as specified.</param>
    /// <param name="loadEnabledMods">If not <c>ModLoadType</c>.None will load the game's enabled mod files as specified.</param>
    /// <returns>An OcsDataContext built from the provided values.</returns>
    public OcsDataContext Build(string name, bool throwIfMissing = true, IEnumerable<ModFolder>? folders = null, IEnumerable<string>? baseMods = null,
        IEnumerable<string>? activeMods = null, Header? header = null, ModInfo? info = null, ModLoadType loadGameFiles = ModLoadType.None,
        ModLoadType loadEnabledMods = ModLoadType.None)
    {
        folders ??= Enumerable.Empty<ModFolder>();

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

        return new OcsDataContext(items, baseItems, name, lastId, header, info);

        void ReadFile(ModFile file, bool active)
        {
            using var reader = new OcsReader(File.OpenRead(file.FullName));

            var type = (FileType)reader.ReadInt();

            if (type == FileType.Mod)
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
                item.Update(data);
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
            var loadOrder = folders.Select(f => ocsService.ReadLoadOrder(f.FullName)).FirstOrDefault(lo => lo is not null);

            if (loadOrder is null)
            {
                if (throwIfMissing)
                {
                    throw new Exception("Could not read enabled mods");
                }

                return;
            }

            var mods = Resolve(loadOrder);
        }

        IEnumerable<ModFile> Resolve(IEnumerable<string> mods)
        {
            return resolver.Resolve(folders, mods, throwIfMissing).DistinctBy(m => m.Name);
        }
    }
}
