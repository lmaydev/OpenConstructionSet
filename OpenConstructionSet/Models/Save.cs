namespace OpenConstructionSet.Models;

/// <summary>
/// Represents a single save directory structure.
/// </summary>
public sealed record Save(string FolderPath)
{
    private string? name, saveFile, portraitsTexture, zoneFolder, platoonFolder;

    /// <summary>
    /// A collection containing the paths of all platoon files.
    /// </summary>
    public List<string> PlatoonFiles { get; } = new();

    /// <summary>
    /// A collection containing the paths of all zone files.
    /// </summary>
    public List<string> ZoneFiles { get; } = new();

    /// <summary>
    /// Name of the save.
    /// </summary>
    public string Name => name ??= new DirectoryInfo(FolderPath).Name ?? "";

    /// <summary>
    /// Path of the save file.
    /// </summary>
    public string QuickFile => saveFile ??= Path.Combine(FolderPath, "quick.save");

    /// <summary>
    /// Path to the portraits text.
    /// </summary>
    public string PortraitsTexture => portraitsTexture ??= Path.Combine(FolderPath, "portraits_texture.png");

    /// <summary>
    /// Path of the Zone folder.
    /// </summary>
    public string ZoneFolder => zoneFolder ??= Path.Combine(FolderPath, "zone");

    /// <summary>
    /// Path of the Platoon folder
    /// </summary>
    public string PlatoonFolder => platoonFolder ??= Path.Combine(FolderPath, "platoon");
}