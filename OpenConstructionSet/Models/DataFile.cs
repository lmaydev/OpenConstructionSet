namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a game data file.
/// </summary>
/// <param name="Type">The value describing the type of the file. See <see cref="DataFileType"/>.</param>
/// <param name="Header">If the file is a mod (Type 16) this contains the meta data for it. This will be <c>null</c> for other data files.</param>
/// <param name="LastId">The last id number used when creating new items.</param>
/// <param name="Items">Collection of data items contained with in the file. These represent all entities in kenshi.</param>
public record DataFile(DataFileType Type, Header? Header, int LastId, List<Item> Items);