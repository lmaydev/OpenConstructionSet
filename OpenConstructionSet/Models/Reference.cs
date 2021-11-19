namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a reference from a game data files.
/// </summary>
/// <param name="TargetId">The StringId of the item being referenced.</param>
/// <param name="Value0">The first value.</param>
/// <param name="Value1">The second value.</param>
/// <param name="Value2">The third value.</param>
public record struct Reference(string TargetId, int Value0, int Value1, int Value2)
{
    /// <summary>
    /// Creates a <c>Reference</c> from the values of the given <c>DataReference</c>
    /// </summary>
    /// <param name="reference"><c>DataReference</c> to get values from.</param>
    public Reference(DataReference reference) : this(reference.TargetId, reference.Value0, reference.Value1, reference.Value2)
    {
    }
}
