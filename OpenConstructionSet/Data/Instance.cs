namespace OpenConstructionSet.Data;

/// <inheritdoc/>
public class Instance : IInstance
{
    /// <summary>
    /// Creates a new <see cref="Instance"/> from another.
    /// </summary>
    /// <param name="instance">The <see cref="Instance"/> to copy.</param>
    public Instance(IInstance instance) : this(instance.Id,
                                               instance.TargetId,
                                               instance.Position,
                                               instance.Rotation,
                                               instance.States)
    {
    }

    /// <summary>
    /// Creates a new <see cref="Instance"/> from the provided data.
    /// </summary>
    /// <param name="id">The identifier for the <see cref="Instance"/>.</param>
    /// <param name="targetId">The <see cref="Item.StringId"/> of the targeted <see cref="Item"/>.</param>
    /// <param name="position">The <see cref="Instance"/>'s position.</param>
    /// <param name="rotation">The <see cref="Instance"/>'s rotation.</param>
    /// <param name="states">A collection of states for the <see cref="Instance"/>.</param>
    public Instance(string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
    {
        Id = id;
        TargetId = targetId;
        Position = position;
        Rotation = rotation;
        States = new(states);
    }

    /// <inheritdoc/>
    public string Id { get; }

    /// <inheritdoc/>
    public Vector3 Position { get; set; }

    /// <inheritdoc/>
    public Vector4 Rotation { get; set; }

    /// <inheritdoc/>
    public List<string> States { get; } = new();

    /// <inheritdoc/>
    public string TargetId { get; set; }

    /// <summary>
    /// Determines if the two <see cref="Instance"/>s are not equal.
    /// </summary>
    /// <param name="left">First Instance.</param>
    /// <param name="right">Second instance.</param>
    /// <returns><c>true</c> if the two <see cref="Instance"/>s are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Instance? left, Instance? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines if the two <see cref="Instance"/>s are equal.
    /// </summary>
    /// <param name="left">First Instance.</param>
    /// <param name="right">Second instance.</param>
    /// <returns><c>true</c> if the two <see cref="Instance"/>s are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Instance? left, Instance? right)
    {
        return EqualityComparer<Instance>.Default.Equals(left, right);
    }

    /// <summary>
    /// Marks this <see cref="Instance"/> as deleted.
    /// </summary>
    public void Delete() => TargetId = "";

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Instance instance &&
               Id == instance.Id &&
               Position.Equals(instance.Position) &&
               Rotation.Equals(instance.Rotation) &&
               TargetId == instance.TargetId &&
               States.SequenceEqual(instance.States);
    }

    /// <inheritdoc/>
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Determines if this <see cref="Instance"/> is marked as deleted.
    /// </summary>
    /// <returns><c>true</c> if marked as deleted; otherwise, <c>false</c>.</returns>
    public bool IsDeleted() => TargetId.Length == 0;
}
