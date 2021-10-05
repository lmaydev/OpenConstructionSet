namespace OpenConstructionSet.Models;

/// <summary>
/// Represents the values assigned to a <see cref="Reference"/> in the game data files.
/// </summary>
/// <param name="Value0">Value 0</param>
/// <param name="Value1">Value 1</param>
/// <param name="Value2">Value 2</param>
public sealed record ReferenceValues(int Value0, int Value1, int Value2)
{
    /// <summary>
    /// A <see cref="Reference"/> with these values is marked as deleted.
    /// </summary>
    public static ReferenceValues Deleted { get; } = new(int.MaxValue, int.MinValue, int.MaxValue);
}
