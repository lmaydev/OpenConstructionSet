using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations;

using IOPath = Path;

/// <inheritdoc/>
public class ModFolder : IModFolder
{
    /// <summary>
    /// Creates a new <see cref="ModFolder"/> instance from the provided values.
    /// </summary>
    /// <param name="path">The path of the folder.</param>
    /// <param name="type">The <see cref="ModFolderType"/> of the folder.</param>
    public ModFolder(string path, ModFolderType type)
    {
        Path = path;
        Type = type;
    }

    /// <inheritdoc/>
    public string Path { get; }

    /// <inheritdoc/>
    public ModFolderType Type { get; }

    /// <inheritdoc/>
    public string GetModPath(string modName, uint modId = 0)
    {
        var filename = IOPath.GetFileName(modName).AddModExtension();
        var name = IOPath.GetFileNameWithoutExtension(filename);

        return Type switch
        {
            ModFolderType.Data => IOPath.Combine(Path, filename),
            ModFolderType.Mod => IOPath.Combine(Path, name, filename),
            ModFolderType.Content => IOPath.Combine(Path, modId.ToString(), filename),
            _ => throw new InvalidOperationException($"Unknown ModFolderType: {Type}")
        };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public override string ToString() => $"{Path} ({Type})";

    /// <inheritdoc/>
    public bool TryFind(string modName, [MaybeNullWhen(false)] out IModFile file)
    {
        file = GetMods().FirstOrDefault(m => m.Filename == modName || m.Name == modName);

        return file is not null;
    }
}
