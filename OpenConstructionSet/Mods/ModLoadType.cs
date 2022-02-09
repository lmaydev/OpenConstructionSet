namespace OpenConstructionSet.Mods;

/// <summary>
/// Used to specify how a mod should be loaded.
/// </summary>
public enum ModLoadType
{
    /// <summary>
    /// Do not load. Default value.
    /// </summary>
    None,

    /// <summary>
    /// Load as base data.
    /// </summary>
    Base,

    /// <summary>
    /// Load as part of the active mod.
    /// </summary>
    Active
}
