namespace OpenConstructionSet.Mods;

public class ModInstanceCollection : KeyedItemList<string, ModInstance>
{
    private readonly ModItem parent;

    internal ModInstanceCollection(ModItem parent, IEnumerable<IInstance> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModInstanceCollection(ModItem parent)
    {
        this.parent = parent;
    }

    internal ModContext? Owner => parent.Owner;

    public override void Add(ModInstance item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void Add(string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        => Add(new(id, targetId, position, rotation, states));

    public void Add(string id, IItem target, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        => Add(new(id, target.StringId, position, rotation, states));

    public void AddFrom(IInstance instance) => Add(instance is ModInstance mi ? mi : new ModInstance(instance));
}
