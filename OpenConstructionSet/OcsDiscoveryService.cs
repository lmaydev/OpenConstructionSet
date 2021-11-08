using OpenConstructionSet.IO.Discovery;

namespace OpenConstructionSet;

/// <summary>
/// The main service for the OpenConstructionSet.
/// Provides discovery and some saving/loading functions.
/// </summary>
public class OcsDiscoveryService : IOcsDiscoveryService
{
    private static readonly Lazy<OcsDiscoveryService> _default = new(() => new(OcsIOService.Default, new IInstallationLocator[]
    {
        SteamFolderLocator.Default,
        GogFolderLocator.Default,
        LocalFolderLocator.Default
    }));

    /// <summary>
    /// Lazy initiated singleton for when DI is not being used
    /// </summary>
    public static OcsDiscoveryService Default => _default.Value;

    private readonly Dictionary<string, IInstallationLocator> locators;
    private readonly IOcsIOService ioService;

    /// <summary>
    /// The supported locator IDs.
    /// </summary>
    public string[] SupportedFolderLocators { get; }

    /// <summary>
    /// Creates a new <c>OcsService</c> instance.
    /// </summary>
    /// <param name="ioService">Used to read files.</param>
    /// <param name="locators">Collection of locators used to find installations.</param>
    public OcsDiscoveryService(IOcsIOService ioService, IEnumerable<IInstallationLocator> locators)
    {
        this.locators = locators.ToDictionary(l => l.Id, l => l, StringComparer.OrdinalIgnoreCase);
        SupportedFolderLocators = locators.Select(l => l.Id).ToArray();
        this.ioService = ioService;
    }

    /// <summary>
    /// Search using all installation locators and return any positive results.
    /// </summary>
    /// <returns>A dictionary of locatorID to Installation information.</returns>
    public Dictionary<string, Installation> DiscoverAllInstallations()
    {
        var result = new Dictionary<string, Installation>();

        foreach (var locator in SupportedFolderLocators)
        {
            var folders = DiscoverInstallation(locator);

            if (folders is not null)
            {
                result.Add(locator, folders);
            }
        }

        return result;
    }

    /// <summary>
    /// Use the provided locator to find the installation details.
    /// </summary>
    /// <param name="locatorId">The ID of the locator to use.</param>
    /// <returns>Details of the installation if found; otherwise, <c>null</c></returns>
    public Installation? DiscoverInstallation(string locatorId)
    {
        if (!locators.TryGetValue(locatorId, out var locator))
        {
            throw new Exception($"Locator {locatorId} not found");
        }

        if (!locator.TryFind(out var discovered))
        {
            return null;
        }

        var data = DiscoverModFolder(discovered.Data);
        var mod = DiscoverModFolder(discovered.Mod);

        if (data is null || mod is null)
        {
            return null;
        }

        var content = discovered.Content is not null ? DiscoverModFolder(discovered.Content) : null;

        var save = Directory.Exists(discovered.Save) ? DiscoverSaveFolder(discovered.Save) : null;

        var enabledMods = ioService.ReadEnabledMods(Path.Combine(data.FullName, OcsConstants.EnabledModFile))?.ToList() ?? new();

        return new(discovered.Installation, enabledMods, data, mod, content, save);
    }

    /// <summary>
    /// Search using all installation locators and return the first positive results.
    /// </summary>
    /// <returns>Details of the installation if found; otherwise, <c>null</c></returns>
    public Installation? DiscoverInstallation() => SupportedFolderLocators.Select(DiscoverInstallation).FirstOrDefault(f => f is not null);

    /// <summary>
    /// Discover the provided folder and it's contained mods.
    /// </summary>
    /// <param name="folder">The mod folder to discover.</param>
    /// <returns>A <c>ModFolder</c> representing the folder.</returns>
    public ModFolder? DiscoverModFolder(string folder)
    {
        if (!Directory.Exists(folder))
        {
            return null;
        }

        var result = new ModFolder(folder, new(StringComparer.OrdinalIgnoreCase));

        AddRange(Directory.GetFiles(folder, "*.base").Select(DiscoverMod));
        AddRange(Directory.GetFiles(folder, "*.mod").Select(DiscoverMod));
        // all mod files in a sub folder
        AddRange(Directory.GetDirectories(folder).SelectMany(f => Directory.GetFiles(f, "*.mod")).Select(DiscoverMod));

        void AddRange(IEnumerable<ModFile?> mods)
        {
            foreach (var mod in mods)
            {
                if (mod is null)
                {
                    continue;
                }

                result.Mods.Add(mod.FileName, mod);
            }
        }

        return result;
    }

    /// <summary>
    /// Discovery the provided mod file reading it's header and info.
    /// </summary>
    /// <param name="file">The mod file to discover.</param>
    /// <returns>A <c>ModFile</c> representing the file.</returns>
    public ModFile? DiscoverMod(string file)
    {
        file = Path.GetFullPath(file);

        if (!File.Exists(file))
        {
            return null;
        }

        if (!ioService.TryReadHeader(file, out var header))
        {
            return null;
        }

        var infoPath = OcsPathHelper.GetInfoPath(file);

        ModInfo? info = null;

        if (File.Exists(infoPath))
        {
            try
            {
                info = ioService.ReadInfo(infoPath);
            }
            catch (Exception)
            {
                // TODO log exception

                info = null;
            }
        }

        return new(file, header, info);
    }

    /// <summary>
    /// Discover the files in the given individual save folder
    /// </summary>
    /// <param name="folder"></param>
    /// <returns></returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Public API")]
    public Save? DiscoverSave(string folder)
    {
        folder = Path.GetFullPath(folder);

        if (!Directory.Exists(folder))
        {
            return null;
        }

        var result = new Save(folder);

        if (Directory.Exists(result.ZoneFolder))
        {
            result.ZoneFiles.AddRange(Directory.GetFiles(result.ZoneFolder, "*.zone"));
        }

        if (Directory.Exists(result.PlatoonFolder))
        {
            result.PlatoonFiles.AddRange(Directory.GetFiles(result.PlatoonFolder, "*.platoon"));
        }

        return result;
    }

    /// <summary>
    /// Discover the provided save folder and contained saves.
    /// </summary>
    /// <param name="folder"></param>
    /// <returns></returns>
    public SaveFolder? DiscoverSaveFolder(string folder)
    {
        folder = Path.GetFullPath(folder);

        if (!Directory.Exists(folder))
        {
            return null;
        }

        var result = new SaveFolder(folder);

        foreach (var save in Directory.GetDirectories(folder).Select(DiscoverSave))
        {
            if (save is null)
            {
                continue;
            }

            result.Saves.Add(save);
        }

        return result;
    }

    /// <summary>
    /// Attempts to read the header of the provided file.
    /// </summary>
    /// <param name="path">The path of the mod file.</param>
    /// <returns>The file's header if able to read; otherwise, null.</returns>
    public Header? ReadHeader(string path) => ioService.ReadHeader(path.AddModExtension());
}
