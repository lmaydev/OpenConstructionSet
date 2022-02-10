using System.Diagnostics.CodeAnalysis;
using LMay.Collections;

namespace OpenConstructionSet.Mods.Context;

public class ModReferenceCollection : SortedKeyedItemCollection<string, ModReference>
{
    private readonly ModReferenceCategory parent;

    internal ModReferenceCollection(ModReferenceCategory parent, IEnumerable<IReference> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModReferenceCollection(ModReferenceCategory parent)
    {
        this.parent = parent;
    }

    internal ModContext? Owner => parent.Owner;

    public override void Add(ModReference item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void Add(string targetId, int value0 = 0, int value1 = 0, int value2 = 0) => Add(new ModReference(targetId, value0, value1, value2));

    public void Add(IItem target, int value0 = 0, int value1 = 0, int value2 = 0) => Add(target.StringId, value0, value1, value2);

    public void AddFrom(IReference reference) => Add(reference is ModReference mr ? mr : new ModReference(reference));

    public IEnumerable<Reference> GetChanges(ModReferenceCollection baseReferences)
    {
        // All instances that are new (not in the baseInstances) or modified
        foreach (var reference in this.Where(r => !baseReferences.TryGetValue(r.Key, out var br) || r != br)
                                      .Select(r => new Reference(r)))
        {
            yield return reference;
        }

        // All instances that were deleted (not present in current instances)
        foreach (var reference in baseReferences.Where(i => !ContainsKey(i.Key)).Select(i => i.AsDeleted()))
        {
            yield return reference;
        }
    }

    public bool TryGetChanges(ModReferenceCollection baseReferences, [MaybeNullWhen(false)] out List<Reference> changes)
    {
        changes = GetChanges(baseReferences).ToList();

        if (changes.Count > 0)
        {
            return true;
        }

        changes = null;
        return false;
    }
}
