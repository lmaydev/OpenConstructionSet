using OpenConstructionSet.Installations;
using OpenConstructionSet.Installations.Locators;

namespace OpenConstructionSet
{
    /// <summary>
    /// Service used to locate <see cref="IInstallation"/>s.
    /// </summary>
    public interface IInstallationService
    {
        /// <summary>
        /// Id of all supported <see cref="IInstallationLocator"/>s.
        /// </summary>
        string[] SupportedLocators { get; }

        /// <summary>
        /// Runs all supported <see cref="IInstallationLocator"/>s and returns any that are found.
        /// </summary>
        /// <returns>A collection of any <see cref="IInstallation"/>s that were found.</returns>
        IAsyncEnumerable<IInstallation> DiscoverAllInstallationsAsync();

        /// <summary>
        /// Runs all supported <see cref="IInstallationLocator"/>s and returns the first <see cref="IInstallation"/> that is found.
        /// </summary>
        /// <returns>The first <see cref="IInstallation"/> that was found; otherwise, <c>null</c></returns>
        Task<IInstallation?> DiscoverInstallationAsync();

        /// <summary>
        /// Runs the <see cref="IInstallationLocator"/> with a matching Id and returns the result.
        /// </summary>
        /// <returns>The <see cref="IInstallation"/> if found; otherwise, <c>null</c></returns>
        Task<IInstallation?> DiscoverInstallationAsync(string locatorId);
    }
}
