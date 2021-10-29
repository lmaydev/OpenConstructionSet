namespace OpenConstructionSet;

/// <summary>
/// Used to build <see cref="OcsDataContext"/> instances.
/// </summary>
public interface IOcsDataContextBuilder
{
    /// <summary>
    /// Build a <c>OcsDataContext</c> from the provided information.
    /// </summary>
    /// <param name="name">The name of the new mod. e.g. example.mod</param>
    /// <param name="throwIfMissing">If <c>true</c> missing mods will cause exceptions to be thrown.</param>
    /// <param name="installation">Game installation to use. If null an attempt will be made to discover one.</param>
    /// <param name="baseMods">A collection of mod names or paths to be loaded as base data.</param>
    /// <param name="activeMods">A collection of mod names or paths to loaded as active data.</param>
    /// <param name="header">The header to use for the mod.</param>
    /// <param name="info">The info to use for this mod.</param>
    /// <param name="loadGameFiles">If not <c>ModLoadType</c>.None will load the game's base data files as specified.</param>
    /// <param name="loadEnabledMods">If not <c>ModLoadType</c>.None will load the game's enabled mod files as specified.</param>
    /// <returns>A <see cref="OcsDataContext"/></returns>
    OcsDataContext Build(string name,
                         bool throwIfMissing = true,
                         Installation? installation = null,
                         IEnumerable<string>? baseMods = null,
                         IEnumerable<string>? activeMods = null,
                         Header? header = null,
                         ModInfo? info = null,
                         ModLoadType loadGameFiles = ModLoadType.None,
                         ModLoadType loadEnabledMods = ModLoadType.None);
}