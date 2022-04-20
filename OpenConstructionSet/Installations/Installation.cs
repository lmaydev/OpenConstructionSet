using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods;
using OpenConstructionSet.Saves;

namespace OpenConstructionSet.Installations;

/// <inheritdoc/>
public class Installation : IInstallation
{
    /// <summary>
    /// Creates a new <see cref="Installation"/> from the provided values.
    /// </summary>
    /// <param name="identifier">Name used to identify this installation e.g. Steam</param>
    /// <param name="path">The full path of the installation.</param>
    /// <param name="content">Optional content folder e.g. Steam Workshop folder.</param>
    public Installation(string identifier, string path, string? content)
    {
        Identifier = identifier;
        Path = path;

        Data = new ModFolder(System.IO.Path.Combine(path, "data"), ModFolderType.Data);
        Mods = new ModFolder(System.IO.Path.Combine(path, "mods"), ModFolderType.Mod);

        Content = content is not null ? new ModFolder(content, ModFolderType.Content) : null;

        Saves = new SaveFolder(System.IO.Path.Combine(Path, "save"));

        EnabledModsFile = System.IO.Path.Combine(Data.Path, OcsConstants.EnabledModFile);
    }

    /// <inheritdoc/>
    public IModFolder? Content { get; }

    /// <inheritdoc/>
    public IModFolder Data { get; }

    /// <inheritdoc/>
    public string EnabledModsFile { get; }

    /// <inheritdoc/>
    public string Identifier { get; }

    /// <inheritdoc/>
    public IModFolder Mods { get; }

    /// <inheritdoc/>
    public string Path { get; }

    /// <inheritdoc/>
    public ISaveFolder Saves { get; }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public virtual async Task<string[]> ReadEnabledModsAsync(CancellationToken cancellationToken = default)
        => await File.ReadAllLinesAsync(EnabledModsFile, cancellationToken).ConfigureAwait(false);

    /// <inheritdoc/>
    public override string ToString() => $"{Identifier} ({Path})";

    /// <inheritdoc/>
    public bool TryFind(string modName, [MaybeNullWhen(false)] out IModFile file) => Data.TryFind(modName, out file) || Mods.TryFind(modName, out file) || (Content?.TryFind(modName, out file) ?? false);

    /// <inheritdoc/>
    public virtual async Task WriteEnabledModsAsync(IEnumerable<string> enabledMods, CancellationToken cancellationToken = default)
            => await File.WriteAllLinesAsync(EnabledModsFile, enabledMods, cancellationToken).ConfigureAwait(false);
}
