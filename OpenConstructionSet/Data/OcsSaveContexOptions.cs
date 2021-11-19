namespace OpenConstructionSet.Data;

/// <summary>
/// Contains the required options to build an <see cref="OcsDataContext"/>.
/// </summary>
/// <param name="Name">(Required) The name of the save.</param>
/// <param name="ThrowIfMissing">If <c>true</c> missing mod files will generate exceptions. Otherwise they will be ignored.</param>
/// <param name="Installation">An <c>Installation</c> object to use when searching for a mods full path and later by the <c>OcsDataContext</c>. If no installation object or name is provided discovery will be attempted.</param>
/// <param name="InstallationName">The name of the installation to use when searching for a mods full path. If no installation object or name is provided discovery will be attempted.</param>
/// <param name="Mods">A collection of mod names, file names or paths to load as base data. The base data will be loaded before applying the active mods on top.</param>
/// <param name="Header">Contains the meta data shown in the launcher (i.e. author, version, dependencies, etc)</param>
/// <param name="Info">Contains additional information about the mod. This takes the form of the .info file that is used for Steam Workshop et al.</param>
/// <param name="LoadGameFiles">If set to `ModLoadType.Active` or `ModLoadType.Base` the game's data files will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.</param>
/// <param name="LoadEnabledMods">If set to `ModLoadType.Active` or `ModLoadType.Base` the game's enabled mods will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.</param>
public record OcsSaveContexOptions(string Name,
                                   bool ThrowIfMissing = true,
                                   Installation? Installation = null,
                                   string? InstallationName = null,
                                   IEnumerable<string>? Mods = null,
                                   Header? Header = null,
                                   ModInfo? Info = null,
                                   bool LoadGameFiles = false,
                                   bool LoadEnabledMods = false);