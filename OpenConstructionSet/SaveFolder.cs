using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet
{
    /// <summary>
    /// Represents the game's save folder.
    /// Can be automatically populated from disk.
    /// </summary>
    public class SaveFolder
    {
        /// <summary>
        /// The path....
        /// </summary>
        public string FolderPath { get; }

        /// <summary>
        /// A collection of <see cref="Save"/>s.
        /// Can be populated be calling <see cref="Populate"/>.
        /// </summary>
        public Save[] Saves { get; private set; }

        /// <summary>
        /// Create and initialize from a folder path.
        /// </summary>
        /// <param name="path">The folder.</param>
        /// <param name="populate">if <c>true</c> the folder structure will be loaded from disk.</param>
        public SaveFolder(string path, bool populate = true)
        {
            FolderPath = path;

            if (populate)
            {
                Populate();
            }
        }

        /// <summary>
        /// Populate the <see cref="Saves"/> property from disk.
        /// </summary>
        public void Populate()
        {
            var info = new DirectoryInfo(FolderPath);

            if (!info.Exists)
            {
                return;
            }

            Saves = info.GetDirectories().Select(d => d.Name).Select(n => new Save(FolderPath, n)).ToArray();
        }
    }
}
