namespace OpenConstructionSet.Data;

/// <summary>
/// Represents the data of a game data file.
/// </summary>
public class DataFileData
{
    /// <summary>
    /// Creates a new <see cref="DataFileData"/>.
    /// </summary>
    /// <param name="type">The data file's type.</param>
    /// <param name="header">The mod's header.</param>
    /// <param name="lastId">The last ID number used when creating new items.</param>
    /// <param name="items">The collection of <see cref="Item"/>s of the <see cref="IDataFile"/>.</param>
    public DataFileData(DataFileType type, Header? header, int lastId, IEnumerable<Item> items)
    {
        Type = type;
        LastId = lastId;
        Items = new(items);
        Header = header;
    }

    /// <summary>
    /// The <see cref="Header"/> if it is a <see cref="DataFileType.Mod"/> file.
    /// <c>null</c> for other data files
    /// </summary>
    public Header? Header { get; set; }

    /// <summary>
    /// Collection of <see cref="Item"/>s contained with in the file. These represent all entities in kenshi.
    /// </summary>
    public List<Item> Items { get; set; }

    /// <summary>
    /// The last ID number used when creating new items.
    /// </summary>
    public int LastId { get; set; }

    /// <summary>
    /// The <see cref="DataFileType"/> of the data file.
    /// </summary>
    public DataFileType Type { get; set; }
}
