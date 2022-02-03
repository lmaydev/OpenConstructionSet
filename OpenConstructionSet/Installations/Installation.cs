using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations;

/// <summary>
/// POCO representing an installation of the game.
/// </summary>
public class Installation : IInstallation
{
    /// <summary>
    /// Creates a new <c>Installation</c> instance.
    /// </summary>
    /// <param name="identifier">Name used to identify this installation e.g. Steam</param>
    /// <param name="path">The full path of the installation.</param>
    /// <param name="content">Optional content folder e.g. Steam Workshop folder.</param>
    public Installation(string identifier, string path, ModFolder? content)
    {
        Identifier = identifier;
        Path = path;

        Data = new(System.IO.Path.Combine(path, "data"), ModFolderType.Data);
        Mods = new(System.IO.Path.Combine(path, "mods"), ModFolderType.Mod);

        Content = content;

        //Saves = new(System.IO.Path.Combine(Path, "save"));

        EnabledModsFile = System.IO.Path.Combine(Data.Path, OcsConstants.EnabledModFile);
    }

    /// <summary>
    /// The installation's content folder.
    /// </summary>
    public ModFolder? Content { get; }

    /// <summary>
    /// The installations's data file.
    /// </summary>
    public ModFolder Data { get; }

    /// <summary>
    /// The path of the file that contain's the enabled mods for this installation.
    /// </summary>
    public string EnabledModsFile { get; }

    /// <summary>
    /// Name used to identify this installation e.g. Steam
    /// </summary>
    public string Identifier { get; }

    /// <summary>
    /// The installation's mod file.
    /// </summary>
    public ModFolder Mods { get; }

    /// <summary>
    /// The full path of the game's installation folder.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// The save folder located inside the installation.
    /// </summary>
    //public SaveFolder Saves { get; }

    public virtual IEnumerable<IModFile> GetMods()
    {
        var usedNames = new HashSet<string>();

        foreach (var mod in Data.GetMods().Concat(Mods.GetMods()).Concat(Content?.GetMods() ?? Enumerable.Empty<ModFile>()))
        {
            if (usedNames.Contains(mod.Name))
            {
                continue;
            }

            usedNames.Add(mod.Name);

            yield return mod;
        }
    }

    public virtual async Task<string[]> ReadEnabledModsAsync(CancellationToken cancellationToken = default)
        => await File.ReadAllLinesAsync(EnabledModsFile, cancellationToken).ConfigureAwait(false);

    public override string ToString() => $"{Identifier} ({Path})";

    public virtual async Task WriteEnabledModsAsync(IEnumerable<string> enabledMods, CancellationToken cancellationToken = default)
            => await File.WriteAllLinesAsync(EnabledModsFile, enabledMods, cancellationToken).ConfigureAwait(false);
}
