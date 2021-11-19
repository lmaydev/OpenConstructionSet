namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a position from the game data files.
/// </summary>
/// <param name="X">X value.</param>
/// <param name="Y">Y value.</param>
/// <param name="Z">Z value.</param>
public record struct Vector3(float X, float Y, float Z)
{
    /// <summary>
    /// Create a new <c>Vector3</c> from the values in the provided item.
    /// </summary>
    /// <param name="value">Item to get values from.</param>
    public Vector3(DataVector3 value) : this(value.X, value.Y, value.Z)
    {
    }
}