using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet.Mods;

/// <inheritdoc/>
public class ModReference : IReference
{
    private ModReferenceCollection? parent;

    /// <summary>
    /// Creates a <see cref="ModReference"/> from another.
    /// </summary>
    /// <param name="reference">The <see cref="IReference"/> to copy.</param>
    internal ModReference(IReference reference)
    {
        TargetId = reference.TargetId;
        Value0 = reference.Value0;
        Value1 = reference.Value1;
        Value2 = reference.Value2;
    }

    /// <summary>
    /// Creates a new <see cref="ModReference"/> from the provided values.
    /// </summary>
    /// <param name="targetId">The <see cref="Item.StringId"/> of the target <see cref="Item"/>.</param>
    /// <param name="value0">The first value.</param>
    /// <param name="value1">The second value.</param>
    /// <param name="value2">The third value.</param>
    internal ModReference(string targetId, int value0 = 0, int value1 = 0, int value2 = 0)
    {
        TargetId = targetId;
        Value0 = value0;
        Value1 = value1;
        Value2 = value2;
    }

    /// <summary>
    /// The target of this <see cref="ModReference"/>.
    /// Attempts to retrieve the <see cref="ModReference"/> from the parent <see cref="IModContext"/>.
    /// </summary>
    public ModItem? Target => parent?.Owner?.Items.TryGetValue(TargetId, out var target) == true ? target : null;

    /// <inheritdoc/>
    public string TargetId { get; }

    /// <inheritdoc/>
    public int Value0 { get; set; }

    /// <inheritdoc/>
    public int Value1 { get; set; }

    /// <inheritdoc/>
    public int Value2 { get; set; }

    /// <summary>
    /// Determines if the two <see cref="ModReference"/>s are not equal.
    /// </summary>
    /// <param name="left">First Instance.</param>
    /// <param name="right">Second instance.</param>
    /// <returns><c>true</c> if the two <see cref="ModReference"/>s are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(ModReference? left, ModReference? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines if the two <see cref="ModReference"/>s are equal.
    /// </summary>
    /// <param name="left">First Instance.</param>
    /// <param name="right">Second instance.</param>
    /// <returns><c>true</c> if the two <see cref="ModReference"/>s are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(ModReference? left, ModReference? right)
    {
        return EqualityComparer<ModReference>.Default.Equals(left, right);
    }

    /// <summary>
    /// Returns an <see cref="Reference"/> that represents this marked as deleted.
    /// </summary>
    /// <returns>An <see cref="Reference"/> that represents this marked as deleted.</returns>
    public Reference AsDeleted() => new(TargetId, int.MaxValue, int.MaxValue, int.MaxValue);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is ModReference reference &&
               TargetId == reference.TargetId &&
               Value0 == reference.Value0 &&
               Value1 == reference.Value1 &&
               Value2 == reference.Value2;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(TargetId, Value0, Value1, Value2);
    }

    /// <summary>
    /// Determines if this <see cref="ModReference"/> is marked as deleted.
    /// </summary>
    /// <returns><c>true</c> if this <see cref="ModReference"/> is deleted; otherwise, <c>false</c>.</returns>
    public bool IsDeleted() => Value0 == int.MaxValue && Value1 == int.MaxValue && Value2 == int.MaxValue;

    internal void SetParent(ModReferenceCollection? newParent)
    {
        parent?.Remove(this);
        parent = newParent;
    }
}
