namespace OpenConstructionSet.Models;

public record Instance(string Id, string Target, Vector3 Position, Vector4 Rotation, string States)
{

    public Instance(KeyValuePair<string, InstanceValues> pair) : this(pair.Key, pair.Value)
    {
    }

    public Instance(string id, InstanceValues values) : this(id, values.Target, values.Position, values.Rotation, values.States)
    { }
}
