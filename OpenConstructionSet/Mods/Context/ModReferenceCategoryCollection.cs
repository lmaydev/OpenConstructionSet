using LMay.Collections;

namespace OpenConstructionSet.Mods.Context;

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

    public IEnumerable<ReferenceCategory> GetChanges(ModReferenceCategoryCollection baseCategories)
    {
        foreach (var category in this)
        {
            if (!baseCategories.TryGetValue(category.Key, out var baseCategory))
            {
                yield return new ReferenceCategory(category);
            }
            else if (category.References.TryGetChanges(baseCategory.References, out var referencChanges))
            {
                yield return new ReferenceCategory(category.Name, referencChanges);
            }
        }

        foreach (var category in baseCategories.Where(c => !ContainsKey(c.Key))
                                               .Select(c => new ReferenceCategory(c.Name, c.References.Select(c => c.AsDeleted()))))
        {
            yield return category;
        }
    }
}
