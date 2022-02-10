namespace OpenConstructionSet.Data;

public interface IInstance
{
    string Id { get; }
    Vector3 Position { get; set; }
    Vector4 Rotation { get; set; }
    List<string> States { get; }
    string TargetId { get; set; }
}
