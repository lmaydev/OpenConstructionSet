using System.Runtime.Versioning;
using OpenConstructionSet.Installations;
using OpenConstructionSet.Installations.Locators;

namespace OpenConstructionSet;

/// <inheritdoc/>
[SupportedOSPlatform("windows")]
public class InstallationService : IInstallationService
{
    private readonly Dictionary<string, IInstallationLocator> locators;

    /// <summary>
    /// Creates a new <see cref="InstallationService"/> using the default <see cref="IInstallationLocator"/>s.
    /// </summary>
    public InstallationService() : this(new IInstallationLocator[] { new SteamLocator(), new GogLocator(), new LocalLocator() })
    {
    }

    /// <summary>
    /// Creates a new <see cref="InstallationService"/> using the provided <see cref="IInstallationLocator"/>s.
    /// </summary>
    /// <param name="locators">Collection of <see cref="IInstallationLocator"/> used to find <see cref="IInstallation"/>s.</param>
    public InstallationService(IEnumerable<IInstallationLocator> locators)
    {
        this.locators = locators.ToDictionary(l => l.Id, l => l, StringComparer.OrdinalIgnoreCase);
        SupportedLocators = locators.Select(l => l.Id).ToArray();
    }

    /// <inheritdoc/>
    public string[] SupportedLocators { get; }

    /// <inheritdoc/>
    public async IAsyncEnumerable<IInstallation> DiscoverAllInstallationsAsync()
    {
        foreach (var locator in SupportedLocators)
        {
            var installation = await DiscoverInstallationAsync(locator).ConfigureAwait(false);

            if (installation is not null)
            {
                yield return installation;
            }
        }
    }

    /// <inheritdoc/>
    public async Task<IInstallation?> DiscoverInstallationAsync(string locatorId)
    {
        if (!locators.TryGetValue(locatorId, out var locator))
        {
            throw new Exception($"Locator {locatorId} not found");
        }

        return await locator.LocateAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IInstallation?> DiscoverInstallationAsync()
    {
        foreach (var locatorId in SupportedLocators)
        {
            var installation = await DiscoverInstallationAsync(locatorId).ConfigureAwait(false);

            if (installation is not null)
            {
                return installation;
            }
        }

        return null;
    }
}
