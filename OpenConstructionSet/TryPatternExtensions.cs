using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet;

/// <summary>
/// Provides Try/Out patterns to existing interface methods.
/// </summary>
public static class TryPatternExtensions
{
    /// <summary>
    /// Attempts to read the enabled mods and load order from file in the given directory. This should the be the game's data folder.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="folder">Data folder to find the file in.</param>
    /// <param name="enabledMods">If successful will contain the collection of mod names from the load order.</param>
    /// <returns><c>true</c> if the load order can be read.</returns>
    public static bool TryReadEnabledMods(this IOcsIOService service, string folder, [MaybeNullWhen(false)] out List<string> enabledMods)
    {
        try
        {
            enabledMods = service.ReadEnabledMods(folder);

            return enabledMods is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        enabledMods = null;
        return false;
    }

    /// <summary>
    /// Attempts to read the header of the provided file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="path">The path of the mod file.</param>
    /// <param name="header">Will contain the read header if successful.</param>
    /// <returns><c>true</c> if header can be read.</returns>
    public static bool TryReadHeader(this IOcsIOService service, string path, [MaybeNullWhen(false)] out Header header)
    {
        try
        {
            header = service.ReadHeader(path);

            return header is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        header = null;
        return false;
    }

    /// <summary>
    /// Attempts to read the specified data file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="path">The path of the data file.</param>
    /// <param name="data">Will contain a <c>DataFile</c> read from the file if successful.</param>
    /// <returns><c>true</c> if the data file can be read.</returns>
    public static bool TryReadDataFile(this IOcsIOService service, string path, [MaybeNullWhen(false)] out DataFile data)
    {
        try
        {
            data = service.ReadDataFile(path);

            return data is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        data = null;
        return false;
    }

    /// <summary>
    /// Attempts to read the specified mod info file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="path">The path of the mod info file.</param>
    /// <param name="info">Will contain a <c>ModInfo</c> if successful.</param>
    /// <returns><c>true</c> if the mod info file can be read.</returns>
    public static bool TryReadInfo(this IOcsIOService service, string path, [MaybeNullWhen(false)] out ModInfo info)
    {
        try
        {
            info = service.ReadInfo(path);

            return info is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        info = null;
        return false;
    }

    /// <summary>
    /// Search using all installation locators and return the first positive results.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="installation">Will contain the installation information if successful.</param>
    /// <returns><c>true</c> if an installation was found; otherwise, <c>false</c>.</returns>
    public static bool TryDiscoverInstallation(this IOcsDiscoveryService service, [MaybeNullWhen(false)] out Installation installation)
    {
        installation = service.DiscoverInstallation();

        return installation is not null;
    }
}
