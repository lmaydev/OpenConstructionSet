namespace OpenConstructionSet.Data;

/// <inheritdoc/>
public class Reference : IReference
{
    /// <summary>
    /// Creates a new <see cref="Reference"/> by copying the values of an <see cref="IReference"/>.
    /// </summary>
    /// <param name="reference">The <see cref="IReference"/> to copy.</param>
    public Reference(IReference reference)
    {
        TargetId = reference.TargetId;
        Value0 = reference.Value0;
        Value1 = reference.Value1;
        Value2 = reference.Value2;
    }

    /// <summary>
    /// Creates a new <see cref="Reference"/> instance from the provided values.
    /// </summary>
    /// <param name="targetId">The <see cref="IItem.StringId"/> of the target <see cref="IItem"/>.</param>
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

    /// <inheritdoc/>
    public string TargetId { get; set; }

    /// <inheritdoc/>
    public int Value0 { get; set; }

    /// <inheritdoc/>
    public int Value1 { get; set; }

    /// <inheritdoc/>
    public int Value2 { get; set; }

    /// <summary>
    /// Determines if the two <see cref="Reference"/>s are not equal.
    /// </summary>
    /// <param name="left">First Reference.</param>
    /// <param name="right">Second Reference.</param>
    /// <returns><c>true</c> if the two <see cref="Reference"/>s are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Reference? left, Reference? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines if the two <see cref="Reference"/>s are equal.
    /// </summary>
    /// <param name="left">First Reference.</param>
    /// <param name="right">Second Reference.</param>
    /// <returns><c>true</c> if the two <see cref="Reference"/>s are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Reference? left, Reference? right)
    {
        return EqualityComparer<Reference>.Default.Equals(left, right);
    }

    /// <summary>
    /// Marks this <see cref="Reference"/> as deleted.
    /// </summary>
    public void Delete() => Value0 = Value1 = Value2 = int.MaxValue;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Reference reference &&
               TargetId == reference.TargetId &&
               Value0 == reference.Value0 &&
               Value1 == reference.Value1 &&
               Value2 == reference.Value2;
    }

    /// <inheritdoc/>
    public override int GetHashCode() => TargetId.GetHashCode();

    /// <summary>
    /// Determines if this <see cref="Reference"/> is marked as deleted.
    /// </summary>
    /// <returns><c>true</c> if marked as deleted; otherwise, <c>false</c>.</returns>
    public bool IsDeleted() => this is { Value0: int.MaxValue, Value1: int.MaxValue, Value2: int.MaxValue };

    /// <inheritdoc/>
    public override string ToString() => $"{TargetId} ({Value0}, {Value1}, {Value2})";
}
