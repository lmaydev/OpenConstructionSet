using LMay.Collections;

namespace OpenConstructionSet.Mods;

public class ModReferenceCategoryCollection : SortedKeyedItemCollection<string, ModReferenceCategory>
{
    private readonly ModItem parent;

    public ModReferenceCategoryCollection(ModItem parent, IEnumerable<IReferenceCategory> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModReferenceCategoryCollection(ModItem parent)
    {
        this.parent = parent;
    }

    internal ModContext? Owner => parent.Owner;

    public override void Add(ModReferenceCategory item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void Add(string name) => Add(new ModReferenceCategory(name));

    public void AddFrom(IReferenceCategory category) => Add(category is ModReferenceCategory mrc ? mrc : new ModReferenceCategory(category));
}
