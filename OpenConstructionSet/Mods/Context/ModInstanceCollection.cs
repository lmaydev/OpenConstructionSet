namespace OpenConstructionSet.Mods.Context;

/// <summary>
/// Collection to manage <see cref="ModInstance"/>s.
/// </summary>
public class ModInstanceCollection : KeyedItemList<string, ModInstance>
{
    private readonly ModItem parent;

    internal ModInstanceCollection(ModItem parent, IEnumerable<IInstance> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModInstanceCollection(ModItem parent)
    {
        this.parent = parent;
    }

    internal ModContext? Owner => parent.Owner;

    /// <summary>
    /// Adds the provided <see cref="ModInstance"/> to the collection.
    /// </summary>
    /// <param name="item">The <see cref="ModInstance"/> to add.</param>
    public override void Add(ModInstance item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    /// <summary>
    /// Adds a new <see cref="ModInstance"/> to the collection with the provided values.
    /// </summary>
    /// <param name="id">Unique identifier.</param>
    /// <param name="targetId">The <see cref="IItem.StringId"/> of the target.</param>
    /// <param name="position">The position.</param>
    /// <param name="rotation">The rotation.</param>
    /// <param name="states">Attached states.</param>
    public void Add(string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        => Add(new(id, targetId, position, rotation, states));

    /// <summary>
    /// Adds a new <see cref="ModInstance"/> to the collection with the provided values.
    /// </summary>
    /// <param name="id">Unique identifier.</param>
    /// <param name="target">The <see cref="IItem"/> to target.</param>
    /// <param name="position">The position.</param>
    /// <param name="rotation">The rotation.</param>
    /// <param name="states">Attached states.</param>
    public void Add(string id, IItem target, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        => Add(new(id, target.StringId, position, rotation, states));

    /// <summary>
    /// Adds a new <see cref="ModInstance"/> based on the provided <see cref="IInstance"/>.
    /// If the <see cref="IInstance"/> is a <see cref="ModInstance"/> it will be added without recreation.
    /// </summary>
    /// <param name="instance">The <see cref="IInstance"/> to add.</param>
    public void AddFrom(IInstance instance) => Add(instance is ModInstance mi ? mi : new ModInstance(instance));

    /// <summary>
    /// Compares this collection with another returning any changes.
    /// </summary>
    /// <param name="baseInstances">Collection to comapre to this one.</param>
    /// <returns>A collection containing the added or modified <see cref="Instance"/>s.</returns>
    public IEnumerable<Instance> GetChanges(ModInstanceCollection baseInstances)
    {
        // All instances that are new (not in the baseInstances) or modified
        foreach (var instance in this.Where(instance => !baseInstances.TryGetValue(instance.Key, out var bi) || instance != bi)
                      .Select(instance => new Instance(instance)))
        {
            yield return instance;
        }

        // All instances that were deleted (not present in current instances)
        foreach (var instance in baseInstances.Where(i => !ContainsKey(i.Key)).Select(i => i.AsDeleted()))
        {
            yield return instance;
        }
    }
}
