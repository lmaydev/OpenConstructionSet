namespace OpenConstructionSet.Data
{
    /// <summary>
    /// Type identifier for data files.
    /// </summary>
    public enum DataFileType : int
    {
        /// <summary>
        /// A save file. Supports .save, .platoon, .zone etc.
        /// </summary>
        Save = 15,

        /// <summary>
        /// A mod file.
        /// </summary>
        Mod = 16
    }
}
