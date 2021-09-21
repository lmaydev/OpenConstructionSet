using OpenConstructionSet.Collections;
using OpenConstructionSet.IO;
using System.ComponentModel;

namespace OpenConstructionSet.Data;

public class OcsDataContext : IRevertibleChangeTracking
{
    private readonly PropertyTracker properties = new();
    private readonly IOcsModService modService;

    public OcsRefDictionary<Entity> Items { get; }
    public string ModName { get; }

    public int LastId
    {
        get => properties.Get<int>(nameof(LastId));

        set => properties.Set(nameof(LastId), value);
    }

    public Header Header { get; set; }

    public ModInfo? Info { get; set; }

    public bool IsChanged => Items.IsChanged || properties.IsChanged;

    public OcsDataContext(IOcsModService modService, OcsRefDictionary<Entity> items, string modName, int lastId, Header? header = null, ModInfo? info = null)
    {
        Items = items;
        ModName = modName.AddModExtension();
        LastId = lastId;
        Header = header ?? new();
        Info = info ?? new();

        this.modService = modService;
    }

    public Entity NewItem(ItemType type, string name)
    {
        LastId++;

        return Items.New($"{LastId}-{ModName}", name, type);
    }

    public void RejectChanges()
    {
        properties.RejectChanges();

        Items.RejectChanges();
    }

    void IChangeTracking.AcceptChanges()
    {
        properties.AcceptChanges();

        (Items as IChangeTracking)?.AcceptChanges();
    }

    public void Save(string path)
    {
        var items = new List<Item>();

        var changes = Items.GetChanges();

        changes.Removed.Values.ForEach(item => items.Add(item.AsDeleted()));

        changes.Added.Values.ForEach(item => items.Add(item.GetChanges(true)));

        changes.Modified.Values.ForEach(item => items.Add(item.GetChanges(false)));

        using var writer = new OcsWriter(new(File.Create(path)));

        modService.Write(writer, Header, LastId, items);

        if (Info is not null)
        {
            using var stream = File.OpenRead(OcsIOHelper.GetInfoFileName(path));

            Info.WriteInfo(stream);
        }
    }

    public void Save(ModFolder folder) => Save(modService.GetPath(folder, ModName));
}
