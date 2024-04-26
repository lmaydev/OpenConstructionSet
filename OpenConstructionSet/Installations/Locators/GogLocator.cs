using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using GameFinder.StoreHandlers.GOG;
using Microsoft.Win32;

namespace OpenConstructionSet.Installations.Locators;

/// <summary>
/// Gog implementation of a <see cref="IInstallationLocator"/>
/// </summary>
[SupportedOSPlatform("windows")]
public class GogLocator(GOGHandler handler) : IInstallationLocator
{
    readonly GOGGameId gameId = GOGGameId.From(1193046833);

    /// <inheritdoc/>
    public string Id { get; } = "Gog";

    /// <inheritdoc/>
    public bool TryLocate([MaybeNullWhen(false)] out IInstallation installation)
    {
        var path = handler.FindOneGameById(gameId, out var _)?.Path.GetFullPath();

        if (!Directory.Exists(path))
        {
            installation =  null;
            return false;
        }

        installation = new Installation(Id, path, null);
        return true;
    }
}
