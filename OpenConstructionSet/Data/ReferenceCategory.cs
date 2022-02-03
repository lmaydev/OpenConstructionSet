namespace OpenConstructionSet.Data
{
    public class ReferenceCategory : List<Reference>
    {
        public ReferenceCategory(ReferenceCategory category) : this(category.Name, category)
        {
        }

        public ReferenceCategory(string name)
        {
            Name = name;
        }

        public ReferenceCategory(string name, IEnumerable<Reference> collection) : base(collection.Select(r => new Reference(r)))
        {
            Name = name;
        }

        public ReferenceCategory(string name, int capacity) : base(capacity)
        {
            Name = name;
        }

        public string Name { get; }

        public override bool Equals(object? obj)
        {
            return obj is ReferenceCategory category &&
                   Name == category.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override string? ToString() => $"{Name} (Count: {Count})";
    }
}