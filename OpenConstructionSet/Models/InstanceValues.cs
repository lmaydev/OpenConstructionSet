namespace OpenConstructionSet.Models;

public record struct InstanceValues(string Target, Vector3 Position, Vector4 Rotation, string States)
{
    public InstanceValues(Instance instance) : this(instance.Target, instance.Position, instance.Rotation, instance.States)
    { }
}
