namespace OpenConstructionSet.Models;

/// <summary>
/// Used to specifiy how a mod should be loaded into a <seealso cref="OcsDataContext"/>
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
