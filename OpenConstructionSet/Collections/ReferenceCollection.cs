namespace OpenConstructionSet.Collections;

public class ReferenceCollection : OcsCollection<Reference>
{
    public ReferenceCollection()
    {
    }

    public ReferenceCollection(IEnumerable<Reference> collection) : base(collection)
    {
    }

    protected override string GetId(Reference item) => item.TargetId;
}
