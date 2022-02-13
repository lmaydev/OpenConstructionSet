namespace OpenConstructionSet.Mods.Context;

/// <summary>
/// Collection to manage <see cref="ModItem"/>s.
/// </summary>
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

    /// <summary>
    /// Adds the provided <see cref="ModItem"/> to the collection.
    /// </summary>
    /// <param name="item">The <see cref="ModItem"/> to add.</param>
    public override void Add(ModItem item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    /// <summary>
    /// Adds a new <see cref="ModItem"/> based on the provided <see cref="IItem"/>.
    /// If the <see cref="IItem"/> is a <see cref="ModItem"/> it will be added without recreation.
    /// </summary>
    /// <param name="reference">The <see cref="IReference"/> to add.</param>
    public void AddFrom(IItem reference) => Add(reference is ModItem mr ? mr : new ModItem(reference));

    /// <summary>
    /// Compares this collection with another returning any changes.
    /// </summary>
    /// <param name="baseItems">Collection to comapre to this one.</param>
    /// <returns>A collection containing the added or modified <see cref="Item"/>s.</returns>
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
