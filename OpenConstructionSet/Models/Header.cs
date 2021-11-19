namespace OpenConstructionSet.Models;

/// <summary>
/// Representation of a mod file's header.
/// </summary>
public class Header
{
    /// <summary>
    /// A list of mod names (e.g. exmaple.mod) that this mod is dependent on.
    /// </summary>
    public List<string> Dependencies { get; set; } = new List<string>();

    /// <summary>
    /// A list of mod names (e.g. example.mod) that this mod referenced.
    /// </summary>
    public List<string> References { get; set; } = new List<string>();

    /// <summary>
    /// The version of the mod.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// The author of the mod.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// A description of the mod.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Initialize a new empty <c>Header</c>.
    /// </summary>
    public Header() : this(1, "", "")
    {
    }

    /// <summary>
    /// Initialize a new <c>Header</c>
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
}
