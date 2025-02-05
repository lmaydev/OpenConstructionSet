namespace OpenConstructionSet.Data;

/// <summary>
/// Change types for <see cref="Item"/> s.
/// </summary>
public enum ItemChangeType : int
{
    /// <summary>
    /// Added by the active mod.
    /// </summary>
    New = 0,

    /// <summary>
    /// Changed by the active mod.
    /// </summary>
    Changed = 1,

    /// <summary>
    /// Name changed by the active mod.
    /// </summary>
    Renamed = 2,
}
