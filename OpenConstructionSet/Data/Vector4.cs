namespace OpenConstructionSet.Data;

/// <summary>
/// Represents an editable Vector4.
/// </summary>
public record struct Vector4
{
    /// <summary>
    /// Creates a new <c>DataVector4</c> from the given values.
    /// </summary>
    /// <param name="w"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Vector4(float w, float x, float y, float z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// The W value.
    /// </summary>
    public float W { get; set; }

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

    public override string ToString() => $"({W}, {X}, {Y}, {Z})";
}