using System.ComponentModel.DataAnnotations;

namespace OpenConstructionSet.Models;

/// <summary>
/// Editable representation of a reference from a data file.
/// </summary>
public record DataReference : IEquatable<Reference>, IDataModel
{
    /// <summary>
    /// Create a <c>DataReference</c> from the values in the provided <c>reference.</c>
    /// </summary>
    /// <param name="reference"><c>Reference</c> to get values from.</param>
    public DataReference(Reference reference)
    {
        TargetId = reference.TargetId;
        Value0 = reference.Value0;
        Value1 = reference.Value1;
        Value2 = reference.Value2;
    }

    /// <summary>
    /// Create a new <c>DataReference</c> from the provided values.
    /// </summary>
    /// <param name="targetId">StringId of the target item.</param>
    /// <param name="value0">The first value.</param>
    /// <param name="value1">The second value.</param>
    /// <param name="value2">The third value.</param>
    public DataReference(string targetId, int value0, int value1, int value2)
    {
        TargetId = targetId;
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }

    /// <summary>
    /// Unique identifier.
    /// </summary>
    public string Key => TargetId;

    /// <summary>
    /// StringId of the target item.
    /// </summary>
    public string TargetId { get; }

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
    /// Determines if the given <c>Reference</c> is equal to this.
    /// </summary>
    /// <param name="other">The <c>Reference</c> to compare to this.</param>
    /// <returns><c>true</c> if the items are equal.</returns>
    public bool Equals(Reference other) => Value0 == other.Value0 && Value1 == other.Value1 && Value2 == other.Value2;
}