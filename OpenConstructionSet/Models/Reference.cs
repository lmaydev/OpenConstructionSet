namespace OpenConstructionSet.Models;

public record Reference(string TargetId, ReferenceValues Values)
{
    public Reference(KeyValuePair<string, ReferenceValues> pair) : this(pair.Key, pair.Value)
    { }
}