using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Mods;
using OpenConstructionSet.Saves;

namespace OpenConstructionSet.Installations;

/// <summary>
/// Representation of an installation of the game.
/// </summary>
public record class Installation(string Identifier, string RootPath, IModFolder Data, IModFolder Mods, IModFolder? Content, ISaveFolder Saves) : IInstallation
{
    /// <inheritdoc/>
    public string EnabledModsFile => Path.Combine(Data.Path, OcsConstants.EnabledModFile);

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
    public override string ToString() => $"{Identifier} ({RootPath})";

    /// <inheritdoc/>
    public bool TryFind(string modName, [MaybeNullWhen(false)] out IModFile file) => Data.TryFind(modName, out file) || Mods.TryFind(modName, out file) || (Content?.TryFind(modName, out file) ?? false);

    /// <inheritdoc/>
    public virtual async Task WriteEnabledModsAsync(IEnumerable<string> enabledMods, CancellationToken cancellationToken = default)
            => await File.WriteAllLinesAsync(EnabledModsFile, enabledMods, cancellationToken).ConfigureAwait(false);
}
