namespace OpenConstructionSet.Data;

/// <summary>
/// Represents a <see cref="Reference"/> from the game's data.
/// </summary>
public record Reference : IReference
{
    /// <summary>
    /// Creates a <see cref="Reference"/> from another.
    /// </summary>
    /// <param name="reference">The <see cref="Reference"/> to copy.</param>
    public Reference(IReference reference)
    {
        TargetId = reference.TargetId;
        Value0 = reference.Value0;
        Value1 = reference.Value1;
        Value2 = reference.Value2;
    }

    /// <summary>
    /// Creates a new <see cref="Reference"/> from the provided values.
    /// </summary>
    /// <param name="targetId">The <see cref="Item.StringId"/> of the target <see cref="Item"/>.</param>
    /// <param name="value0">The first value.</param>
    /// <param name="value1">The second value.</param>
    /// <param name="value2">The third value.</param>
    public Reference(string targetId, int value0 = 0, int value1 = 0, int value2 = 0)
    {
        TargetId = targetId;
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }

    /// <summary>
    /// The <see cref="Item.StringId"/> of the target <see cref="Item"/>.
    /// </summary>
    public string TargetId { get; set; }

    /// <summary>
    /// The first value.
    /// </summary>
    public int Value0 { get; set; }

    /// <summary>
    /// The second value.
    /// </summary>
    public int Value1 { get; set; }

    /// <summary>
    /// The third value.
    /// </summary>
    public int Value2 { get; set; }

    /// <summary>
    /// Marks this <see cref="Reference"/> as deleted.
    /// </summary>
    public void Delete() => Value0 = Value1 = Value2 = int.MaxValue;

    /// <summary>
    /// Determines if this <see cref="Reference"/> is marked as deleted.
    /// </summary>
    /// <returns><c>true</c> if marked as deleted; otherwise, <c>false</c>.</returns>
    public bool IsDeleted() => this is { Value0: int.MaxValue, Value1: int.MaxValue, Value2: int.MaxValue };

    /// <inheritdoc/>
    public override string ToString() => $"{TargetId} ({Value0}, {Value1}, {Value2})";
}
