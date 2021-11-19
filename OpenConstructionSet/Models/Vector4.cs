namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a Rotation from the game data files.
/// </summary>
/// <param name="W">The W value.</param>
/// <param name="X">The X value.</param>
/// <param name="Y">The Y value.</param>
/// <param name="Z">The Z value.</param>
public record struct Vector4(float W, float X, float Y, float Z)
{
    /// <summary>
    /// Create a new <c>Vector4</c> from the values in the provided item.
    /// </summary>
    /// <param name="value">Item to get values from.</param>
    public Vector4(DataVector4 value) : this(value.W, value.X, value.Y, value.Z)
    {
    }
}