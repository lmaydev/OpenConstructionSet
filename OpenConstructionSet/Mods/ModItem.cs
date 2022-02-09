namespace OpenConstructionSet.Mods;

/// <summary>
/// Represents an item in the games data.
/// All entites in the game are represented using these.
/// </summary>
public class ModItem : IItem
{
    private readonly IModContext owner;

    /// <summary>
    /// Creates a new <see cref="ModItem"/> from another.
    /// </summary>
    /// <param name="item">The <see cref="ModItem"/> to copy.</param>
    public ModItem(IModContext owner, IItem item) : this(
        owner,
        item.Type,
        item.Id,
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
    /// <param name="id">The Id of this <see cref="ModItem"/>.</param>
    /// <param name="name">The name of this <see cref="ModItem"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="ModItem"/>.</param>
    ///
    public ModItem(IModContext owner, ItemType type, int id, string name, string stringId)
    {
        this.owner = owner;
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;

        Values = new();
        ReferenceCategories = new();
        Instances = new(owner);
    }

    /// <summary>
    /// Creates a new <see cref="ModItem"/> from the provided data.
    /// </summary>
    /// <param name="type">The <see cref="ItemType"/> for this <see cref="ModItem"/>.</param>
    /// <param name="id">The Id of this <see cref="ModItem"/>.</param>
    /// <param name="name">The name of this <see cref="ModItem"/>.</param>
    /// <param name="stringId">The unique string identifier of this <see cref="ModItem"/>.</param>
    /// <param name="values">Dictionary of values stored by this <see cref="ModItem"/>.</param>
    /// <param name="referenceCategories">Collection of <see cref="ReferenceCategory"/> instances stored by this <see cref="ModItem"/>.</param>
    /// <param name="instances">Collection of <see cref="Instance"/>s stored by this <see cref="ModItem"/>.</param>
    ///
    public ModItem(IModContext owner, ItemType type, int id, string name, string stringId, IDictionary<string, object> values, IEnumerable<IReferenceCategory> referenceCategories, IEnumerable<IInstance> instances)
    {
        this.owner = owner;
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;

        this.Values = new(values);
        this.ReferenceCategories = new(referenceCategories.Select(c => (IModReferenceCategory)new ModReferenceCategory(owner, c)));
        this.Instances = new(owner, instances.Select(i => new ModInstance(owner, i)));
    }

    /// <summary>
    /// The Id of this <see cref="ModItem"/>.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Collection of <see cref="Instance"/>s stored by this <see cref="ModItem"/>.
    /// </summary>
    public ModInstanceCollection Instances { get; }

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

    ICollection<IInstance> IItem.Instances => (ICollection<IInstance>)Instances;

    ICollection<IReferenceCategory> IItem.ReferenceCategories => (ICollection<IReferenceCategory>)ReferenceCategories;

    IDictionary<string, object> IItem.Values => Values;
}
