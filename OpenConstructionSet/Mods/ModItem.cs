using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet.Mods;

/// <summary>
/// Represents an item in the games data. All entites in the game are represented using these.
/// </summary>
public class ModItem : IItem, IKeyedItem<string>
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
    public ModItem(ItemType type, string name, string stringId)
    {
        Type = type;
        Name = name;
        StringId = stringId;

        Values = new();
        ReferenceCategories = new(this);
        Instances = new(this);
    }

    /// <summary>
    /// Creates a new <see cref="ModItem"/> from the provided data.
    /// </summary>
    /// <param name="type">The <see cref="ItemType"/> for this <see cref="ModItem"/>.</param>
    /// <param name="name">The name of this <see cref="ModItem"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="ModItem"/>.</param>
    /// <param name="values">Dictionary of values stored by this <see cref="ModItem"/>.</param>
    /// <param name="referenceCategories">
    /// Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="ModItem"/>.
    /// </param>
    /// <param name="instances">Collection of <see cref="Instance"/> s stored by this <see cref="ModItem"/>.</param>
    ///
    public ModItem(ItemType type, string name, string stringId, IDictionary<string, object> values, IEnumerable<IReferenceCategory> referenceCategories, IEnumerable<IInstance> instances)
    {
        Type = type;
        Name = name;
        StringId = stringId;

        this.Values = new(values);
        this.ReferenceCategories = new(this, referenceCategories);
        this.Instances = new(this, instances);
    }

    /// <summary>
    /// Collection of <see cref="Instance"/> s stored by this <see cref="ModItem"/>.
    /// </summary>
    public ModInstanceCollection Instances { get; }

    public string Key => StringId;

    /// <summary>
    /// The name of this <see cref="ModItem"/>.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="ModItem"/>.
    /// </summary>
    public ModReferenceCategoryCollection ReferenceCategories { get; }

    /// <summary>
    /// The unique string identifier of this <see cref="ModItem"/>.
    /// </summary>
    public string StringId { get; }

    /// <summary>
    /// The <see cref="ItemType"/> for this <see cref="ModItem"/>.
    /// </summary>
    public ItemType Type { get; set; }

    /// <summary>
    /// Dictionary of values stored by this <see cref="ModItem"/>.
    /// </summary>
    public SortedDictionary<string, object> Values { get; }

    ItemChangeType IItem.ChangeType { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
    int IItem.Id { get => 0; set { } }
    IEnumerable<IInstance> IItem.Instances => Instances;
    IEnumerable<IReferenceCategory> IItem.ReferenceCategories => ReferenceCategories;
    IDictionary<string, object> IItem.Values => Values;
    internal ModContext? Owner => parent?.Owner;

    public Item AsDeleted()
    {
        var deleted = new Item(Type, 0, Name, StringId, ItemChangeType.Changed);

        deleted.Values["DELETED"] = true;

        return deleted;
    }

    public ModItem DeepClone()
    {
        return new ModItem(Type, Name, StringId, Values, ReferenceCategories.Select(c => c.DeepClone()),
            Instances.Select(i => i.DeepClone()));
    }

    public bool IsDeleted() => Values.TryGetValue("DELETED", out var value) && value is bool deleted && deleted;

    /// <summary>
    /// Attempts to get an <see cref="Item"/> representing the changes between this and the provided <c>baseItem</c>.
    /// </summary>
    /// <param name="baseItem">Base item to compare to.</param>
    /// <param name="changes">If successful will contain the changes.</param>
    /// <returns><c>true</c> if there are changes; otherwise, <c>false</c>.</returns>
    public bool TryGetChanges(ModItem baseItem, [MaybeNullWhen(false)] out Item changes)
    {
        changes = new Item(Type, 0, Name, baseItem.StringId, Name != baseItem.Name ? ItemChangeType.Renamed : ItemChangeType.Changed);

        // Add any new or changed values
        foreach (var pair in Values.Where(pair => !baseItem.Values.TryGetValue(pair.Key, out var baseValue)
                                                  || baseValue != pair.Value))
        {
            changes.Values[pair.Key] = pair.Value;
        }

        changes.ReferenceCategories.AddRange(ReferenceCategories.GetChanges(baseItem.ReferenceCategories));

        changes.Instances.AddRange(Instances.GetChanges(baseItem.Instances));

        if (changes.ChangeType == ItemChangeType.Renamed
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
