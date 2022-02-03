namespace OpenConstructionSet.Data;

/// <summary>
/// Change types for <see cref="Item"/>s.
/// </summary>
public enum ItemChangeType : int
{
    /// <summary>
    /// Changed by the active mod.
    /// </summary>
    Changed = -2147483647,

    /// <summary>
    /// Added by the active mod.
    /// </summary>
    New = -2147483646,

    /// <summary>
    /// Name was changed by the active mod.
    /// </summary>
    Renamed = -2147483645,
}
