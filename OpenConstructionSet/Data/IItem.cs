namespace OpenConstructionSet.Data;

/// <summary>
/// Represents an instance from the game's data.
/// All data in the game is represented by these.
/// </summary>
public interface IItem
{
    /// <summary>
    /// The type of changes applied to this item and its save count.
    /// </summary>
    ItemSaveData SaveData { get; set; }

    /// <summary>
    /// The ID of the item.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// A collection of instances for this item.
    /// </summary>
    IEnumerable<IInstance> Instances { get; }

    /// <summary>
    /// The name of this item.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// A collection of reference categories for this item.
    /// </summary>
    IEnumerable<IReferenceCategory> ReferenceCategories { get; }

    /// <summary>
    /// The unique string identifier for this item.
    /// </summary>
    string StringId { get; }

    /// <summary>
    /// The type of item this represents.
    /// </summary>
    ItemType Type { get; set; }

    /// <summary>
    /// Dictionary of values for this item.
    /// </summary>
    IDictionary<string, object> Values { get; }
}
