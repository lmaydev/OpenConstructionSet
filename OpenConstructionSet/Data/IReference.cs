namespace OpenConstructionSet.Data;

/// <summary>
/// Represents a reference from the game's data.
/// </summary>
public interface IReference
{
    /// <summary>
    /// The <see cref="IItem.StringId"/> of the target <see cref="IItem"/>.
    /// </summary>
    string TargetId { get; }

    /// <summary>
    /// The first value.
    /// </summary>
    int Value0 { get; set; }

    /// <summary>
    /// The second value.
    /// </summary>
    int Value1 { get; set; }

    /// <summary>
    /// The third value.
    /// </summary>
    int Value2 { get; set; }
}
