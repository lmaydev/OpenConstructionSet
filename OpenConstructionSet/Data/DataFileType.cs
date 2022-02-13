namespace OpenConstructionSet.Data;

/// <summary>
/// Type identifier for data files.
/// </summary>
public enum DataFileType : int
{
    /// <summary>
    /// A data file. Supports any data file that isn't a mod. .save, .platoon, .zone etc.
    /// </summary>
    Data = 15,

    /// <summary>
    /// A mod file.
    /// </summary>
    Mod = 16
}
