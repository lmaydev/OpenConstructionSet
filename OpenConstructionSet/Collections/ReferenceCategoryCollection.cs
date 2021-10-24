namespace OpenConstructionSet.Collections;

/// <summary>
/// Collection of <see cref="ReferenceCategory"/> objects unique by their Name.
/// </summary>
public class ReferenceCategoryCollection : OcsCollection<ReferenceCategory>
{
    /// <summary>
    /// Creates a new empty collection.
    /// </summary>
    public ReferenceCategoryCollection()
    {
    }

    /// <summary>
    /// Build the collection from the provided collection of <see cref="ReferenceCategory"/> objects.
    /// </summary>
    /// <param name="collection">Collection of items to start with.</param>
    public ReferenceCategoryCollection(IEnumerable<ReferenceCategory> collection) : base(collection)
    {
    }

    /// <summary>
    /// Return the <see cref="ReferenceCategory"/>'s <c>Name</c> property.
    /// </summary>
    /// <param name="item">The item to get the <c>Name</c> from.</param>
    /// <returns>The item's <c>Name</c></returns>
    protected override string GetId(ReferenceCategory item) => item.Name;
}
