namespace OpenConstructionSet.Data;

/// <summary>
/// Represents a reference category from the game's data.
/// Stores a collection of related references.
/// </summary>
public interface IReferenceCategory
{
    /// <summary>
    /// The name of the <see cref="IReferenceCategory"/>.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// A collection of references stored by this <see cref="IReferenceCategory"/>
    /// </summary>
    IEnumerable<IReference> References { get; }
}
