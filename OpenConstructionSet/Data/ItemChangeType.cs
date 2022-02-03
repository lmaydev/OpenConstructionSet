namespace OpenConstructionSet.Data;

/// <summary>
/// Change types for items.
/// </summary>
public enum ItemChangeType : int
{
    /// <summary>
    /// The item was changed by the active mod.
    /// </summary>
    Changed = -2147483647,

    /// <summary>
    /// Added by the active mod.
    /// </summary>
    New = -2147483646,

    /// <summary>
    /// The item's name was changed by the active mod.
    /// </summary>
    Renamed = -2147483645,
}