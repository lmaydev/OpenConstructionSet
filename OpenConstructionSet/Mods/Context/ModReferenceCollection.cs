using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Mods.Context;

/// <summary>
/// Collection to manage <see cref="ModReference"/>s.
/// </summary>
public class ModReferenceCollection : KeyedCollection<string, ModReference>
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

    protected override void InsertItem(int index, ModReference item) => item.SetParent(this);

    protected override void SetItem(int index, ModReference item) => item.SetParent(this);

    /// <summary>
    /// Adds a new <see cref="ModReference"/> to the collection with the provided values.
    /// </summary>
    /// <param name="targetId">The <see cref="IItem.StringId"/> of the target.</param>
    /// <param name="value0">The first value.</param>
    /// <param name="value1">The second value.</param>
    /// <param name="value2">The third value.</param>
    public void Add(string targetId, int value0 = 0, int value1 = 0, int value2 = 0) => Add(new ModReference(targetId, value0, value1, value2));

    /// <summary>
    /// Adds a new <see cref="ModReference"/> to the collection with the provided values.
    /// </summary>
    /// <param name="target">The <see cref="IItem"/> to target.</param>
    /// <param name="value0">The first value.</param>
    /// <param name="value1">The second value.</param>
    /// <param name="value2">The third value.</param>
    public void Add(IItem target, int value0 = 0, int value1 = 0, int value2 = 0) => Add(target.StringId, value0, value1, value2);

    /// <summary>
    /// Adds a new <see cref="ModReference"/> based on the provided <see cref="IReference"/>.
    /// If the <see cref="IReference"/> is a <see cref="ModReference"/> it will be added without recreation.
    /// </summary>
    /// <param name="reference">The <see cref="IReference"/> to add.</param>
    public void AddFrom(IReference reference) => Add(reference is ModReference mr ? mr : new ModReference(reference));

    /// <summary>
    /// Compares this collection with another returning any changes.
    /// </summary>
    /// <param name="baseReferences">Collection to comapre to this one.</param>
    /// <returns>A collection containing the added or modified <see cref="Reference"/>s.</returns>
    public IEnumerable<Reference> GetChanges(ModReferenceCollection baseReferences)
    {
        // All instances that are new (not in the baseInstances) or modified
        foreach (var reference in this.Where(r => !baseReferences.TryGetValue(r.TargetId, out var br) || r != br)
                                      .Select(r => new Reference(r)))
        {
            yield return reference;
        }

        // All instances that were deleted (not present in current instances)
        foreach (var reference in baseReferences.Where(i => !TryGetValue(i.TargetId, out var _)))
        {
            yield return reference.AsDeleted();
        }
    }

    /// <summary>
    /// Compares this collection with another returning any changes.
    /// </summary>
    /// <param name="baseReferences">Collection to comapre to this one.</param>
    /// <param name="changes">A collection containing the added or modified <see cref="Reference"/>s.</param>
    /// <returns><c>true</c> if there are any changes; otherwise, <c>false</c>.</returns>
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

    protected override string GetKeyForItem(ModReference item) => item.TargetId;
}
