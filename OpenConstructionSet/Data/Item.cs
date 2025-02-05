namespace OpenConstructionSet.Data;

/// <summary>
/// Represents an item in the games data.
/// All entites in the game are represented using these.
/// </summary>
public class Item : IItem
{
    /// <summary>
    /// Creates a new <see cref="Item"/> from an <see cref="IItem"/>.
    /// </summary>
    /// <param name="item">The <see cref="IItem"/> to copy.</param>
    public Item(IItem item) : this(
        item.Type,
        item.Id,
        item.Name,
        item.StringId,
        item.SaveData,
        item.Values,
        item.ReferenceCategories,
        item.Instances)
    {
    }

    /// <summary>
    /// Creates a new <see cref="Item"/> from the provided data.
    /// </summary>
    /// <param name="type">The <see cref="ItemType"/> for this <see cref="Item"/>.</param>
    /// <param name="id">The Id of this <see cref="Item"/>.</param>
    /// <param name="name">The name of this <see cref="Item"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="Item"/>.</param>
    /// <param name="saveData">The types of changes that have been applied to this <see cref="Item"/> and its save count.</param>
    public Item(ItemType type, int id, string name, string stringId, ItemSaveData saveData)
    {
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        SaveData = saveData;

        Values = new();
        ReferenceCategories = new();
        Instances = new();
    }

    /// <summary>
    /// Creates a new <see cref="Item"/> from the provided data.
    /// </summary>
    /// <param name="type">The <see cref="ItemType"/> for this <see cref="Item"/>.</param>
    /// <param name="id">The Id of this <see cref="Item"/>.</param>
    /// <param name="name">The name of this <see cref="Item"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="Item"/>.</param>
    /// <param name="saveData">The types of changes that have been applied to this <see cref="Item"/> and its save count.</param>
    /// <param name="values">Dictionary of values stored by this <see cref="Item"/>.</param>
    /// <param name="referenceCategories">Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="Item"/>.</param>
    /// <param name="instances">Collection of <see cref="Instance"/>s stored by this <see cref="Item"/>.</param>
    public Item(
        ItemType type,
        int id,
        string name,
        string stringId,
        ItemSaveData saveData,
        IDictionary<string, object> values,
        IEnumerable<IReferenceCategory> referenceCategories,
        IEnumerable<IInstance> instances)
        : this(type, id, name, stringId, saveData, values, referenceCategories.Select(c => new ReferenceCategory(c)),
              instances.Select(i => new Instance(i)))
    {
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        SaveData = saveData;

        Values = new(values);
        ReferenceCategories = new(referenceCategories.Select(c => new ReferenceCategory(c)));
        Instances = new(instances.Select(i => new Instance(i)));
    }

    /// <summary>
    /// Creates a new <see cref="Item"/> from the provided data.
    /// </summary>
    /// <param name="type">The <see cref="ItemType"/> for this <see cref="Item"/>.</param>
    /// <param name="id">The Id of this <see cref="Item"/>.</param>
    /// <param name="name">The name of this <see cref="Item"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="Item"/>.</param>
    /// <param name="saveData">The types of changes that have been applied to this <see cref="Item"/> and its save count.</param>
    /// <param name="values">Dictionary of values stored by this <see cref="Item"/>.</param>
    /// <param name="referenceCategories">Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="Item"/>.</param>
    /// <param name="instances">Collection of <see cref="Instance"/>s stored by this <see cref="Item"/>.</param>
    public Item(ItemType type,
                int id,
                string name,
                string stringId,
                ItemSaveData saveData,
                IDictionary<string, object> values,
                IEnumerable<ReferenceCategory> referenceCategories,
                IEnumerable<Instance> instances)
    {
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        SaveData = saveData;

        Values = new(values);
        ReferenceCategories = new(referenceCategories);
        Instances = new(instances);
    }

    /// <summary>
    /// The types of changes that have been applied to this <see cref="Item"/>.
    /// </summary>
    public ItemSaveData SaveData { get; set; }

    /// <summary>
    /// The Id of this <see cref="Item"/>.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Collection of <see cref="Instance"/>s stored by this <see cref="Item"/>.
    /// </summary>
    public List<Instance> Instances { get; } = new();

    /// <summary>
    /// The name of this <see cref="Item"/>.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="Item"/>.
    /// </summary>
    public List<ReferenceCategory> ReferenceCategories { get; } = new();

    /// <summary>
    /// The unique string identifier of this <see cref="Item"/>.
    /// </summary>
    public string StringId { get; }

    /// <summary>
    /// The <see cref="ItemType"/> for this <see cref="Item"/>.
    /// </summary>
    public ItemType Type { get; set; }

    /// <summary>
    /// Dictionary of values stored by this <see cref="Item"/>.
    /// </summary>
    public OrderedDictionary<string, object> Values { get; } = new OrderedDictionary<string, object>();

    IEnumerable<IInstance> IItem.Instances => Instances;

    IEnumerable<IReferenceCategory> IItem.ReferenceCategories => ReferenceCategories;

    IDictionary<string, object> IItem.Values => Values;

    /// <summary>
    /// Determines if the two <see cref="Item"/>s are not equal.
    /// </summary>
    /// <param name="left">First item.</param>
    /// <param name="right">Second item.</param>
    /// <returns><c>true</c> if the two <see cref="Item"/>s are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Item? left, Item? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines if the two <see cref="Item"/>s are equal.
    /// </summary>
    /// <param name="left">First Item.</param>
    /// <param name="right">Second Item.</param>
    /// <returns><c>true</c> if the two <see cref="Item"/>s are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Item? left, Item? right)
    {
        return EqualityComparer<Item>.Default.Equals(left, right);
    }

    /// <summary>
    /// Marks this <see cref="Reference"/> as deleted.
    /// </summary>
    public void Delete()
    {
        ReferenceCategories.Clear();
        Instances.Clear();
        Values.Clear();

        Values["DELETED"] = true;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Item item &&
               SaveData == item.SaveData &&
               Id == item.Id &&
               Name == item.Name &&
               StringId == item.StringId &&
               Type == item.Type &&
               ReferenceCategories.SequenceEqual(item.ReferenceCategories) &&
               Instances.SequenceEqual(item.Instances) &&
               Values.SequenceEqual(item.Values);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, StringId, Type);
    }

    /// <summary>
    /// Determines if this <see cref="Reference"/> is marked as deleted.
    /// </summary>
    /// <returns><c>true</c> if marked as deleted; otherwise, <c>false</c>.</returns>
    public bool IsDeleted() => Values.TryGetValue("DELETED", out var value) && value is bool b && b;

    /// <inheritdoc/>
    public override string ToString()
        => $"{Name} ({StringId}) Values: {Values.Count} Instances: {Instances.Count} Reference Categories: {ReferenceCategories.Count}";
}
