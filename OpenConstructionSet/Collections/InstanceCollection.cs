namespace OpenConstructionSet.Collections;

public class InstanceCollection : OcsCollection<Instance>
{
    public InstanceCollection()
    {
    }

    public InstanceCollection(IEnumerable<Instance> collection) : base(collection)
    {
    }

    protected override string GetId(Instance item) => item.Id;
}
