using OpenConstructionSet.IO;

namespace OpenConstructionSet.Data;

/// <summary>
/// Multiple mod files can be loaded into a context as base or active items.
/// Allows the editing and saving of the active mod.
/// </summary>
public class OcsDataContext
{
    private readonly IOcsIOService ioService;
    private readonly Installation installation;
    private readonly Dictionary<string, Item> baseItems;

    /// <summary>
    /// Collection of active items.
    /// </summary>
    public Dictionary<string, Item> Items { get; }

    /// <summary>
    /// The name of the mod.
    /// </summary>
    public string ModName { get; }

    /// <summary>
    /// Tracks the last ID used for an Item.
    /// </summary>
    public int LastId { get; set; }

    /// <summary>
    /// The header that will be stored in the mod file.
    /// </summary>
    public Header Header { get; set; }

    /// <summary>
    /// The data for the mod's .info file.
    /// </summary>
    public ModInfo? Info { get; set; }

    /// <summary>
    /// Creates a new OcsDataContext instance.
    /// </summary>
    /// <param name="ioService">The IO service.</param>
    /// <param name="installation">The installation to use.</param>
    /// <param name="items">The active data for editing.</param>
    /// <param name="baseItems">The base data.</param>
    /// <param name="modName">The name of the mod.</param>
    /// <param name="lastId">The last used ID. This should be the largest from all the mods loaded.</param>
    /// <param name="header">An optional header for the active mod.</param>
    /// <param name="info">Optional values the mod's info file.</param>
    public OcsDataContext(IOcsIOService ioService, Installation installation, Dictionary<string, Item> items, Dictionary<string, Item> baseItems, string modName, int lastId, Header? header = null, ModInfo? info = null)
    {
        this.ioService = ioService;
        this.installation = installation;
        Items = items;
        this.baseItems = baseItems;
        ModName = modName.AddModExtension();
        LastId = lastId;
        Header = header ?? new();
        Info = info ?? new();
    }

    /// <summary>
    /// Generates a new ID and creates an item with it.
    /// LastId will be increased.
    /// </summary>
    /// <param name="type">The type of item to create.</param>
    /// <param name="name">The name of the new item.</param>
    /// <returns></returns>
    public Item NewItem(ItemType type, string name)
    {
        LastId++;

        var item = new Item(type, 0, name, $"{LastId}-{ModName}", ItemChanges.New);

        Items.Add(item.StringId, item);

        return item;
    }

    /// <summary>
    /// Saves the active mod to the given path.
    /// </summary>
    /// <param name="path">The path to save the mod to.</param>
    public void Save(string path)
    {
        path = Path.GetFullPath(path);

        var changes = new List<Item>();

        var usedKeys = new HashSet<string>();

        foreach (var pair in Items)
        {
            usedKeys.Add(pair.Key);
            var item = pair.Value;

            if (!baseItems.TryGetValue(item.StringId, out var baseItem))
            {
                var newItem = item.Duplicate();

                newItem.Changes = ItemChanges.New;

                changes.Add(newItem);
            }
            else if (item.TryGetChanges(baseItem, out var changeItem))
            {
                changes.Add(changeItem);
            }
        }

        foreach (var item in baseItems.Values)
        {
            if (usedKeys.Contains(item.StringId))
            {
                continue;
            }

            changes.Add(item.Delete());
        }

        var directory = Path.GetDirectoryName(path);

        if (directory is not null && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        ioService.Write(path, new DataFile(DataFileType.Mod, Header, LastId, changes));

        if (Info is not null)
        {
            var infoPath = OcsPathHelper.GetInfoPath(path);

            ioService.Write(infoPath, Info);
        }
    }

    /// <summary>
    /// Saves the active mod into the given folder.
    /// </summary>
    /// <param name="folder">The mod folder to save to.</param>
    public void Save(ModFolder folder) => Save(OcsPathHelper.GetModPath(folder, ModName));

    /// <summary>
    /// Saves the active mod into the installation's mod folder.
    /// </summary>
    public void Save() => Save(installation.Mod);
}
