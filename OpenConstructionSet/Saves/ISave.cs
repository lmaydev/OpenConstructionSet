
namespace OpenConstructionSet.Saves
{
    public interface ISave
    {
        string Path { get; }
        string PlatoonFolder { get; }
        string PortraitsTexture { get; }
        IDataFile SaveFile { get; }
        string ZoneFolder { get; }

        IEnumerable<IPlatoonFile> GetPlatoonFiles();
        IEnumerable<IZoneFile> GetZoneFiles();
    }
}