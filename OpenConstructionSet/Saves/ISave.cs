namespace OpenConstructionSet.Saves;

/// <summary>
/// Represents an individual save folder.
/// </summary>
public interface ISave
{
    /// <summary>
    /// Path of the <see cref="ISave"/>'s root folder.
    /// </summary>
    string Path { get; }

    /// <summary>
    /// Path of the <see cref="ISave"/>'s platoon folder.
    /// </summary>
    string PlatoonFolder { get; }

    /// <summary>
    /// Path of the <see cref="ISave"/>'s portrait image file.
    /// </summary>
    string PortraitsTexture { get; }

    /// <summary>
    /// Representation of the <see cref="ISave"/>'s quick.save file.
    /// </summary>
    IDataFile SaveFile { get; }

    /// <summary>
    /// Path of the <see cref="ISave"/>'s zone folder.
    /// </summary>
    string ZoneFolder { get; }

    /// <summary>
    /// Get's all <see cref="IPlatoonFile"/>s in the <see cref="ISave.PlatoonFolder"/>.
    /// </summary>
    /// <returns>A collection of <see cref="IPlatoonFile"/>s contained in this <see cref="ISave"/>.</returns>
    IEnumerable<IPlatoonFile> GetPlatoonFiles();

    /// <summary>
    /// Get's all <see cref="IZoneFile"/>s in the <see cref="ISave.ZoneFolder"/>.
    /// </summary>
    /// <returns>A collection of <see cref="IZoneFile"/>s contained in this <see cref="ISave"/>.</returns>
    IEnumerable<IZoneFile> GetZoneFiles();
}
