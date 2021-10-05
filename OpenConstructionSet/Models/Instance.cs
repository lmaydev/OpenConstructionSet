namespace OpenConstructionSet.Models;

/// <summary>
/// Represents an instance from a game data file.
/// </summary>
/// <param name="Id">The instance's identifier.</param>
/// <param name="Target">The StringId of the target <seealso cref="Item"/></param>
/// <param name="Position">The position of the instance.</param>
/// <param name="Rotation">The rotation of the instance.</param>
/// <param name="States">The attached states.</param>
public sealed record Instance(string Id, string Target, Vector3 Position, Vector4 Rotation, string States);
