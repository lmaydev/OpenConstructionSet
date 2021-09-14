using System.Collections.Generic;

namespace OpenConstructionSet.Models
{
    public class Item
    {
        public Dictionary<string, object> Values { get; } = new();

        public Dictionary<string, List<Reference>> References { get; } = new();

        public List<Instance> Instances { get; set; } = new();

        public ItemType Type { get; }
        public string StringId { get; }

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
    }
}