
namespace OpenConstructionSet;

/// <summary>
/// Provides discovery methods for the games various directory structures and files.
/// </summary>
public interface IOcsDiscoveryService
{
    /// <summary>
    /// The supported locator IDs.
    /// </summary>
    string[] SupportedFolderLocators { get; }

    /// <summary>
    /// Discover the provided file reading it's header and info.
    /// </summary>
    /// <param name="file">The mod file to discover.</param>
    /// <returns>A <c>ModFile</c> representing the file.</returns>
    ModFile? DiscoverMod(string file);

    /// <summary>
    /// Discover the provided folder and it's contained mods.
    /// </summary>
    /// <param name="folder">The mod folder to discover.</param>
    /// <returns>A <c>ModFolder</c> representing the folder.</returns>
    ModFolder? DiscoverModFolder(string folder);

    /// <summary>
    /// Search using all installation locators and return any positive results.
    /// </summary>
    /// <returns>A dictionary of locatorID to Installation information.</returns>
    Dictionary<string, Installation> FindAllInstallations();

    /// <summary>
    /// Search using all installation locators and return the first positive results.
    /// </summary>
    /// <returns>Details of the installation if found; otherwise, <c>null</c></returns>
    Installation? FindInstallation();

    /// <summary>
    /// Use the provided locator to find the installation details.
    /// </summary>
    /// <param name="locatorId">The ID of the locator to use.</param>
    /// <returns>Details of the installation if found; otherwise, <c>null</c></returns>
    Installation? FindInstallation(string locatorId);
}