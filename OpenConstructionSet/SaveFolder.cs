using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet
{
    public class SaveFolder
    {
        public string FolderPath { get; }

        public Save[] Saves { get; private set; }

        public SaveFolder(string path, bool loadSaves = true)
        {
            FolderPath = path;

            if (loadSaves)
            {
                LoadSaves();
            }
        }

        public void LoadSaves()
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
