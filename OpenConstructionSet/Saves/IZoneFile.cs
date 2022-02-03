namespace OpenConstructionSet.Saves
{
    public interface IZoneFile : IDataFile
    {
        Tuple<int, int> Id { get; }
    }
}
