namespace OpenConstructionSet.Data;

/// <summary>
/// Represents an instance from the game's data.
/// </summary>
public interface IInstance
{
    /// <summary>
    /// The <see cref="IInstance"/>'s unique identifier.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// The <see cref="IInstance"/>'s position.
    /// </summary>
    Vector3 Position { get; set; }

    /// <summary>
    /// The <see cref="IInstance"/>'s rotation.
    /// </summary>
    Vector4 Rotation { get; set; }

    /// <summary>
    /// A collection of states for the <see cref="IInstance"/>.
    /// </summary>
    List<string> States { get; }

    /// <summary>
    /// The <see cref="IItem.StringId"/> of the targeted <see cref="IItem"/>.
    /// </summary>
    string TargetId { get; set; }
}
