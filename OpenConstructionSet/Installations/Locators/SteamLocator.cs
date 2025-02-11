using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using GameFinder.StoreHandlers.Steam;
using GameFinder.StoreHandlers.Steam.Models.ValueTypes;
using Microsoft.Win32;

namespace OpenConstructionSet.Installations.Locators;

/// <summary>
/// Steam implementation of a <see cref="IInstallationLocator"/>
/// </summary>
[SupportedOSPlatform("windows")]
public class SteamLocator(SteamHandler handler, InstallationFactory installationFactory) : IInstallationLocator
{
    readonly AppId gameId = AppId.From(233860);

    /// <inheritdoc/>
    public string Id { get; } = "Steam";

    /// <inheritdoc/>
    public bool TryLocate([MaybeNullWhen(false)] out IInstallation installation)
    {
        {
            var game = handler.FindOneGameById(gameId, out var _);

            if (game is null)
            {
                installation = null;
                return false;
            }

            var content = game.ParseWorkshopManifest().ValueOrDefault?.GetContentDirectoryPath().GetFullPath();

            var path = game.Path.GetFullPath();

            if (!Directory.Exists(path) || !Directory.Exists(path))
            {
                installation = null;
                return false;
            }

            installation = installationFactory.Build(Id, path, content);
            return true;
        }
    }
}
