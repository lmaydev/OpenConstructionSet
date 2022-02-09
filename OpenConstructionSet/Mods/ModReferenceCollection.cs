using LMay.Collections;

namespace OpenConstructionSet.Mods;

public class ModReferenceCollection : SortedKeyedItemCollection<string, ModReference>
{
    private readonly ModReferenceCategory parent;

    internal ModReferenceCollection(ModReferenceCategory parent, IEnumerable<IReference> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModReferenceCollection(ModReferenceCategory parent)
    {
        this.parent = parent;
    }

    internal ModContext? Owner => parent.Owner;

    public override void Add(ModReference item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void Add(string targetId, int value0 = 0, int value1 = 0, int value2 = 0) => Add(new ModReference(targetId, value0, value1, value2));

    public void Add(IItem target, int value0 = 0, int value1 = 0, int value2 = 0) => Add(target.StringId, value0, value1, value2);

    public void AddFrom(IReference reference) => Add(reference is ModReference mr ? mr : new ModReference(reference));
}
