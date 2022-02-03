namespace OpenConstructionSet.Saves
{
    public interface IPlatoonFile : IDataFile
    {
        string Faction { get; }
        int Id { get; }
    }
}
