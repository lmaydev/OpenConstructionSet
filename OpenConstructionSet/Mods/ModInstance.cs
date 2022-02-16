using OpenConstructionSet.Mods.Context;

namespace OpenConstructionSet.Mods;

/// <inheritdoc/>
public class ModInstance : IInstance, IKeyedItem<string>
{
    private ModInstanceCollection? parent;

    /// <summary>
    /// Creates a new <see cref="ModInstance"/> from another.
    /// </summary>
    /// <param name="instance">The <see cref="IInstance"/> to copy.</param>
    public ModInstance(IInstance instance) : this(instance.Id, instance.TargetId, instance.Position, instance.Rotation, instance.States)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ModInstance"/> from the provided data.
    /// </summary>
    /// <param name="id">The identifier for the <see cref="ModInstance"/>.</param>
    /// <param name="targetId">The <see cref="IItem.StringId"/> of the targeted <see cref="IItem"/>.</param>
    /// <param name="position">The <see cref="ModInstance"/>'s position.</param>
    /// <param name="rotation">The <see cref="ModInstance"/>'s rotation.</param>
    /// <param name="states">A collection of states for the <see cref="ModInstance"/>.</param>
    public ModInstance(string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
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
    public string Key => Id;

    /// <inheritdoc/>
    public Vector3 Position { get; set; }

    /// <inheritdoc/>
    public Vector4 Rotation { get; set; }

    /// <inheritdoc/>
    public List<string> States { get; } = new();

    /// <summary>
    /// The target of this <see cref="ModInstance"/>.
    /// Attempts to retrieve the <see cref="ModInstance"/> from the parent <see cref="IModContext"/>.
    /// </summary>
    public ModItem? Target => parent?.Owner?.Items.TryGetValue(TargetId, out var target) == true ? target : null;

    /// <inheritdoc/>
    public string TargetId { get; set; }

    /// <summary>
    /// Determines if the two <see cref="ModInstance"/>s are not equal.
    /// </summary>
    /// <param name="left">First Instance.</param>
    /// <param name="right">Second instance.</param>
    /// <returns><c>true</c> if the two <see cref="ModInstance"/>s are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(ModInstance? left, ModInstance? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines if the two <see cref="ModInstance"/>s are equal.
    /// </summary>
    /// <param name="left">First Instance.</param>
    /// <param name="right">Second instance.</param>
    /// <returns><c>true</c> if the two <see cref="ModInstance"/>s are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(ModInstance? left, ModInstance? right)
    {
        return EqualityComparer<ModInstance>.Default.Equals(left, right);
    }

    /// <summary>
    /// Returns an <see cref="Instance"/> that represents this marked as deleted.
    /// </summary>
    /// <returns>An <see cref="Instance"/> that represents this marked as deleted.</returns>
    public Instance AsDeleted() => new(Id, "", Position, Rotation, States);

    /// <summary>
    /// Performs a deep clone of this object.
    /// </summary>
    /// <returns>A deep clone of this object.</returns>
    public ModInstance DeepClone() => new(Id, TargetId, Position, Rotation, States);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is ModInstance instance &&
               Id == instance.Id &&
               Position.Equals(instance.Position) &&
               Rotation.Equals(instance.Rotation) &&
               TargetId == instance.TargetId &&
               States.SequenceEqual(instance.States);
    }

    /// <inheritdoc/>
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Determines if this <see cref="ModInstance"/> is marked as deleted.
    /// </summary>
    /// <returns><c>true</c> if this <see cref="ModInstance"/> is deleted; otherwise, <c>false</c>.</returns>
    public bool IsDeleted() => TargetId.Length == 0;

    internal void SetParent(ModInstanceCollection? newParent)
    {
        parent?.Remove(this);
        parent = newParent;
    }
}
