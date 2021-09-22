using OpenConstructionSet.Collections;
using OpenConstructionSet.IO;
using OpenConstructionSet.IO.Discovery;
using System.ComponentModel;

namespace OpenConstructionSet.Data;

public class OcsDataContextBuilder : IOcsDataContextBuilder
{
    private static readonly Lazy<OcsDataContextBuilder> _default = new(() => new(ModNameResolver.Default));

    public static OcsDataContextBuilder Default => _default.Value;

    private readonly IModNameResolver resolver;

    public OcsDataContextBuilder(IModNameResolver resolver) => this.resolver = resolver;

    /// <summary>
    /// Builds a <see cref="OcsDataContext"/> from the provided options
    /// </summary>
    /// <param name="name">The name of the mod e.g. example.mod</param>
    /// <param name="folders">A collection of folders used when resolving mod names. If loading game files or enabled mods <c>folders</c> can not be <c>null</c>.</param>
    /// <param name="baseMods">A collection of mods to load as the base data.</param>
    /// <param name="activeMods">A collection of mods to load as active. When saving data from these mods will be saved along with any changes.</param>
    /// <param name="header">Header for the new mod</param>
    /// <param name="info"></param>
    /// <param name="loadGameFiles"></param>
    /// <param name="loadEnabledMods"></param>
    /// <returns></returns>
    public OcsDataContext Build(string name, bool throwIfMissing = true, IEnumerable<ModFolder>? folders = null, IEnumerable<string>? baseMods = null,
        IEnumerable<string>? activeMods = null, Header? header = null, ModInfo? info = null, ModLoadType loadGameFiles = ModLoadType.None)
    {
        folders ??= Enumerable.Empty<ModFolder>();

        var baseModFiles = baseMods is not null ? Resolve(baseMods) : Enumerable.Empty<ModFile>();
        var activeModFiles = activeMods is not null ? Resolve(activeMods) : Enumerable.Empty<ModFile>();

        var items = new OcsRefDictionary<Entity>();

        var lastId = 0;

        Stack<ModFile> loaded = new();

        if (loadGameFiles == ModLoadType.Base)
        {
            LoadGameFiles(false);
        }

        baseModFiles.ForEach(m => ReadFile(m, false));

        // Set base data as original values. All changes after this will be part of the active mod.
        (items as IChangeTracking)?.AcceptChanges();

        if (loadGameFiles == ModLoadType.Active)
        {
            LoadGameFiles(true);
        }

        activeModFiles.DistinctBy(m => m.Name).ForEach(m => ReadFile(m, true));

        if (loaded.TryPop(out var last))
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

        return new OcsDataContext(items, name, lastId, header, info);

        void ReadFile(ModFile file, bool active)
        {
            using var reader = new OcsReader(File.OpenRead(file.FullName));

            var type = (FileType)reader.ReadInt();

            if (type != FileType.Mod)
            {
                throw new InvalidOperationException($"Invalid file type. Expected Mod (16); received {type}");
            }

            reader.ReadHeader();

            lastId = Math.Max(lastId, reader.ReadInt());

            reader.ReadItems().ForEach(AddOrUpdate);

            if (active)
            {
                loaded.Push(file);
            }
        }

        void AddOrUpdate(Item data)
        {
            if (!items.TryGetValue(data.StringId, out var item))
            {
                item = items.New(data.StringId, data.Name, data.Type);
            }

            item.Update(data);
        }

        void LoadGameFiles(bool active)
        {
            Resolve(OcsConstants.BaseMods).ForEach(m => ReadFile(m, active));
        }

        IEnumerable<ModFile> Resolve(IEnumerable<string> mods)
        {
            return resolver.Resolve(folders, mods, throwIfMissing).DistinctBy(m => m.Name);
        }
    }
}
