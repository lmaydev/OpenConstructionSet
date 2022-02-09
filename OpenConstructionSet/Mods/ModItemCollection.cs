using LMay.Collections;

namespace OpenConstructionSet.Mods;

public class ModItemCollection : SortedKeyedItemCollection<string, ModItem>
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
}
