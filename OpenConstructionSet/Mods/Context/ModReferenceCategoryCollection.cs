using System.Collections.ObjectModel;

namespace OpenConstructionSet.Mods.Context;

/// <summary>
/// Collection to manage <see cref="ModReferenceCategory"/> objects.
/// </summary>
public class ModReferenceCategoryCollection : KeyedCollection<string, ModReferenceCategory>
{
    private readonly ModItem parent;

    internal ModReferenceCategoryCollection(ModItem parent, IEnumerable<IReferenceCategory> collection) : this(parent)
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

    protected override void InsertItem(int index, ModReferenceCategory item)
    {
        item.SetParent(this);
        base.InsertItem(index, item);
    }

    protected override void SetItem(int index, ModReferenceCategory item)
    {
        item.SetParent(this);
        base.SetItem(index, item);
    }

    /// <summary>
    /// Adds a new <see cref="ModReferenceCategory"/> to the collection with the provided name.
    /// </summary>
    /// <param name="name">Unique name.</param>
    public void Add(string name) => Add(new ModReferenceCategory(name));

    /// <summary>
    /// Adds a new <see cref="ModReferenceCategory"/> based on the provided <see cref="IReferenceCategory"/>.
    /// If the <see cref="IReferenceCategory"/> is a <see cref="ModReferenceCategory"/> it will be added without recreation.
    /// </summary>
    /// <param name="category">The <see cref="IReferenceCategory"/> to add.</param>
    public void AddFrom(IReferenceCategory category) => Add(category is ModReferenceCategory mrc ? mrc : new ModReferenceCategory(category));

    /// <summary>
    /// Compares this collection with another returning any changes.
    /// </summary>
    /// <param name="baseCategories">Collection to comapre to this one.</param>
    /// <returns>A collection containing the added or modified <see cref="ReferenceCategory"/>s.</returns>
    public IEnumerable<ReferenceCategory> GetChanges(ModReferenceCategoryCollection baseCategories)
    {
        foreach (var category in this)
        {
            if (!baseCategories.TryGetValue(category.Name, out var baseCategory))
            {
                yield return new ReferenceCategory(category);
            }
            else if (category.References.TryGetChanges(baseCategory.References, out var referencChanges))
            {
                yield return new ReferenceCategory(category.Name, referencChanges);
            }
        }

        foreach (var category in baseCategories.Where(c => !TryGetValue(c.Name, out var _))
                                               .Select(c => new ReferenceCategory(c.Name, c.References.Select(c => c.AsDeleted()))))
        {
            yield return category;
        }
    }

    protected override string GetKeyForItem(ModReferenceCategory item) => item.Name;
}
