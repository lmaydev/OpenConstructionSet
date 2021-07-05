using forgotten_construction_set;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet
{
    /// <summary>
    /// Collection of methods to help when working with <c>GameData</c> objects.
    /// </summary>
    public static class GameDataExtensions
    {
        /// <summary>
        /// Saves the active mod from the supplied <c>GameData</c> to the folder provided.
        /// </summary>
        /// <param name="gameData"><c>GameData</c> object with an active mod.</param>
        /// <param name="folder">Folder to save the mod in.</param>
        public static void Save(this GameData gameData, GameFolder folder)
        {
            if (gameData.activeFileName == null)
            {
                throw new Exception("No active mod");
            }

            gameData.save(folder.GetFullPath(gameData.activeFileName));
        }
    }
}
