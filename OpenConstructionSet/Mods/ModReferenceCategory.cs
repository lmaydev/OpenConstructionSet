using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet.Mods;

/// <summary>
/// Represents a <see cref="ModReferenceCategory"/> from the game's data. Stores a collection of
/// related references.
/// </summary>
public class ModReferenceCategory : IReferenceCategory
{
    private ModReferenceCategoryCollection? parent;

    /// <summary>
    /// Creates a new <see cref="ModReferenceCategory"/> from another.
    /// </summary>
    /// <param name="category">The <see cref="IReferenceCategory"/> to copy.</param>
    internal ModReferenceCategory(IReferenceCategory category) : this(category.Name, (IEnumerable<IReference>)category)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ModReferenceCategory"/> with the given name.
    /// </summary>
    /// <param name="name">The name of the <see cref="ModReferenceCategory"/>.</param>
    internal ModReferenceCategory(string name)
    {
        Name = name;
        References = new(this);
    }

    /// <summary>
    /// Creates a new <see cref="ModReferenceCategory"/> with the given name and contained <see
    /// cref="Reference"/> s. The <see cref="Reference"/> s will be recreated using the copy constructor.
    /// </summary>
    /// <param name="name">The name of the <see cref="ModReferenceCategory"/>.</param>
    /// <param name="collection">A collection of <see cref="Reference"/> s to add to the <see cref="ModReferenceCategory"/>.</param>
    internal ModReferenceCategory(string name, IEnumerable<IReference> collection)
    {
        Name = name;

        References = new(this, collection);
    }

    /// <summary>
    /// The name of the <see cref="ModReferenceCategory"/>.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// A collection of references stored by this <see cref="ModReferenceCategory"/>
    /// </summary>
    public ModReferenceCollection References { get; }

    IEnumerable<IReference> IReferenceCategory.References => References.Cast<IReference>();

    internal ModContext? Owner => parent?.Owner;

    /// <summary>
    /// Performs a deep clone of this object.
    /// </summary>
    /// <returns>A deep clone of this object.</returns>
    public ModReferenceCategory DeepClone()
    {
        return new ModReferenceCategory(Name, References.Select(r => new ModReference(r)));
    }

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

    internal void SetParent(ModReferenceCategoryCollection? newParent)
    {
        parent?.Remove(this);
        parent = newParent;
    }
}
