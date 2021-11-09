namespace OpenConstructionSet.Data;

/// <summary>
/// Contains the required options to build a collection of game data for reference.
/// </summary>
/// <param name="ThrowIfMissing">If <c>true</c> missing mod files will generate exceptions. Otherwise they will be ignored.</param>
/// <param name="Installation">An <c>Installation</c> object to use when searching for a mods full path. If <c>null</c> discovery will be attempted.</param>
/// <param name="Mods">A collection of mod names, file names or paths to load.</param>
/// <param name="LoadGameFiles">If <c>true</c> the game's files will be loaded.</param>
/// <param name="LoadEnabledMods">If <c>true</c> the game's enabled mods will be loaded in order.</param>
public record OcsDataOptions(bool ThrowIfMissing = true,
                                      Installation? Installation = null,
                                      IEnumerable<string>? Mods = null,
                                      bool LoadGameFiles = false,
                                      bool LoadEnabledMods = false);