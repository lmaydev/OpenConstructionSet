namespace OpenConstructionSet.Models;

public class DataInstance : IDataModel, IEquatable<Instance>
{
    public string Key => Id;

    public string Id { get; }
    public string TargetId { get; set; }

    public DataVector3 Position { get; set; }

    public DataVector4 Rotation { get; set; }

    public List<string> States { get; }

    public DataInstance(Instance instance) : this(instance.Id, instance.Target, new(instance.Position), new(instance.Rotation), instance.States)
    {
    }

    public DataInstance(DataInstance values) : this(values.Id, values.TargetId, values.Position, values.Rotation, values.States)
    {
    }

    public DataInstance(string id, string target) : this(id, target, new(0,0,0), new DataVector4(0,0,0,0), Enumerable.Empty<string>())
    {
    }

    public DataInstance(string id, string target, DataVector3 position, DataVector4 rotation, IEnumerable<string> states)
    {
        this.Id = id;
        TargetId = target;
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
               Id == instance.Id &&
               TargetId == instance.TargetId &&
               Position.Equals(instance.Position) &&
               Rotation.Equals(instance.Rotation) &&
               States.SequenceEqual(instance.States);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, TargetId, Position, Rotation, string.Join(',', States));
    }

    public bool Equals(Instance other) => Id == other.Id &&
                                          TargetId == other.Target &&
                                          Position.Equals(other.Position) &&
                                          Rotation.Equals(other.Rotation) &&
                                          States.SequenceEqual(other.States);
}