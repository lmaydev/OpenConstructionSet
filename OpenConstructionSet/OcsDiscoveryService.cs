using OpenConstructionSet.Installations;
using OpenConstructionSet.Installations.Locators;

namespace OpenConstructionSet;

/// <summary>
/// The main service for the OpenConstructionSet.
/// Provides discovery and some saving/loading functions.
/// </summary>
public class OcsDiscoveryService : IOcsDiscoveryService
{
    private readonly Dictionary<string, IInstallationLocator> locators;

    /// <summary>
    /// Creates a new <c>OcsService</c> instance.
    /// </summary>
    /// <param name="locators">Collection of locators used to find installations.</param>
    public OcsDiscoveryService(IEnumerable<IInstallationLocator> locators)
    {
        this.locators = locators.ToDictionary(l => l.Id, l => l, StringComparer.OrdinalIgnoreCase);
        SupportedLocators = locators.Select(l => l.Id).ToArray();
    }

    /// <summary>
    /// The supported locator IDs.
    /// </summary>
    public string[] SupportedLocators { get; }

    /// <summary>
    /// Search using all installation locators and return any positive results.
    /// </summary>
    /// <returns>A dictionary of locatorID to Installation information.</returns>
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

    /// <summary>
    /// Use the provided locator to find the installation details.
    /// </summary>
    /// <param name="locatorId">The ID of the locator to use.</param>
    /// <returns>Details of the installation if found; otherwise, <c>null</c></returns>
    public async Task<IInstallation?> DiscoverInstallationAsync(string locatorId)
    {
        if (!locators.TryGetValue(locatorId, out var locator))
        {
            throw new Exception($"Locator {locatorId} not found");
        }

        return await locator.LocateAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Search using all installation locators and return the first positive results.
    /// </summary>
    /// <returns>Details of the installation if found; otherwise, <c>null</c></returns>
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
