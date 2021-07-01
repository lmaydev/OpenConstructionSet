namespace OpenConstructionSet
{
    /// <summary>
    /// POCO for the game's folders.
    /// </summary>
    public class GameFolders
    {
        /// <summary>
        /// The game's data folder.
        /// </summary>
        public GameFolder Data { get; set; }

        /// <summary>
        /// The game's mod folder
        /// </summary>
        public GameFolder Mod { get; set; }

        /// <summary>
        /// New save location in local app data
        /// </summary>
        public SaveFolder SaveFolder { get; set; }

        /// <summary>
        /// Old save location in game folder
        /// </summary>
        public SaveFolder OldSaveFolder { get; set; }

        /// <summary>
        /// Helper function to get the folders as an array.
        /// </summary>
        /// <returns>The folders in an arrray.</returns>
        public GameFolder[] ToArray() => new GameFolder[] { Data, Mod };
    }
}