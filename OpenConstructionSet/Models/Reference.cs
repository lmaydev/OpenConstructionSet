namespace OpenConstructionSet.Models;

public struct Reference
{
    public Reference(KeyValuePair<string, ReferenceValues> pair) : this(pair.Key, pair.Value)
    { }

    public Reference(string targetId, ReferenceValues values)
    {
        this.targetId = targetId;
        this.values = values;
    }

    public string targetId;
    public ReferenceValues values;
}