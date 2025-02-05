using System.Collections.Immutable;
using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Data;

/// <summary>
/// Represents the header of a <see cref="IModFile"/>.
/// </summary>
public class Header
{
    /// <summary>
    /// Initialize a new empty <see cref="Header"/>
    /// </summary>
    public Header()
    {
    }

    /// <summary>
    /// Initialize a new <see cref="Header"/>
    /// </summary>
    /// <param name="version">The mod's version.</param>
    /// <param name="author">The mod's author.</param>
    /// <param name="description">A description of the mod.</param>
    public Header(int version, string author, string description)
    {
        Version = version;
        Author = author;
        Description = description;
    }

    public Header(int version,
    string author,
    string description,
    List<string> dependencies,
    List<string> references,
    uint saveCount,
    uint lastMerge,
    OrderedDictionary<string, MergeEntry> mergeEntries,
    OrderedDictionary<string, DeleteRequest> deleteRequests)
    {
        Author = author;
        Dependencies = dependencies;
        Description = description;
        References = references;
        Version = version;
        SaveCount = saveCount;
        LastMerge = lastMerge;
        MergeEntries = mergeEntries;
        DeleteRequests = deleteRequests;
    }

    /// <summary>
    /// The author of the mod.
    /// </summary>
    public string Author { get; set; } = "";

    /// <summary>
    /// A list of mod names (e.g. exmaple.mod) that this mod is dependent on.
    /// </summary>
    public List<string> Dependencies { get; set; } = [];

    /// <summary>
    /// A description of the mod.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// A list of mod names (e.g. example.mod) that this mod referenced.
    /// </summary>
    public List<string> References { get; set; } = [];

    /// <summary>
    /// The version of the mod.
    /// </summary>
    public int Version { get; set; } = 1;

    public uint SaveCount { get; set; }

    public uint LastMerge { get; set; }

    public OrderedDictionary<string, MergeEntry> MergeEntries { get; set; } = [];

    public OrderedDictionary<string, DeleteRequest> DeleteRequests { get; set; } = [];
}
