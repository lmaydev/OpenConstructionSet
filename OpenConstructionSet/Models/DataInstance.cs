namespace OpenConstructionSet.Models;

public class DataInstance : IEquatable<Instance>
{
    public string Target { get; set; }

    public Vector3 Position { get; set; }

    public Vector4 Rotation { get; set; }

    public List<string> States { get; }

    public DataInstance(Instance instance) : this(instance.Target, instance.Position, instance.Rotation, instance.States)
    {

    }

    public DataInstance(DataInstance values)
    {
        Target = values.Target;
        Position = values.Position;
        Rotation = values.Rotation;
        States = new(values.States);
    }

    public DataInstance(string target) : this(target, default, default, Enumerable.Empty<string>())
    {
        Target = target;
    }

    public DataInstance(string target, Vector3 position, Vector4 rotation, IEnumerable<string> states)
    {
        Target = target;
        Position = position;
        Rotation = rotation;
        States = new(states);
    }

    public static bool operator ==(DataInstance? left, DataInstance? right)
    {
        return EqualityComparer<DataInstance>.Default.Equals(left, right);
    }

    public static bool operator !=(DataInstance? left, DataInstance? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return obj is DataInstance instance &&
               Target == instance.Target &&
               Position.Equals(instance.Position) &&
               Rotation.Equals(instance.Rotation) &&
               States.SequenceEqual(instance.States);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Target, Position, Rotation, string.Join(',', States));
    }

    public bool Equals(Instance other) => Target == other.Target && Position == other.Position && Rotation == other.Rotation && States.SequenceEqual(other.States);
}