namespace OpenConstructionSet.Mods.Context;

public class ModItemCollection : KeyedItemCollection<string, ModItem>
{
    internal ModItemCollection(ModContext owner, IEnumerable<IItem> collection) : this(owner)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModItemCollection(ModContext owner)
    {
        Owner = owner;
    }

    internal ModContext Owner { get; }

    public override void Add(ModItem item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void AddFrom(IItem reference) => Add(reference is ModItem mr ? mr : new ModItem(reference));

    public IEnumerable<Item> GetChanges(IDictionary<string, ModItem> baseItems)
    {
        foreach (var item in this)
        {
            if (!baseItems.TryGetValue(item.Key, out var baseItem))
            {
                yield return new Item(item.Type, 0, item.Name, item.StringId, ItemChangeType.New);
            }
            else if (item.TryGetChanges(baseItem, out var changes))
            {
                yield return changes;
            }
        }

        foreach (var item in baseItems.Values.Where(i => !ContainsKey(i.Key)))
        {
            yield return new Item(item.AsDeleted());
        }
    }
}
