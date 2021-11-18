using OpenConstructionSet.Collections;
using System.ComponentModel.DataAnnotations;

namespace OpenConstructionSet.Models;

public class DataItem : IDataModel
{
    public string Key => StringId;

    public string StringId { get; }

    public ItemType Type { get; }

    public int Id { get; set; }

    public string Name { get; set; }

    public Dictionary<string, object> Values { get; set; }

    public OcsList<DataInstance> Instances { get; }

    public OcsList<DataReferenceCategory> ReferenceCategories { get; }

    public DataItem(string stringId, ItemType type, int id, string name) : this(stringId, type, id, name, new(), Enumerable.Empty<DataInstance>(), Enumerable.Empty<DataReferenceCategory>())
    {
    }

    public DataItem(Item item) : this(item.StringId,
                                      item.Type,
                                      item.Id,
                                      item.Name,
                                      item.Values,
                                      item.Instances.Select(i => new DataInstance(i)),
                                      item.ReferenceCategories.Select(c => new DataReferenceCategory(c)))
    {
    }

    public DataItem(string stringId, ItemType type, int id, string name, Dictionary<string, object> values, IEnumerable<DataInstance> instances, IEnumerable<DataReferenceCategory> referenceCategories)
    {
        StringId = stringId;
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
            if (instance.IsDeleted())
            {
                Instances.Remove(instance.Id);
            }
            else
            {
                Instances.Update(new(instance));
            }
        }

        foreach (var category in changes.ReferenceCategories)
        {
            if (!ReferenceCategories.TryGetValue(category.Name, out var existingCategory))
            {
                ReferenceCategories.Add(new(category));
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
                        existingCategory.Update(new(reference));
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

