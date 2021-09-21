namespace OpenConstructionSet.Models;

public record struct Reference(string TargetId, ReferenceValues Values)
{
    public Reference(KeyValuePair<string, ReferenceValues> pair) : this(pair.Key, pair.Value)
    { }
}