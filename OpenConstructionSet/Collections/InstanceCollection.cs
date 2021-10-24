namespace OpenConstructionSet.Collections;

/// <summary>
/// A collection of <see cref="Instance"/>s unique by their Id.
/// </summary>
public class InstanceCollection : OcsCollection<Instance>
{
    /// <summary>
    /// Create a new empty collection of <see cref="Instance"/>s.
    /// </summary>
    public InstanceCollection()
    {
    }

    /// <summary>
    /// Build the collection from the provided collection of <see cref="Instance"/>s.
    /// </summary>
    /// <param name="collection">Collection of items to start with.</param>
    public InstanceCollection(IEnumerable<Instance> collection) : base(collection)
    {
    }

    /// <summary>
    /// Return the <see cref="Instance"/>'s <c>Id</c> property.
    /// </summary>
    /// <param name="item">The item to get the <c>Id</c> from.</param>
    /// <returns>The item's <c>Id</c></returns>
    protected override string GetId(Instance item) => item.Id;
}
