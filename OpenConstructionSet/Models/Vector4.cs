namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a Rotation from the game data files.
/// </summary>
/// <param name="W">W value.</param>
/// <param name="X">X value.</param>
/// <param name="Y">Y value.</param>
/// <param name="Z">Z value.</param>
public record struct Vector4(float W, float X, float Y, float Z)
{
    public Vector4(DataVector4 value) : this(value.W, value.X, value.Y, value.Z)
    {
    }
}