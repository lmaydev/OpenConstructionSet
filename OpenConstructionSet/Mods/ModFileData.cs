namespace OpenConstructionSet.Mods;

/// <summary>
/// Represents the data stored within a <see cref="IModFile"/>.
/// </summary>
public class ModFileData
{
    /// <summary>
    /// Creates a new <see cref="ModFileData"/>.
    /// </summary>
    /// <param name="type">The mod file's type.</param>
    /// <param name="header">The mod's header.</param>
    /// <param name="lastId">The last ID number used when creating new items.</param>
    /// <param name="items">The collection of <see cref="Item"/> s of the <see cref="IModFile"/>.</param>
    /// <param name="info">Optional data contained within the <see cref="IModFile"/>'s .info file.</param>
    public ModFileData(DataFileType type, Header header, int lastId, IEnumerable<Item> items, ModInfoData? info)
    {
        Type = type;
        Header = header;
        LastId = lastId;
        Info = info;
        Items = new(items);
    }

    /// <summary>
    /// The <see cref="Header"/> of the <see cref="IModFile"/>.
    /// </summary>
    public Header Header { get; set; }

    /// <summary>
    /// Optional data contained within the <see cref="IModFile"/>'s .info file.
    /// </summary>
    public ModInfoData? Info { get; set; }

    /// <summary>
    /// The collection of <see cref="Item"/> s of the <see cref="IModFile"/>.
    /// </summary>
    public List<Item> Items { get; set; }

    /// <summary>
    /// The last Id used to generate a new <see cref="IItem"/>.
    /// </summary>
    public int LastId { get; set; }

    /// <summary>
    /// The <see cref="DataFileType"/> of the mod file.
    /// </summary>
    public DataFileType Type { get; }
}
