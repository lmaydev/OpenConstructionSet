namespace OpenConstructionSet.Data;

/// <summary>
/// Representation of a Vector3.
/// </summary>
public record struct Vector3
{
    /// <summary>
    /// Creates a new <see cref="Vector3"/> from the provided values.
    /// </summary>
    /// <param name="x">The X value.</param>
    /// <param name="y">The Y value.</param>
    /// <param name="z">The Z value.</param>
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// The X value.
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// The Y value.
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// The Z value.
    /// </summary>
    public float Z { get; set; }

    /// <inheritdoc/>
    public override string ToString() => $"({X}, {Y}, {Z})";
}
