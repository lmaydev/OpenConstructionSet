using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet.Mods;

/// <inheritdoc/>
public class ModItem : IItem
{
    internal ModItemCollection? parent;

    /// <summary>
    /// Creates a new <see cref="ModItem"/> from another.
    /// </summary>
    /// <param name="item">The <see cref="ModItem"/> to copy.</param>
    public ModItem(IItem item) : this(
        item.Type,
        item.Name,
        item.StringId,
        item.SaveData,
        item.Values,
        item.ReferenceCategories,
        item.Instances)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ModItem"/> from the provided data.
    /// </summary>
    /// <param name="type">The <see cref="ItemType"/> for this <see cref="ModItem"/>.</param>
    /// <param name="name">The name of this <see cref="ModItem"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="ModItem"/>.</param>
    ///
    public ModItem(ItemType type, string name, string stringId, ItemSaveData saveData) : this(type, name, stringId, saveData, new Dictionary<string,object>(), [], [])
    {
    }

    /// <summary>
    /// Creates a new <see cref="ModItem"/> from the provided data.
    /// </summary>
    /// <param name="type">The <see cref="ItemType"/> for this <see cref="ModItem"/>.</param>
    /// <param name="name">The name of this <see cref="ModItem"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="ModItem"/>.</param>
    /// <param name="saveData">The types of changes that have been applied to this <see cref="Item"/> and its save count.</param>
    /// <param name="values">Dictionary of values stored by this <see cref="ModItem"/>.</param>
    /// <param name="referenceCategories">
    /// Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="ModItem"/>.
    /// </param>
    /// <param name="instances">Collection of <see cref="Instance"/> s stored by this <see cref="ModItem"/>.</param>
    ///
    public ModItem(ItemType type, string name, string stringId, ItemSaveData saveData, IDictionary<string, object> values, IEnumerable<IReferenceCategory> referenceCategories, IEnumerable<IInstance> instances)
    {
        Type = type;
        Name = name;
        StringId = stringId;

        (this as IItem).SaveData = saveData;

        this.Values = new(values);
        this.ReferenceCategories = new(this, referenceCategories);
        this.Instances = new(this, instances);
    }

    /// <summary>
    /// Collection of <see cref="Instance"/> s stored by this <see cref="ModItem"/>.
    /// </summary>
    public ModInstanceCollection Instances { get; }

    /// <inheritdoc/>
    public string Name { get; set; }

    /// <summary>
    /// Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="ModItem"/>.
    /// </summary>
    public ModReferenceCategoryCollection ReferenceCategories { get; }

    /// <inheritdoc/>
    public string StringId { get; }

    /// <inheritdoc/>
    public ItemType Type { get; set; }

    /// <summary>
    /// Dictionary of values stored by this <see cref="ModItem"/>.
    /// </summary>
    public SortedDictionary<string, object> Values { get; }

    ItemSaveData IItem.SaveData { get; set; }
    int IItem.Id { get => 0; }
    IEnumerable<IInstance> IItem.Instances => Instances;
    IEnumerable<IReferenceCategory> IItem.ReferenceCategories => ReferenceCategories;
    IDictionary<string, object> IItem.Values => Values;
    internal ModContext? Owner => parent?.Owner;

    /// <summary>
    /// Returns an <see cref="Item"/> that represents this marked as deleted.
    /// </summary>
    /// <returns>An <see cref="Item"/> that represents this marked as deleted.</returns>
    public Item AsDeleted()
    {
        var deleted = new Item(Type, 0, Name, StringId, (uint)ItemChangeType.Changed);

        deleted.Values["DELETED"] = true;

        return deleted;
    }

    /// <summary>
    /// Performs a deep clone of this object.
    /// </summary>
    /// <returns>A deep clone of this object.</returns>
    public ModItem DeepClone()
    {
        return new ModItem(Type, Name, StringId, (this as IItem).SaveData, Values, ReferenceCategories.Select(c => c.DeepClone()),
            Instances.Select(i => i.DeepClone()));
    }

    /// <summary>
    /// Determines if this <see cref="ModItem"/> is marked as deleted.
    /// </summary>
    /// <returns><c>true</c> if this <see cref="ModItem"/> is deleted; otherwise, <c>false</c>.</returns>
    public bool IsDeleted() => Values.TryGetValue("DELETED", out var value) && value is bool deleted && deleted;

    /// <summary>
    /// Attempts to get an <see cref="Item"/> representing the changes between this and the provided <c>baseItem</c>.
    /// </summary>
    /// <param name="baseItem">Base item to compare to.</param>
    /// <param name="changes">If successful will contain the changes.</param>
    /// <returns><c>true</c> if there are changes; otherwise, <c>false</c>.</returns>
    public bool TryGetChanges(ModItem baseItem, [MaybeNullWhen(false)] out Item changes)
    {
        var saveData = new ItemSaveData((this as IItem).SaveData.SaveCount + 1, Name != baseItem.Name ? ItemChangeType.Renamed : ItemChangeType.Changed);

        changes = new Item(Type, 0, Name, baseItem.StringId, saveData);

        // Add any new or changed values
        foreach (var pair in Values.Where(pair => !baseItem.Values.TryGetValue(pair.Key, out var baseValue)
                                                  || baseValue != pair.Value))
        {
            changes.Values[pair.Key] = pair.Value;
        }

        changes.ReferenceCategories.AddRange(ReferenceCategories.GetChanges(baseItem.ReferenceCategories));

        changes.Instances.AddRange(Instances.GetChanges(baseItem.Instances));

        if (changes.SaveData.ChangeType == ItemChangeType.Renamed
            || changes.Values.Count > 0
            || changes.ReferenceCategories.Count > 0
            || changes.Instances.Count > 0)
        {
            return true;
        }

        changes = null;

        return false;
    }

    internal void SetParent(ModItemCollection? newOwner)
    {
        parent?.Remove(this);
        parent = newOwner;
    }
}
