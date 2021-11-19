namespace OpenConstructionSet.Models;

/// <summary>
/// Editable representation of an Instance from a data file.
/// </summary>
public class DataInstance : IDataModel, IEquatable<Instance>
{
    /// <summary>
    /// Unique Identifier.
    /// </summary>
    public string Key => Id;

    /// <summary>
    /// The instance's identifier.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// The StringId of the target <seealso cref="Item"/>.
    /// </summary>
    public string TargetId { get; set; }

    /// <summary>
    /// The position of the instance.
    /// </summary>
    public DataVector3 Position { get; set; }

    /// <summary>
    /// The rotation of the instance.
    /// </summary>
    public DataVector4 Rotation { get; set; }

    /// <summary>
    /// The attached states.
    /// </summary>
    public List<string> States { get; }

    /// <summary>
    /// Create an editable <c>DataInstance</c> from a <c>Instance</c>.
    /// </summary>
    /// <param name="instance"></param>
    public DataInstance(Instance instance) : this(instance.Id, instance.Target, new(instance.Position), new(instance.Rotation), instance.States)
    {
    }

    /// <summary>
    /// Copy constructor.
    /// </summary>
    /// <param name="instance">Object to take values from.</param>
    public DataInstance(DataInstance instance) : this(instance.Id, instance.TargetId, instance.Position, instance.Rotation, instance.States)
    {
    }

    /// <summary>
    /// Create a <c>DataInstance</c> from the provided values.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <param name="target">The StringId of the target <seealso cref="Item"/>.</param>
    public DataInstance(string id, string target) : this(id, target, new(0,0,0), new DataVector4(0,0,0,0), Enumerable.Empty<string>())
    {
    }

    /// <summary>
    /// Create a <c>DataInstance</c> from the provided values.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <param name="target">The StringId of the target <seealso cref="Item"/>.</param>
    /// <param name="position">Position of the instance.</param>
    /// <param name="rotation">Rotation of the instance.</param>
    /// <param name="states">The Attached states.</param>
    public DataInstance(string id, string target, DataVector3 position, DataVector4 rotation, IEnumerable<string> states)
    {
        this.Id = id;
        TargetId = target;
        Position = position;
        Rotation = rotation;
        States = new(states);
    }

    /// <summary>
    /// Determines if two <c>DataInstance</c>s are the same.
    /// </summary>
    /// <param name="left">First item.</param>
    /// <param name="right">Second item.</param>
    /// <returns><c>true</c> if the items are equal.</returns>
    public static bool operator ==(DataInstance? left, DataInstance? right)
    {
        return EqualityComparer<DataInstance>.Default.Equals(left, right);
    }

    /// <summary>
    /// Determines if two <c>DataInstance</c>s are not the same.
    /// </summary>
    /// <param name="left">First item.</param>
    /// <param name="right">Second item.</param>
    /// <returns><c>true</c> if the items are not equal.</returns>
    public static bool operator !=(DataInstance? left, DataInstance? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines if the provided object is equal to this.
    /// </summary>
    /// <param name="obj">Object to compare.</param>
    /// <returns><c>true</c> if this and the object are equal.</returns>
    public override bool Equals(object? obj)
    {
        return obj is DataInstance instance &&
               Id == instance.Id &&
               TargetId == instance.TargetId &&
               Position.Equals(instance.Position) &&
               Rotation.Equals(instance.Rotation) &&
               States.SequenceEqual(instance.States);
    }

    /// <summary>
    /// Creates a hash code based on the object's property values.
    /// </summary>
    /// <returns>A hash code created from the object's properties.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, TargetId, Position, Rotation, string.Join(',', States));
    }

    /// <summary>
    /// Determine if the given <c>Instance</c> is equal to this.
    /// </summary>
    /// <param name="other">The <c>Instance</c> to compare.</param>
    /// <returns><c>true</c> if this and the <c>Instance</c> are equal.</returns>
    public bool Equals(Instance other) => Id == other.Id &&
                                          TargetId == other.Target &&
                                          Position.Equals(other.Position) &&
                                          Rotation.Equals(other.Rotation) &&
                                          States.SequenceEqual(other.States);
}