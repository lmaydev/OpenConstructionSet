namespace OpenConstructionSet.Installations
{
    /// <summary>
    /// Represents the various types of mod folder.
    /// </summary>
    public enum ModFolderType
    {
        /// <summary>
        /// Currently used for the Steam Workshop folder.
        /// Files are stored in a sub folder based on the Id of their .info file.
        /// e.g. [folder]/120595/example.mod
        /// </summary>
        Content,

        /// <summary>
        /// The data folder of a game installation.
        /// Contains the base game files.
        /// Files are stored in the root
        /// e.g [folder]/example.mod
        /// </summary>
        Data,

        /// <summary>
        /// The mods folder of a game installation.
        /// Files are stored in a sub folder based on their name.
        /// e.g. [folder]/example/example.mod
        /// </summary>
        Mod,
    }
}