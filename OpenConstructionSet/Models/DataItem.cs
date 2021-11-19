using OpenConstructionSet.Collections;
using System.ComponentModel.DataAnnotations;

namespace OpenConstructionSet.Models;

/// <summary>
/// Editable representation of a item from a data file.
/// </summary>
public class DataItem : IDataModel
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public string Key => StringId;

    /// <summary>
    /// Unique string identifier.
    /// </summary>
    public string StringId { get; }

    /// <summary>
    /// The type of the item.
    /// </summary>
    public ItemType Type { get; }

    /// <summary>
    /// Unique identifier for in game data.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the item.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A dictionary of stored values.
    /// </summary>
    public Dictionary<string, object> Values { get; }

    /// <summary>
    /// A collection of categories that contain the item's references.
    /// </summary>
    public OcsList<DataReferenceCategory> ReferenceCategories { get; }

    /// <summary>
    /// A collection of instances.
    /// </summary>
    public OcsList<DataInstance> Instances { get; }

    /// <summary>
    /// Creates a new <c>DataItem</c> from the given values.
    /// </summary>
    /// <param name="type">The type of the item.</param>
    /// <param name="id">Unique identifier.</param>
    /// <param name="name">Name of the item.</param>
    /// <param name="stringId">Unique string identifier.</param>
    public DataItem(ItemType type, int id, string name, string stringId) : this(type, id, name, stringId, new Dictionary<string, object>(), Enumerable.Empty<DataReferenceCategory>(), Enumerable.Empty<DataInstance>())
    {
    }

    /// <summary>
    /// Creates a new <c>DataItem</c> from the provided <c>Item</c>.
    /// </summary>
    /// <param name="item">An <c>Item</c> whose values will be used when creating the <c>DataItem</c>.</param>
    public DataItem(Item item) : this(item.Type,
                                      item.Id,
                                      item.Name,
                                      item.StringId,
                                      item.Values,
                                      item.ReferenceCategories.Select(c => new DataReferenceCategory(c)),
                                      item.Instances.Select(i => new DataInstance(i)))
    {
    }

    /// <summary>
    /// Creates a new <c>DataItem</c> from the given values.
    /// </summary>
    /// <param name="type">The type of the item.</param>
    /// <param name="id">Unique identifier for in game data.</param>
    /// <param name="name">Name of the item.</param>
    /// <param name="stringId">Unique string identifier.</param>
    /// <param name="values">A dictionary of stored values.</param>
    /// <param name="referenceCategories">A collection of categories that contain the item's references.</param>
    /// <param name="instances">A collection of instances.</param>
    public DataItem(ItemType type, int id, string name, string stringId, IDictionary<string, object> values, IEnumerable<DataReferenceCategory> referenceCategories, IEnumerable<DataInstance> instances)
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
    /// <returns><c>true</c> if there are changes; otherwise, <c>false</c>.</returns>
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
                changes.Instances.Add(new(pair.Value));

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
                changes.ReferenceCategories.Add(new(pair.Value));

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
                        changedCategory.References.Add(new(reference.Value));
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

