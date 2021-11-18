namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a position from the game data files.
/// </summary>
/// <param name="X">X value.</param>
/// <param name="Y">Y value.</param>
/// <param name="Z">Z value.</param>
public record struct Vector3(float X, float Y, float Z)
{
    public Vector3(DataVector3 value) : this(value.X, value.Y, value.Z)
    {
    }
}