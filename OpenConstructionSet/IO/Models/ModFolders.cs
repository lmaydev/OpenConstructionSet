using System.Collections.Generic;

namespace OpenConstructionSet.IO
{
    /// <summary>
    /// POCO for the game's folders.
    /// </summary>
    public class ModFolders
    {
        /// <summary>
        /// The game's data folder.
        /// </summary>
        public ModFolder? Data { get; set; }

        /// <summary>
        /// The game's mod folder.
        /// </summary>
        public ModFolder? Mod { get; set; }

        /// <summary>
        /// Helper function to get the folders as an array.
        /// </summary>
        /// <returns>The folders in an arrray.</returns>
        public ModFolder[] ToArray()
        {
            var list = new List<ModFolder>();

            if (Data is not null)
            {
                list.Add(Data);
            }

            if (Mod is not null)
            {
                list.Add(Mod);
            }

            return list.ToArray();
        }
    }
}