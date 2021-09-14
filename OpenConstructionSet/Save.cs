using System;
using System.IO;

namespace OpenConstructionSet
{
    /// <summary>
    /// Represents a single save directory structure.
    /// </summary>
    public class Save
    {
        /// <summary>
        /// Root folder of the save.
        /// </summary>
        public string FolderPath { get; }

        /// <summary>
        /// Name of the save.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Path of the save file.
        /// </summary>
        public string SaveFile { get; }

        /// <summary>
        /// Path to the portraits text.
        /// </summary>
        public string PortraitsTexture { get; }

        /// <summary>
        /// Path of the Zone folder.
        /// </summary>
        public string ZoneFolder { get; }

        /// <summary>
        /// A collection containing the save's zone files' paths.
        /// </summary>
        public string[] ZoneFiles { get; private set; }

        /// <summary>
        /// Path of the PlatoonFolder
        /// </summary>
        public string PlatoonFolder { get; }

        /// <summary>
        /// A collection containing the save's platton files' paths.
        /// </summary>
        public string[] PlatoonFiles { get; private set; }

        /// <summary>
        /// Initialise a save file for the given path and name.
        /// </summary>
        /// <param name="basePath">The actual save folder.</param>
        /// <param name="name">The name of the save.</param>
        /// <param name="populate">if <c>true</c> file properties will be populated from disk.</param>
        public Save(string basePath, string name, bool populate = true)
        {
            Name = name;

            FolderPath = Path.Combine(basePath, name);

            SaveFile = Path.Combine(FolderPath, "quick.save");
            PortraitsTexture = Path.Combine(FolderPath, "portraits_texture.png");

            ZoneFolder = Path.Combine(FolderPath, "zone");

            PlatoonFolder = Path.Combine(FolderPath, "platoon");

            if (populate)
            {
                Populate();
            }
        }

        /// <summary>
        /// Populates the <see cref="PlatoonFiles"/> and <see cref="ZoneFiles"/> properties from disk.
        /// </summary>
        public void Populate()
        {
            ZoneFiles = Directory.Exists(ZoneFolder) ? Directory.GetFiles(ZoneFolder, "*.zone") : Array.Empty<string>();

            PlatoonFiles = Directory.Exists(PlatoonFolder) ? Directory.GetFiles(PlatoonFolder, "*.platoon") : Array.Empty<string>();
        }
    }
}
