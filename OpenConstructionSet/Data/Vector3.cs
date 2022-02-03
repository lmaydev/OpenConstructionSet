namespace OpenConstructionSet.Data;

/// <summary>
/// Editable representation of a Vector3.
/// </summary>
public record struct Vector3
{
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

    public override string ToString() => $"({X}, {Y}, {Z})";
}