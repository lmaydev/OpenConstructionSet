namespace OpenConstructionSet.Data;

/// <summary>
/// Represents an item in the games data.
/// All entites in the game are represented using these.
/// </summary>
public class Item : IItem
{
    /// <summary>
    /// Creates a new <see cref="Item"/> from another.
    /// </summary>
    /// <param name="item">The <see cref="Item"/> to copy.</param>
    public Item(Item item) : this(item, item.ChangeType)
    {
    }

    public Item(IItem item, ItemChangeType changeType) : this(
        item.Type,
        item.Id,
        item.Name,
        item.StringId,
        changeType,
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
    /// <param name="changeType">The types of changes that have been applied to this <see cref="Item"/>.</param>
    public Item(ItemType type, int id, string name, string stringId, ItemChangeType changeType)
    {
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        ChangeType = changeType;

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
    /// <param name="changeType">The types of changes that have been applied to this <see cref="Item"/>.</param>
    /// <param name="values">Dictionary of values stored by this <see cref="Item"/>.</param>
    /// <param name="referenceCategories">Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="Item"/>.</param>
    /// <param name="instances">Collection of <see cref="Instance"/>s stored by this <see cref="Item"/>.</param>
    public Item(ItemType type, int id, string name, string stringId, ItemChangeType changeType, IDictionary<string, object> values, IEnumerable<IReferenceCategory> referenceCategories, IEnumerable<IInstance> instances)
    {
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        ChangeType = changeType;

        Values = new(values);
        ReferenceCategories = new(referenceCategories.Select(c => new ReferenceCategory(c)));
        Instances = new(instances.Select(i => new Instance(i)));
    }

    /// <summary>
    /// The types of changes that have been applied to this <see cref="Item"/>.
    /// </summary>
    public ItemChangeType ChangeType { get; set; }

    /// <summary>
    /// The Id of this <see cref="Item"/>.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Collection of <see cref="Instance"/>s stored by this <see cref="Item"/>.
    /// </summary>
    public List<Instance> Instances { get; } = new List<Instance>();

    /// <summary>
    /// The name of this <see cref="Item"/>.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="Item"/>.
    /// </summary>
    public List<ReferenceCategory> ReferenceCategories { get; } = new List<ReferenceCategory>();

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
}
