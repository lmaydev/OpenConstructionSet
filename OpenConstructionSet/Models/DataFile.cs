using System.Collections.Generic;

namespace OpenConstructionSet.Models
{
    /// <summary>
    /// Represents a game data file.
    /// </summary>
    public class DataFile
    {
        /// <summary>
        /// Identifies the file's type.
        /// </summary>
        public FileType Type { get; set; }
        /// <summary>
        /// Mod file header.
        /// </summary>
        public Header? Header { get; set; }
        /// <summary>
        /// The last ID used.
        /// </summary>
        public int LastId { get; set; }
        /// <summary>
        /// Collection of items within the mod.
        /// </summary>
        public Dictionary<string, Item> Items { get; }
        /// <summary>
        /// Contains the metadata from a mod's info file if it exists.
        /// </summary>
        public ModInfo? Info { get; set; }

        /// <summary>
        /// Create a new data file.
        /// </summary>
        /// <param name="type">The file's type identifier.</param>
        /// <param name="header">Optional header if the file is a mod.</param>
        /// <param name="lastId">The last ID used.</param>
        /// <param name="info">Metadata from a mod's info file.</param>
        /// <param name="items">Collection of items</param>
        public DataFile(FileType type, Header? header, int lastId, ModInfo? info = null, Dictionary<string, Item>? items = null)
        {
            Type = type;
            Header = header ?? new Header();
            LastId = lastId;
            Info = info;
            Items = items ?? new();
        }
    }
}