namespace OpenConstructionSet.Data;

/// <summary>
/// 
/// </summary>
/// <param name="Name">(Required) The name of the active mod. If it doesn't exist a new empty mod will be created.</param>
/// <param name="ThrowIfMissing">If <c>true</c> missing mod files will generate exceptions. Otherwise they will be ignored.</param>
/// <param name="Installation">An <c>Installation</c> object to use when searching for a mods full path and later by the <c>OcsDataContext</c>. If an <c>null</c> discovery will be attempted.</param>
/// <param name="BaseMods">A collection of mod names, file names or paths to load as base data. The base data will be loaded before applying the active mods on top.</param>
/// <param name="ActiveMods">A collection of mod names, file names or paths to load as active. These mods will be applied on top of the base data and will form part of the changes saved to the new mod.</param>
/// <param name="Header">Contains the meta data shown in the launcher (i.e. author, version, dependencies, etc)</param>
/// <param name="Info">Contains additional information about the mod. This takes the form of the .info file that is used for Steam Workshop et al.</param>
/// <param name="LoadGameFiles">If set to `ModLoadType.Active` or `ModLoadType.Base` the game's data files will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.</param>
/// <param name="LoadEnabledMods">If set to `ModLoadType.Active` or `ModLoadType.Base` the game's enabled mods will be loaded into the context as specified. Passing `ModLoadType.None` will cause them not to be loaded.</param>
public record OcsDataContexOptions(string Name,
                                   bool ThrowIfMissing = true,
                                   Installation? Installation = null,
                                   IEnumerable<string>? BaseMods = null,
                                   IEnumerable<string>? ActiveMods = null,
                                   Header? Header = null,
                                   ModInfo? Info = null,
                                   ModLoadType LoadGameFiles = ModLoadType.None,
                                   ModLoadType LoadEnabledMods = ModLoadType.None);
