namespace OpenConstructionSet.Saves;

using IOPath = System.IO.Path;

public class Save : ISave
{
    public Save(string path)
    {
        Path = path;

        Name = Path.Split('\\', StringSplitOptions.RemoveEmptyEntries).Last();

        SaveFile = new DataFile(IOPath.Combine(path, "quick.save"));

        PortraitsTexture = IOPath.Combine(path, "portraits_texture.png");

        ZoneFolder = IOPath.Combine(path, "zone\\");

        PlatoonFolder = IOPath.Combine(path, "platoon\\");
    }

    public string Name { get; }

    public string Path { get; }
    public string PlatoonFolder { get; }
    public string PortraitsTexture { get; }
    public IDataFile SaveFile { get; }
    public string ZoneFolder { get; }

    public virtual IEnumerable<IPlatoonFile> GetPlatoonFiles() => Directory.GetFiles(PlatoonFolder, "*_*.platoon").Select(f => new PlatoonFile(f));

    public virtual IEnumerable<IZoneFile> GetZoneFiles() => Directory.GetFiles(ZoneFolder, "zone.*.*.zone").Select(f => new ZoneFile(f));

    public override string ToString() => $"{Name} ({Path})";
}
