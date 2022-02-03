namespace OpenConstructionSet.Data
{
    public class Item
    {
        public Item(Item item) : this(
            item.Type,
            item.Id,
            item.Name,
            item.StringId,
            item.ChangeType,
            item.Values,
            item.ReferenceCategories,
            item.Instances)
        {
        }

        public Item(ItemType type, int id, string name, string stringId, ItemChangeType changeType)
        {
            Type = type;
            Id = id;
            Name = name;
            StringId = stringId;
            ChangeType = changeType;

            Values = new();
            ReferenceCategories = new();
            Instances = new();
        }

        public Item(ItemType type, int id, string name, string stringId, ItemChangeType changeType, IDictionary<string, object> values, IEnumerable<ReferenceCategory> referenceCategories, IEnumerable<Instance> instances)
        {
            Type = type;
            Id = id;
            Name = name;
            StringId = stringId;
            ChangeType = changeType;

            Values = new(values);
            ReferenceCategories = new(referenceCategories.Select(c => new ReferenceCategory(c)));
            Instances = new(instances.Select(i => new Instance(i)));
        }

        public ItemChangeType ChangeType { get; set; }
        public int Id { get; set; }
        public List<Instance> Instances { get; } = new();
        public string Name { get; set; }
        public List<ReferenceCategory> ReferenceCategories { get; } = new();
        public string StringId { get; }
        public ItemType Type { get; set; }
        public OrderedDictionary<string, object> Values { get; } = new();
    }
}