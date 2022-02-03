using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations;

using IOPath = Path;

/// <summary>
/// Representation of a mod folder.
/// </summary>
public class ModFolder : IModFolder
{
    /// <summary>
    /// Creates a new <c>ModFolder</c> instance.
    /// </summary>
    /// <param name="path">The full path of the folder.</param>
    /// <param name="type">The type of the folder.</param>
    public ModFolder(string path, ModFolderType type)
    {
        Path = path;
        Type = type;
    }

    /// <summary>
    /// the full path of the folder.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// The type of the folder.
    /// </summary>
    public ModFolderType Type { get; }

    /// <summary>
    /// Get the path for a mod given its folder and name.
    /// </summary>
    /// <param name="modName">The name of the mod. e.g. example or example.mod</param>
    /// <param name="modId">The Id value from the mod's .info file. Only required for content folders.</param>
    /// <returns>The full path for the mod name for in the given folder.</returns>
    public string GetModPath(string modName, uint modId = 0)
    {
        var filename = IOPath.GetFileName(modName).AddModExtension();
        var name = IOPath.GetFileNameWithoutExtension(filename);

        return Type switch
        {
            ModFolderType.Data => IOPath.Combine(Path, filename),
            ModFolderType.Mod => IOPath.Combine(Path, name, filename),
            ModFolderType.Content => IOPath.Combine(Path, modId.ToString(), filename),
            _ => throw new InvalidOperationException($"Unkown ModFolderType: {Type}")
        };
    }

    public virtual IEnumerable<IModFile> GetMods()
    {
        var modPaths = Type switch
        {
            ModFolderType.Data => Directory.GetFiles(Path, "*.base").Concat(Directory.GetFiles(Path, "*.mod")),

            ModFolderType.Mod => Directory.GetDirectories(Path).Select(d =>
            {
                var modName = d.Split("\\", StringSplitOptions.RemoveEmptyEntries).Last().AddModExtension();

                return IOPath.Combine(d, modName);
            }),

            _ => Directory.GetDirectories(Path).SelectMany(d => Directory.GetFiles(d, "*.mod"))
        };

        return modPaths.Where(File.Exists).Select(f => new ModFile(f));
    }

    public override string ToString() => $"{Path} ({Type.ToString()})";
}
