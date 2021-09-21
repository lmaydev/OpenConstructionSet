namespace OpenConstructionSet.Models;

public record struct ReferenceValues(int Value0, int Value1, int Value2)
{
    public static ReferenceValues Deleted { get; } = new(int.MaxValue, int.MinValue, int.MaxValue);
}
