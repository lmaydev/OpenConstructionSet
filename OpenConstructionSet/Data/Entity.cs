using OpenConstructionSet.Collections;
using System.ComponentModel;

namespace OpenConstructionSet.Data;

public class Entity : IRevertibleChangeTracking, IClearable
{
    private readonly PropertyTracker properties = new();

    public bool IsChanged => properties.IsChanged || Values.IsChanged || Instances.IsChanged || ReferenceCategories.IsChanged;

    public OcsDictionary<object> Values { get; }

    public ReferenceCollection ReferenceCategories { get; }

    public OcsDictionary<InstanceValues> Instances { get; }

    public ItemType Type { get; }
    public string StringId { get; }

    public int Id
    {
        get => properties.Get<int>(nameof(Id));

        set => properties.Set<int>(nameof(Id), value);
    }

    public string Name
    {
        get => properties.Get<string>(nameof(Name));

        set => properties.Set<string>(nameof(Name), value);
    }

    internal Entity(ItemType type, string stringId,
                    string name, int id = 0,
                    OcsDictionary<object>? values = null,
                    OcsDictionary<InstanceValues>? instances = null,
                    ReferenceCollection? referenceCategories = null)
    {
        Values = values ?? new();
        ReferenceCategories = referenceCategories ?? new();
        Instances = instances ?? new();
        Type = type;
        StringId = stringId;

        Id = id;

        Name = name;
    }

    internal Entity(Item item) : this(item.Type, item.StringId, item.Name, item.Id,
        new(item.Values),
        new(item.Instances.ToDictionary(i => i.id, i => new InstanceValues(i))),
        // Create outer dictionary using the category name (key).
        // Then create the inner dictionary using the targetId as the key
        new(item.References.ToDictionary(p => p.Key, p => new OcsDictionary<ReferenceValues>(p.Value.ToDictionary(r => r.targetId, r => r.values)))))
    {
    }

    public void RejectChanges()
    {
        properties.RejectChanges();

        Values.RejectChanges();
        Instances.RejectChanges();
        ReferenceCategories.RejectChanges();
    }

    void IChangeTracking.AcceptChanges()
    {
        properties.AcceptChanges();

        (Values as IChangeTracking)?.AcceptChanges();
        (Instances as IChangeTracking)?.AcceptChanges();
        (ReferenceCategories as IChangeTracking)?.AcceptChanges();
    }

    public void Clear()
    {
        Name = "";
        Id = 0;

        properties.Clear();

        Values.Clear();
        Instances.Clear();
        ReferenceCategories.Clear();
    }

    public void Update(Item item)
    {
        if (Type != item.Type)
        {
            throw new ArgumentException("ItemType must match", nameof(item));
        }

        Id = item.Id;
        Name = item.Name;

        foreach (var pair in item.Values)
        {
            Values[pair.Key] = pair.Value;
        }

        foreach (var instance in item.Instances)
        {
            if (instance.Deleted())
            {
                Instances.Remove(instance.id);
                continue;
            }

            Instances[instance.id] = new(instance);
        }

        foreach (var pair in item.References)
        {
            var category = pair.Key;

            if (!ReferenceCategories.TryGetValue(category, out var references))
            {
                references = ReferenceCategories.New(category);
            }

            foreach (var reference in pair.Value)
            {
                if (reference.Deleted())
                {
                    references.Remove(reference.targetId);
                    continue;
                }

                references[reference.targetId] = reference.values;
            }
        }
    }

    public Item GetChanges(bool newItem)
    {
        var changes = newItem ? ItemChanges.New : properties.Modified(nameof(Name)) ? ItemChanges.Renamed : ItemChanges.Changed;

        var item = new Item(Type, Id, Name, StringId, changes);

        if (!IsChanged)
        {
            return item;
        }

        GetValueChanges(item);

        GetInstanceChanges(item);

        GetReferencesChanges(item);

        return item;

        void GetInstanceChanges(Item item)
        {
            var changes = Instances.GetChanges();

            item.Instances.AddRange(changes.Removed.Select(p => new Instance(p).Delete()));

            item.Instances.AddRange(changes.Added.Union(changes.Modified).Select(p => new Instance(p)));
        }

        void GetValueChanges(Item item)
        {
            foreach (var id in Values.Added.Union(Values.Modified))
            {
                item.Values[id] = Values[id];
            }
        }

        void GetReferencesChanges(Item item)
        {
            var categoryChanges = ReferenceCategories.GetChanges();

            foreach (var pair in categoryChanges.Removed)
            {
                // Removed category, add all items as deleted
                item.References[pair.Key] = pair.Value.Select(p => new Reference(p).Delete()).ToList();
            }

            foreach (var pair in categoryChanges.Added)
            {
                // Added category, add all items
                item.References[pair.Key] = pair.Value.Select(p => new Reference(p)).ToList();
            }

            foreach (var pair in categoryChanges.Modified)
            {
                var references = new List<Reference>();

                // Changed states need to be handled individually so create and add list first
                item.References[pair.Key] = references;

                var referenceChanges = pair.Value.GetChanges();

                // Add all removed items as deleted
                references.AddRange(referenceChanges.Removed.Select(p => new Reference(p).Delete()));

                // Add all new and modified items
                references.AddRange(referenceChanges.Added.Select(p => new Reference(p)));
                references.AddRange(referenceChanges.Modified.Select(p => new Reference(p)));
            }
        }
    }

    public Item AsDeleted()
    {
        var deleted = new Item(Type, Id, Name, StringId, ItemChanges.Changed);

        deleted.Delete();

        return deleted;
    }
}
