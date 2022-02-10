using OpenConstructionSet.Installations;

namespace OpenConstructionSet.Mods.Context;

public class ModContext
{
    private readonly Dictionary<string, ModItem> baseItems;
    private readonly IInstallation installation;

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

    public Header Header { get; set; }
    public ModInfoData? Info { get; set; }
    public ModItemCollection Items { get; }
    public int LastId { get; set; }
    public string ModName { get; }

    /// <summary>
    /// Generates a new ID and creates an item with it.
    /// LastId will be increased.
    /// </summary>
    /// <param name="type">The type of item to create.</param>
    /// <param name="name">The name of the new item.</param>
    /// <returns></returns>
    public ModItem NewItem(ItemType type, string name)
    {
        LastId++;

        var stringId = $"{LastId}-{ModName}";

        var item = new ModItem(type, name, stringId);

        Items.Add(item);

        return item;
    }

    public Task SaveAsync() => SaveAsync(installation.Mods.GetModPath(ModName));

    public Task SaveAsync(IModFolder folder, string modName) => SaveAsync(folder.GetModPath(modName, Info?.Id ?? 0));

    public async Task SaveAsync(string path)
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

    private ModFileData GetChanges() => new(Header, LastId, Items.GetChanges(baseItems), Info);
}
