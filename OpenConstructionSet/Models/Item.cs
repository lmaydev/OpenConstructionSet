namespace OpenConstructionSet.Models;

public sealed record Item(ItemType Type, int Id, string Name, string StringId, ItemChanges Changes, Dictionary<string, object> Values, List<ReferenceCategory> ReferenceCategories, List<Instance> Instances)
{
    public Item(ItemType Type, int Id, string Name, string StringId, ItemChanges Changes) : this(Type, Id, Name, StringId, Changes, new(), new(), new())
    {
    }

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
    /// Apply the changes from <c>item</c> to this <c>Item</c>.
    /// </summary>
    /// <param name="changes">A set of changes to be applied.</param>
    /// <exception cref="InvalidOperationException">Items' types must match</exception>
    public static Item ApplyChanges(Item item, Item changes)
    {
        if (changes.Type != item.Type)
        {
            throw new InvalidOperationException("Items' types must match");
        }

        item = item with { Id = changes.Id, Name = changes.Name, Changes = changes.Changes };

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
            var baseCategory = item.ReferenceCategories.Find(c => c.Name == category.Name);

            if (baseCategory is null)
            {
                item.ReferenceCategories.Add(category with { });
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

        return item;
    }

    /// <summary>
    /// Attempts to get an <c>Item</c> representing the changes between this and the provided <c>baseItem</c>.
    /// </summary>
    /// <param name="baseItem">Base item to compare to.</param>
    /// <param name="changes">If successful will contain the changes.</param>
    /// <returns><c>true</c> if there are changes; otherwise, <c>false</c></returns>
    public static bool TryGetChanges(Item item, Item baseItem, out Item changes)
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
