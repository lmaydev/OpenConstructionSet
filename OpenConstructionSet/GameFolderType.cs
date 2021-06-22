namespace OpenConstructionSet
{
    /// <summary>
    /// Represents the type of a game folder.
    /// </summary>
    public enum GameFolderType
    {
        /// <summary>
        /// Data folders store the files in their root.
        /// e.g. [folder]/example.mod
        /// </summary>
        Data,
        /// <summary>
        /// Mod folders store the files in a sub directory of their name
        /// e.g. [folder]/example/example.mod
        /// </summary>
        Mod,
    }
}