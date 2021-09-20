namespace OpenConstructionSet.Models;

public class Header
{
    public List<string> Dependencies { get; set; } = new List<string>();

    public List<string> References { get; set; } = new List<string>();

    public int Version { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }

    public Header() : this(1, "", "")
    {
    }

    public Header(int version, string author, string description)
    {
        Version = version;
        Author = author;
        Description = description;
    }
}
