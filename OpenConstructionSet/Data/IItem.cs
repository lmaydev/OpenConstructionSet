namespace OpenConstructionSet.Data
{
    public interface IItem
    {
        int Id { get; set; }
        ICollection<IInstance> Instances { get; }
        string Name { get; set; }
        ICollection<IReferenceCategory> ReferenceCategories { get; }
        string StringId { get; }
        ItemType Type { get; set; }
        IDictionary<string, object> Values { get; }
    }
}
