namespace OpenConstructionSet.Models;

public sealed class Item
{
    public Dictionary<string, object> Values { get; init; } = new();

    public List<Reference> References { get; init; } = new();

    public List<Instance> Instances { get; init; } = new();

    public ItemType Type { get; set; }
    public string StringId { get; set; }

    public int Id { get; set; }
    public string Name { get; set; }
    public ItemChanges Changes { get; set; }

    public Item(ItemType type, int id, string name, string stringId, ItemChanges changes)
    {
        Type = type;
        Id = id;
        Name = name;
        StringId = stringId;
        Changes = changes;
    }

    public Item Duplicate() => new(Type, Id, Name, StringId, Changes)
    {
        Values = new(Values),
        References = new(References),
        Instances = new(Instances),
    };

    public Item AsDeleted() => new(Type, Id, Name, StringId, Changes)
    {
        Values = new Dictionary<string, object> { ["DELETED"] = true }
    };

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
