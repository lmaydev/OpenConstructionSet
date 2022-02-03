namespace OpenConstructionSet.Saves;

using IOPath = System.IO.Path;

/// <inheritdoc/>
public class Save : ISave
{
    /// <summary>
    /// Creats a new <see cref="Save"/> instance from the given path.
    /// </summary>
    /// <param name="path">The path of the <see cref="Save"/>'s root folder.</param>
    public Save(string path)
    {
        Path = path;

        Name = Path.Split('\\', StringSplitOptions.RemoveEmptyEntries).Last();

        SaveFile = new DataFile(IOPath.Combine(path, "quick.save"));

        PortraitsTexture = IOPath.Combine(path, "portraits_texture.png");

        ZoneFolder = IOPath.Combine(path, "zone\\");

        PlatoonFolder = IOPath.Combine(path, "platoon\\");
    }

    /// <inheritdoc/>
    public string Name { get; }

    /// <inheritdoc/>
    public string Path { get; }

    /// <inheritdoc/>
    public string PlatoonFolder { get; }

    /// <inheritdoc/>
    public string PortraitsTexture { get; }

    /// <inheritdoc/>
    public IDataFile SaveFile { get; }

    /// <inheritdoc/>
    public string ZoneFolder { get; }

    /// <inheritdoc/>
    public virtual IEnumerable<IPlatoonFile> GetPlatoonFiles() => Directory.GetFiles(PlatoonFolder, "*_*.platoon").Select(f => new PlatoonFile(f));

    /// <inheritdoc/>
    public virtual IEnumerable<IZoneFile> GetZoneFiles() => Directory.GetFiles(ZoneFolder, "zone.*.*.zone").Select(f => new ZoneFile(f));

    /// <inheritdoc/>
    public override string ToString() => $"{Name} ({Path})";
}
