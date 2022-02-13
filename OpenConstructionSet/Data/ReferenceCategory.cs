namespace OpenConstructionSet.Data;

/// <inheritdoc/>
public class ReferenceCategory : IReferenceCategory
{
    /// <summary>
    /// Creates a new <see cref="ReferenceCategory"/> from another.
    /// </summary>
    /// <param name="category">The <see cref="ReferenceCategory"/> to copy.</param>
    public ReferenceCategory(IReferenceCategory category) : this(category.Name, category.References)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ReferenceCategory"/> with the given name.
    /// </summary>
    /// <param name="name">The name of the <see cref="ReferenceCategory"/>.</param>
    public ReferenceCategory(string name)
    {
        Name = name;
        References = new();
    }

    /// <summary>
    /// Creates a new <see cref="ReferenceCategory"/> with the given name and contained <see cref="Reference"/>s.
    /// The <see cref="Reference"/>s will be recreated using the copy constructor.
    /// </summary>
    /// <param name="name">The name of the <see cref="ReferenceCategory"/>.</param>
    /// <param name="collection">A collection of <see cref="Reference"/>s to add to the <see cref="ReferenceCategory"/>.</param>
    public ReferenceCategory(string name, IEnumerable<IReference> collection) : this(name, collection.Select(r => new Reference(r)))
    {
    }

    /// <summary>
    /// Creates a new <see cref="ReferenceCategory"/> with the given name and contained <see cref="Reference"/>s.
    /// The <see cref="Reference"/>s will be recreated using the copy constructor.
    /// </summary>
    /// <param name="name">The name of the <see cref="ReferenceCategory"/>.</param>
    /// <param name="collection">A collection of <see cref="Reference"/>s to add to the <see cref="ReferenceCategory"/>.</param>
    public ReferenceCategory(string name, IEnumerable<Reference> collection)
    {
        Name = name;
        References = new(collection);
    }

    /// <summary>
    /// Creates a new <see cref="ReferenceCategory"/> with the given name and contained <see cref="Reference"/>s.
    /// </summary>
    /// <param name="name">The name of the <see cref="ReferenceCategory"/>.</param>
    /// <param name="capacity">The initial capacity of <see cref="ReferenceCategory"/> list.</param>
    public ReferenceCategory(string name, int capacity)
    {
        Name = name;
        References = new(capacity);
    }

    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc/>
    public List<Reference> References { get; }

    /// <inheritdoc/>
    IEnumerable<IReference> IReferenceCategory.References => References;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is ReferenceCategory category &&
               Name == category.Name &&
               References.SequenceEqual(category.References);
    }

    /// <inheritdoc/>
    public override int GetHashCode() => Name.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => $"{Name} (Count: {References.Count})";
}
