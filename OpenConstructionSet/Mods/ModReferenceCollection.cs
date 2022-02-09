using LMay.Collections;

namespace OpenConstructionSet.Mods;

public class ModInstanceCollection : KeyedItemList<string, ModInstance>
{
    private readonly ModItem parent;

    internal ModInstanceCollection(ModItem parent, IEnumerable<IInstance> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModInstanceCollection(ModItem parent)
    {
        this.parent = parent;
    }

    internal ModContext? Owner => parent.Owner;

    public override void Add(ModInstance item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void AddFrom(IInstance instance) => Add(instance is ModInstance mi ? mi : new ModInstance(instance));
}

public class ModItemCollection : SortedKeyedItemCollection<string, ModItem>
{
    private readonly ModContext parent;

    internal ModItemCollection(ModContext parent, IEnumerable<IItem> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModItemCollection(ModContext parent)
    {
        this.parent = parent;
    }

    internal ModContext Owner => parent;

    public override void Add(ModItem item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void AddFrom(IItem reference) => Add(reference is ModItem mr ? mr : new ModItem(reference));
}

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
