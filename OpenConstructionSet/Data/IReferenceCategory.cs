namespace OpenConstructionSet.Data;

public interface IReferenceCategory
{
    string Name { get; }

    IEnumerable<IReference> References { get; }
}
