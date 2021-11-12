namespace OpenConstructionSet.Models;

/// <summary>
/// Represent an Item from a game data file.
/// </summary>
public sealed class Item
{
    /// <summary>
    /// The values associated with the Item.
    /// </summary>
    public Dictionary<string, object> Values { get; init; } = new();

    /// <summary>
    /// The references associated with the Item.
    /// </summary>
    public List<ReferenceCategory> ReferenceCategories { get; private set; } = new();

    /// <summary>
    /// The instances associated with the Item.
    /// </summary>
    public List<Instance> Instances { get; private set; } = new();

    /// <summary>
    /// The type of the Item.
    /// </summary>
    public ItemType Type { get; set; }

    /// <summary>
    /// The unique id of this Item.
    /// </summary>
    public string StringId { get; set; }

    /// <summary>
    /// Still not sure what this does.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of this Item.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Represents the state of changes to this item.
    /// </summary>
    public ItemChanges Changes { get; set; }

    /// <summary>
    /// Initializes a new <c>Item</c>.
    /// </summary>
    /// <param name="type">Item type.</param>
    /// <param name="id">Not sure, seems to be 0 for mod files.</param>
    /// <param name="name">Item's name.</param>
    /// <param name="stringId">Item's unique identifier</param>
    /// <param name="changes">The state of changes to this item.</param>
    public Item(ItemType type, int id, string name, string stringId, ItemChanges changes)
    {
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        Changes = changes;
    }

    /// <summary>
    /// Duplicate's the current Item.
    /// </summary>
    /// <returns>A duplicate of the current Item.</returns>
    public Item Duplicate() => new(Type, Id, Name, StringId, Changes)
    {
        Values = new(Values),
        ReferenceCategories = new(ReferenceCategories.Select(c => new ReferenceCategory(c))),
        Instances = new(Instances)
    };

    /// <summary>
    /// Apply the changes from <c>item</c> to this <c>Item</c>.
    /// </summary>
    /// <param name="item">A set of changes to be applied.</param>
    /// <exception cref="InvalidOperationException">Items' types must match</exception>
    public void ApplyChanges(Item item)
    {
        if (item.Type != Type)
        {
            throw new InvalidOperationException("Items' types must match");
        }

        Id = item.Id;
        Name = item.Name;
        Changes = item.Changes;

        foreach (var pair in item.Values)
        {
            Values[pair.Key] = pair.Value;
        }

        foreach (var instance in item.Instances)
        {
            if (Instances.Contains(instance))
            {
                Instances.Remove(instance);
            }

            if (!instance.IsDeleted())
            {
                Instances.Add(instance);
            }
        }

        foreach (var category in item.ReferenceCategories)
        {
            var baseCategory = ReferenceCategories.Find(c => c.Name == category.Name);

            if (baseCategory is null)
            {
                ReferenceCategories.Add(category with { });
            }
            else
            {
                foreach (var reference in category.References)
                {
                    if (reference.IsDeleted())
                    {
                        var index = baseCategory.References.FindIndex(r => r.TargetId == reference.TargetId);

                        if (index > -1)
                        {
                            baseCategory.References.RemoveAt(index);
                        }
                    }
                    else
                    {
                        baseCategory.References.Add(reference);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Attempts to get an <c>Item</c> representing the changes between this and the provided <c>baseItem</c>.
    /// </summary>
    /// <param name="baseItem">Base item to compare to.</param>
    /// <param name="changes">If successful will contain the changes.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c></returns>
    public bool TryGetChanges(Item baseItem, out Item changes)
    {
        var changed = Name != baseItem.Name;

        changes = new Item(Type, Id, Name, StringId, changed ? ItemChanges.Renamed : ItemChanges.Changed);

        foreach (var pair in Values)
        {
            if (!baseItem.Values.TryGetValue(pair.Key, out var value) || value != pair.Value)
            {
                changes.Values[pair.Key] = pair.Value;
                changed = true;
            }
        }

        var usedKeys = new HashSet<string>();

        foreach (var instance in Instances)
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

        foreach (var category in ReferenceCategories)
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
                var changedCategory = new ReferenceCategory(category.Name, new());

                foreach (var reference in category.References)
                {
                    usedKeys.Add(reference.TargetId);

                    var baseReference = baseCategory.References.Find(r => r.TargetId == reference.TargetId);

                    if (baseReference is null || reference != baseReference)
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

            changes.ReferenceCategories.Add(new(baseCategory.Name, new(baseCategory.References.Select(r => r.Delete()))));
        }

        return changed;
    }
}
