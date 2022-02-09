namespace OpenConstructionSet.Data;

public interface IReference
{
    string TargetId { get; }
    int Value0 { get; set; }
    int Value1 { get; set; }
    int Value2 { get; set; }
}
