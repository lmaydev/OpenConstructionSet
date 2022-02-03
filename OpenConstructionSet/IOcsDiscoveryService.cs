using OpenConstructionSet.Installations;

namespace OpenConstructionSet
{
    public interface IOcsDiscoveryService
    {
        string[] SupportedLocators { get; }

        IAsyncEnumerable<IInstallation> DiscoverAllInstallationsAsync();
        Task<IInstallation?> DiscoverInstallationAsync();
        Task<IInstallation?> DiscoverInstallationAsync(string locatorId);
    }
}