namespace OpenConstructionSet.Collections;

/// <summary>
/// A collection of <see cref="Reference"/>s unique by their TargetId.
/// </summary>
public class ReferenceCollection : OcsCollection<Reference>
{
    /// <summary>
    /// Create a new empty collection of <see cref="Reference"/>s.
    /// </summary>
    public ReferenceCollection()
    {
    }

    /// <summary>
    /// Build the collection from the provided collection of <see cref="Reference"/>s.
    /// </summary>
    /// <param name="collection">Collection of items to start with.</param>
    public ReferenceCollection(IEnumerable<Reference> collection) : base(collection)
    {
    }

    /// <summary>
    /// Return the <see cref="Reference"/>'s <c>TargetId</c> property.
    /// </summary>
    /// <param name="item">The item to get the <c>TargetID</c> from.</param>
    /// <returns>The item's <c>TargetId</c></returns>
    protected override string GetId(Reference item) => item.TargetId;
}
