namespace OpenConstructionSet.Data
{
    public interface IItem
    {
        ItemChangeType ChangeType { get; set; }
        int Id { get; set; }
        IEnumerable<IInstance> Instances { get; }
        string Name { get; set; }
        IEnumerable<IReferenceCategory> ReferenceCategories { get; }
        string StringId { get; }
        ItemType Type { get; set; }
        IDictionary<string, object> Values { get; }
    }
}
