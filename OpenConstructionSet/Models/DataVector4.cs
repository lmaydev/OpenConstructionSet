namespace OpenConstructionSet.Models;

/// <summary>
/// Represents an editable Vector4.
/// </summary>
public record class DataVector4 : IEquatable<Vector4>
{
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

    /// <summary>
    /// Creates a zeroed <c>DataVector4</c>.
    /// </summary>
    public DataVector4()
    {
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="value">Item to copy values from.</param>
    public DataVector4(Vector4 value) : this(value.W, value.X, value.Y, value.Z)
    {
    }

    /// <summary>
    /// Creates a new <c>DataVector4</c> from the given values.
    /// </summary>
    /// <param name="w"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public DataVector4(float w, float x, float y, float z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Determines if this and the other item are equal.
    /// </summary>
    /// <param name="other">Item to compare to this.</param>
    /// <returns><c>true</c> if this and the other item are equal.</returns>
    public bool Equals(Vector4 other) => W == other.W && X == other.X && Y == other.Y && Z == other.Z;
}
