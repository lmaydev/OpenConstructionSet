namespace OpenConstructionSet.Models;

/// <summary>
/// Represents an instance from a game data file.
/// </summary>
/// <param name="Id">The instance's identifier.</param>
/// <param name="Target">The StringId of the target <seealso cref="Item"/></param>
/// <param name="Position">The position of the instance.</param>
/// <param name="Rotation">The rotation of the instance.</param>
/// <param name="States">The attached states.</param>
public record struct Instance(string Id, string Target, Vector3 Position, Vector4 Rotation, string[] States)
{
    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="instance">Item to copy values from.</param>
    public Instance(Instance instance) : this(instance.Id, instance.Target, instance.Position, instance.Rotation, instance.States.ToArray())
    {
    }

    /// <summary>
    /// Creates a new <c>Instance</c> using the values of the provided item.
    /// </summary>
    /// <param name="data">Item to copy values from.</param>
    public Instance(DataInstance data) : this(data.Id, data.TargetId, new(data.Position), new(data.Rotation), data.States.ToArray())
    {
    }
}
