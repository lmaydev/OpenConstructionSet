using OpenConstructionSet.IO;

namespace OpenConstructionSet.Data;

public class OcsDataContext
{
    private readonly Dictionary<string, Item> baseItems;

    public Dictionary<string, Item> Items { get; }
    public string ModName { get; }

    public int LastId { get; set; }

    public Header Header { get; set; }

    public ModInfo? Info { get; set; }

    public OcsDataContext(Dictionary<string, Item> items, Dictionary<string, Item> baseItems, string modName, int lastId, Header? header = null, ModInfo? info = null)
    {
        Items = items;
        this.baseItems = baseItems;
        ModName = modName.AddModExtension();
        LastId = lastId;
        Header = header ?? new();
        Info = info ?? new();
    }

    public Item NewItem(ItemType type, string name)
    {
        LastId++;

        return new(type, 0, name, $"{LastId}-{ModName}", ItemChanges.New);
    }

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

            changes.Add(item.AsDeleted());
        }

        var directory = Path.GetDirectoryName(path);

        if (directory is not null && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        using var writer = new OcsWriter(File.Create(path));

        writer.WriteMod(Header, LastId, changes);

        if (Info is not null)
        {
            var infoPath = OcsIOHelper.GetInfoPath(path);

            if (File.Exists(infoPath))
            {
                File.Delete(infoPath);
            }

            using var stream = File.Create(infoPath);

            Info.WriteInfo(stream);
        }
    }

    public void Save(ModFolder folder) => Save(OcsIOHelper.GetModPath(folder, ModName));
}
