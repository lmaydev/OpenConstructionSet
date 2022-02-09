namespace OpenConstructionSet.Mods;

/// <summary>
/// Represents a <see cref="ModReferenceCategory"/> from the game's data.
/// Stores a collection of related references.
/// </summary>
public class ModReferenceCategory : IModReferenceCategory
{
    private readonly IModContext owner;

    /// <summary>
    /// Creates a new <see cref="ModReferenceCategory"/> from another.
    /// </summary>
    /// <param name="category">The <see cref="IModReferenceCategory"/> to copy.</param>
    internal ModReferenceCategory(IModContext owner, IReferenceCategory category) : this(owner, category.Name, (IEnumerable<IReference>)category)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ModReferenceCategory"/> with the given name.
    /// </summary>
    /// <param name="name">The name of the <see cref="ModReferenceCategory"/>.</param>
    internal ModReferenceCategory(IModContext owner, string name)
    {
        this.owner = owner;
        Name = name;
        References = new();
    }

    /// <summary>
    /// Creates a new <see cref="ModReferenceCategory"/> with the given name and contained <see cref="Reference"/>s.
    /// The <see cref="Reference"/>s will be recreated using the copy constructor.
    /// </summary>
    /// <param name="name">The name of the <see cref="ModReferenceCategory"/>.</param>
    /// <param name="collection">A collection of <see cref="Reference"/>s to add to the <see cref="ModReferenceCategory"/>.</param>
    internal ModReferenceCategory(IModContext owner, string name, IEnumerable<IReference> collection)
    {
        this.owner = owner;
        Name = name;

        References = new(collection.Select(r => new ModReference(owner, r)));
    }

    /// <inheritdoc/>
    public string Key => Name;

    /// <summary>
    /// The name of the <see cref="ModReferenceCategory"/>.
    /// </summary>
    public string Name { get; }

    public KeyedItemList<string, ModReference> References { get; }

    IKeyedCollection<string, ModReference> IModReferenceCategory.References => References;

    IEnumerable<IReference> IReferenceCategory.References => References.Cast<IReference>();

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is ModReferenceCategory category &&
               Name == category.Name;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    /// <inheritdoc/>
    public override string ToString() => $"{Name} (Count: {References.Count})";
}
