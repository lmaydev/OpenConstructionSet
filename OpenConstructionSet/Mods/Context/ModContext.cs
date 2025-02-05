using OpenConstructionSet.Installations;

namespace OpenConstructionSet.Mods.Context;

/// <inheritdoc/>
public class ModContext : IModContext
{
    private readonly Dictionary<string, ModItem> baseItems;
    private readonly IInstallation installation;

    /// <summary>
    /// Creates a new <see cref="ModContext"/> from the provided data.
    /// </summary>
    /// <param name="baseItems">
    /// Collection of item's loaded as base data. Used to compare for changes when saving.
    /// </param>
    /// <param name="activeItems">
    /// Collection of item's loaded as active data. Used for editing the mod.
    /// </param>
    /// <param name="installation">The installation to use when saving.</param>
    /// <param name="modName">The name of the mod when saving.</param>
    /// <param name="lastId">The last ID used when generating an <see cref="IItem.StringId"/>.</param>
    /// <param name="header">The header to use for the mod.</param>
    /// <param name="info">Optional data for the mod's .info file.</param>
    public ModContext(Dictionary<string, ModItem> baseItems, IEnumerable<ModItem> activeItems, IInstallation installation, string modName, int lastId, Header? header = null, ModInfoData? info = null)
    {
        this.baseItems = baseItems;
        Items = new(this, activeItems);

        this.installation = installation;
        ModName = modName.AddModExtension();

        LastId = lastId;
        Header = header ?? new Header();
        Info = info;
    }

    /// <inheritdoc/>
    public Header Header { get; set; }

    /// <inheritdoc/>
    public ModInfoData? Info { get; set; }

    /// <inheritdoc/>
    public ModItemCollection Items { get; }

    /// <inheritdoc/>
    public int LastId { get; set; }

    /// <inheritdoc/>
    public string ModName { get; }

    /// <inheritdoc/>
    public virtual ModItem NewItem(ItemType type, string name)
    {
        LastId++;

        var stringId = $"{LastId}-{ModName}";

        var item = new ModItem(type, name, stringId, new ItemSaveData(0, ItemChangeType.New));

        Items.Add(item);

        return item;
    }

    /// <inheritdoc/>
    public virtual Task SaveAsync() => SaveAsync(installation.Mods.GetModPath(ModName));

    /// <inheritdoc/>
    public virtual Task SaveAsync(IModFolder folder, string modName) => SaveAsync(folder.GetModPath(modName, Info?.Id ?? 0));

    /// <inheritdoc/>
    public virtual async Task SaveAsync(string path)
    {
        var directory = Path.GetDirectoryName(path);

        if (directory is not null && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var mod = new ModFile(path);

        // TODO Determine if needed.
        var data = await Task.Run(GetChanges).ConfigureAwait(false);

        await mod.WriteDataAsync(data).ConfigureAwait(false);
    }

    private ModFileData GetChanges() => new(DataFileType.Mod, Header, LastId, Items.GetChanges(baseItems), Info);
}
