
namespace OpenConstructionSet;

/// <summary>
/// The main service for the OpenConstructionSet.
/// Provides discovery and some saving/loading functions.
/// </summary>
public interface IOcsService
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

    /// <summary>
    /// Attempts to read the header of the provided file.
    /// </summary>
    /// <param name="path">The path of the mod file.</param>
    /// <returns>The file's header if able to read; otherwise, null.</returns>
    Header? ReadHeader(string path);

    /// <summary>
    /// Attempts to read the load order file. This file is contained in the game's data folder.
    /// </summary>
    /// <param name="folder">Data folder to find the file in.</param>
    /// <returns>The collection of mod names from the load order. If the file cannot be found an empty array is returned.</returns>
    string[] ReadLoadOrder(string folder);

    /// <summary>
    /// Save a collection of mod names to the load order file. This file is contained in the game's data folder.
    /// </summary>
    /// <param name="folder">Data folder to find the file in.</param>
    /// <param name="loadOrder">List of mod names.</param>
    /// <returns></returns>
    void SaveLoadOrder(string folder, IEnumerable<string> loadOrder);
}