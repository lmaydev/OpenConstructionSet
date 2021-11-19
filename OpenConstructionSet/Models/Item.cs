using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Models;

/// <summary>
/// Represents an item from a data file.
/// </summary>
/// <param name="Type">The type of the item.</param>
/// <param name="Id">Unique identifier for in game data.</param>
/// <param name="Name">Name of the item.</param>
/// <param name="StringId">Unique string identifier.</param>
/// <param name="Changes">What changes were applied to this data item.</param>
/// <param name="Values">A dictionary of stored values.</param>
/// <param name="ReferenceCategories">A collection of categories that contain the item's references.</param>
/// <param name="Instances">A collection of instances.</param>
public sealed record Item(ItemType Type, int Id, string Name, string StringId, ItemChanges Changes, Dictionary<string, object> Values, List<ReferenceCategory> ReferenceCategories, List<Instance> Instances)
{
    /// <summary>
    /// Represents an item from a data file.
    /// </summary>
    /// <param name="Type">The type of the item.</param>
    /// <param name="Id">Unique identifier.</param>
    /// <param name="Name">Name of the item.</param>
    /// <param name="StringId">Unique string identifier</param>
    /// <param name="Changes">What changes were applied to this data item.</param>
    public Item(ItemType Type, int Id, string Name, string StringId, ItemChanges Changes) : this(Type, Id, Name, StringId, Changes, new(), new(), new())
    {
    }

    /// <summary>
    /// Copy constructor.
    /// </summary>
    /// <param name="item"><c>Item</c> to clone.</param>
    public Item(Item item)
    {
        Type = item.Type;
        Id = item.Id;
        Name = item.Name;
        StringId = item.StringId;
        Changes = item.Changes;

        Values = new(item.Values);
        ReferenceCategories = new(item.ReferenceCategories);
        Instances = new(item.Instances);
    }

    /// <summary>
    /// Create an <c>Item</c> from the given <c>DataItem</c>.
    /// </summary>
    /// <param name="data"><c>DataItem</c> to get values from.</param>
    /// <param name="changes">Current changes to the item.</param>
    /// 
    public Item(DataItem data, ItemChanges changes) : this(data.Type, data.Id, data.Name, data.StringId, changes)
    {
    }

    /// <summary>
    /// Apply the changes from <c>item</c> to this <c>Item</c>.
    /// </summary>
    /// <param name="changes">A set of changes to be applied.</param>
    /// <exception cref="InvalidOperationException">Items' types must match</exception>
    public Item ApplyChanges(Item changes)
    {
        if (changes.Type != Type)
        {
            throw new InvalidOperationException("Items' types must match");
        }

        var item = this with { Id = changes.Id, Name = changes.Name, Changes = changes.Changes };

        foreach (var pair in changes.Values)
        {
            item.Values[pair.Key] = pair.Value;
        }

        foreach (var instance in changes.Instances)
        {
            var index = item.Instances.FindIndex(i => i.Id == instance.Id);

            if (index > -1)
            {
                item.Instances.RemoveAt(index);
            }

            if (!instance.IsDeleted())
            {
                item.Instances.Add(instance);
            }
        }

        foreach (var category in changes.ReferenceCategories)
        {
            var existing = item.ReferenceCategories.Find(c => c.Name == category.Name);

            if (existing is null)
            {
                item.ReferenceCategories.Add(new(category));
            }
            else
            {
                foreach (var reference in category.References)
                {
                    var index = existing.References.FindIndex(r => r.TargetId == reference.TargetId);

                    if (index > -1)
                    {
                        existing.References.RemoveAt(index);
                    }

                    if (!reference.IsDeleted())
                    {
                        existing.References.Add(reference);
                    }
                }
            }
        }

        return item;
    }

    /// <summary>
    /// Attempts to get an <c>Item</c> representing the changes between this and the provided <c>baseItem</c>.
    /// </summary>
    /// <param name="item">Active item containing possible changes.</param>
    /// <param name="baseItem">Base item to compare to.</param>
    /// <param name="changes">If successful will contain the changes.</param>
    /// <returns><c>true</c> if there are changes; otherwise, <c>false</c></returns>
    public static bool TryGetChanges(Item item, Item baseItem, [MaybeNullWhen(false)]out Item changes)
    {
        var changed = item.Name != baseItem.Name;

        changes = new Item(item.Type, item.Id, item.Name, item.StringId, item.Name != baseItem.Name ? ItemChanges.Renamed : ItemChanges.Changed);

        foreach (var pair in item.Values)
        {
            if (!baseItem.Values.TryGetValue(pair.Key, out var value) || value != pair.Value)
            {
                changes.Values[pair.Key] = pair.Value;
                changed = true;
            }
        }

        var usedKeys = new HashSet<string>();

        foreach (var instance in item.Instances)
        {
            usedKeys.Add(instance.Id);

            var baseIndex = baseItem.Instances.FindIndex(i => i.Id == instance.Id);

            if (baseIndex == -1 || baseItem.Instances[baseIndex] != instance)
            {
                changes.Instances.Add(instance);

                changed = true;
            }
        }

        foreach (var baseInstance in baseItem.Instances)
        {
            if (usedKeys.Contains(baseInstance.Id))
            {
                continue;
            }

            changes.Instances.Add(baseInstance.Delete());

            changed = true;
        }

        usedKeys.Clear();

        var usedCategories = new HashSet<string>();

        foreach (var category in item.ReferenceCategories)
        {
            usedCategories.Add(category.Name);

            var baseCategory = baseItem.ReferenceCategories.Find(c => c.Name == category.Name);

            if (baseCategory is null)
            {
                changes.ReferenceCategories.Add(category with { });

                changed = true;
            }
            else
            {
                var changedCategory = new ReferenceCategory(category.Name, new List<Reference>());

                foreach (var reference in category.References)
                {
                    usedKeys.Add(reference.TargetId);

                    var baseIndex = baseCategory.References.FindIndex(r => r.TargetId == reference.TargetId);

                    if (baseIndex == -1 || reference != baseCategory.References[baseIndex])
                    {
                        changedCategory.References.Add(reference);
                    }
                }

                foreach (var baseReference in baseCategory.References)
                {
                    if (usedKeys.Contains(baseReference.TargetId))
                    {
                        continue;
                    }

                    changedCategory.References.Add(baseReference.Delete());
                }

                usedKeys.Clear();

                if (changedCategory.References.Any())
                {
                    changes.ReferenceCategories.Add(changedCategory);
                    changed = true;
                }
            }
        }

        foreach (var baseCategory in baseItem.ReferenceCategories)
        {
            if (usedCategories.Contains(baseCategory.Name))
            {
                continue;
            }

            changes.ReferenceCategories.Add(new(baseCategory.Name, new List<Reference>(baseCategory.References.Select(r => r.Delete()))));
        }

        if (changed)
        {
            return true;
        }

        changes = null;
        return false;
    }
}
