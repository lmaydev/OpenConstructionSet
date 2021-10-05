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
    public List<Reference> References { get; init; } = new();

    /// <summary>
    /// The instances associated with the Item.
    /// </summary>
    public List<Instance> Instances { get; init; } = new();

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
        References = new(References),
        Instances = new(Instances),
    };

    /// <summary>
    /// Apply the changes from <c>item</c> to this item.
    /// </summary>
    /// <param name="item">A set of changes to be applied.</param>
    /// <exception cref="InvalidOperationException">Items' types must match</exception>
    public void Update(Item item)
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
            var current = Instances.FindIndex(i => i.Id == instance.Id);

            if (current != -1)
            {
                Instances.RemoveAt(current);
            }

            if (!instance.IsDeleted())
            {
                Instances.Add(instance);
            }
        }

        foreach (var reference in item.References)
        {
            var current = References.FindIndex(i => i.Key == reference.Key);

            if (current != -1)
            {
                References.RemoveAt(current);
            }

            if (!reference.IsDeleted())
            {
                References.Add(reference);
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

        foreach (var reference in References)
        {
            usedKeys.Add(reference.Key);

            var baseIndex = baseItem.References.FindIndex(i => i.Key == reference.Key);

            if (baseIndex == -1 || baseItem.References[baseIndex] != reference)
            {
                changes.References.Add(reference);

                changed = true;
            }
        }

        foreach (var baseReference in baseItem.References)
        {
            if (usedKeys.Contains(baseReference.Key))
            {
                continue;
            }

            changes.References.Add(baseReference.Delete());

            changed = true;
        }

        return changed;
    }
}
