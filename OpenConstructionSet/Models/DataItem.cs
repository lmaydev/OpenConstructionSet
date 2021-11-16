namespace OpenConstructionSet.Models;

public record DataItem
{
    public ItemType Type { get; }

    public int Id { get; set; }

    public string Name { get; set; }

    public Dictionary<string, object> Values { get; set; }

    public Dictionary<string, DataInstance> Instances { get; }

    public Dictionary<string, DataReferenceCategory> ReferenceCategories { get; }

    public DataItem(ItemType Type, int Id, string Name) : this(Type, Id, Name, new(), new(), new())
    {
    }

    public DataItem(Item item) : this(item.Type,
                                      item.Id,
                                      item.Name,
                                      new(item.Values),
                                      new(item.Instances.ToDictionary(i => i.Id, i => new DataInstance(i))),
                                      new(item.ReferenceCategories.ToDictionary(c => c.Name, c => new DataReferenceCategory(c))))
    {
    }

    public DataItem(ItemType type, int id, string name, Dictionary<string, object> values, Dictionary<string, DataInstance> instances, Dictionary<string, DataReferenceCategory> referenceCategories)
    {
        Type = type;
        Id = id;
        Name = name;
        Values = new(values);
        Instances = new(instances);
        ReferenceCategories = new(referenceCategories);
    }

    /// <summary>
    /// Apply the changes from <c>item</c> to this <c>Item</c>.
    /// </summary>
    /// <param name="changes">A set of changes to be applied.</param>
    /// <exception cref="InvalidOperationException">Items' types must match</exception>
    public void ApplyChanges(Item changes)
    {
        if (changes.Type != Type)
        {
            throw new InvalidOperationException("Items' types must match");
        }

        Id = changes.Id;

        Name = changes.Name;

        foreach (var pair in changes.Values)
        {
            Values[pair.Key] = pair.Value;
        }

        foreach (var instance in changes.Instances)
        {
            Instances.Remove(instance.Id);

            if (!instance.IsDeleted())
            {
                Instances[instance.Id] = new(instance);
            }
        }

        foreach (var category in changes.ReferenceCategories)
        {
            if (!ReferenceCategories.TryGetValue(category.Name, out var existingCategory))
            {
                ReferenceCategories[category.Name] = new(category);
            }
            else
            {
                foreach (var reference in category.References)
                {
                    if (reference.IsDeleted())
                    {
                        existingCategory.Remove(reference.TargetId);
                    }
                    else
                    {
                        existingCategory[reference.TargetId] = new(reference);
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
    /// <returns><c>true</c> if there are changes; otherwise, <c>false</c></returns>
    public bool TryGetChanges(Item baseItem, out Item changes)
    {
        var changed = Name != baseItem.Name || Id != baseItem.Id;

        changes = new Item(Type, Id, Name, baseItem.StringId, Name != baseItem.Name ? ItemChanges.Renamed : ItemChanges.Changed);

        foreach (var pair in Values)
        {
            if (!baseItem.Values.TryGetValue(pair.Key, out var value) || value != pair.Value)
            {
                changes.Values[pair.Key] = pair.Value;
                changed = true;
            }
        }

        var usedKeys = new HashSet<string>();

        foreach (var pair in Instances)
        {
            usedKeys.Add(pair.Key);

            var baseIndex = baseItem.Instances.FindIndex(i => i.Id == pair.Key);

            if (baseIndex == -1 || !pair.Value.Equals(baseItem.Instances[baseIndex]))
            {
                changes.Instances.Add(new(pair.Key, pair.Value));

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

        foreach (var pair in ReferenceCategories)
        {
            usedCategories.Add(pair.Key);

            var baseCategory = baseItem.ReferenceCategories.Find(c => c.Name == pair.Key);

            if (baseCategory is null)
            {
                changes.ReferenceCategories.Add(new(pair.Key, pair.Value));

                changed = true;
            }
            else
            {
                var changedCategory = new ReferenceCategory(pair.Key, new List<Reference>());

                foreach (var reference in pair.Value)
                {
                    usedKeys.Add(reference.Key);

                    var baseIndex = baseCategory.References.FindIndex(r => r.TargetId == reference.Key);

                    if (baseIndex == -1 || !reference.Value.Equals(baseCategory.References[baseIndex]))
                    {
                        changedCategory.References.Add(new(reference.Key, reference.Value));
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
            changed = true;
        }

        return changed;
    }
}

