namespace OpenConstructionSet.Data
{
    /// <summary>
    /// Represents a game data file.
    /// </summary>
    /// <param name="Type">The type identifier of the data file.</param>
    /// <param name="LastId">The last id number used when creating new items.</param>
    /// <param name="Items">Collection of data items contained with in the file. These represent all entities in kenshi.</param>
    public sealed record DataFileData(DataFileType Type, int LastId, List<Item> Items);
}
