namespace OpenConstructionSet.Data;

/// <summary>
/// Represents the data of a game data file.
/// </summary>
/// <param name="Type">The <see cref="DataFileType"/> of the data file.</param>
/// <param name="LastId">The last ID number used when creating new items.</param>
/// <param name="Items">Collection of data items contained with in the file. These represent all entities in kenshi.</param>
public sealed record DataFileData(DataFileType Type, int LastId, List<Item> Items)
{
    /// <summary>
    /// The <see cref="DataFileType"/> of the data file.
    /// </summary>
    public DataFileType Type { get; init; } = Type;

    /// <summary>
    /// The last ID number used when creating new items.
    /// </summary>
    public int LastId { get; init; } = LastId;

    /// <summary>
    /// Collection of <see cref="Item"/>s contained with in the file. These represent all entities in kenshi.
    /// </summary>
    public List<Item> Items { get; init; } = Items;
}
