namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a reference from a game data files.
/// </summary>
/// <param name="TargetId">The StringId of the item being referenced</param>
/// <param name="Values">The values assigned to this reference.</param>
public record struct Reference(string TargetId, int Value0, int Value1, int Value2)
{
    public Reference(string targetId, DataReference data) : this(targetId, data.Value0, data.Value1, data.Value2)
    {
    }
}
