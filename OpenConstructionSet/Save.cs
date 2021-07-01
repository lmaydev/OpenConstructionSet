using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet
{
    public class Save
    {
        public string FolderPath { get; }

        public string Name { get; }

        public string SaveFile { get; }

        public string PortraitsTexture { get; }

        public string ZoneFolder { get; }

        public string[] ZoneFiles { get; private set; }

        public string PlatoonFolder { get; }

        public string[] PlatoonFiles { get; private set; }

        public Save(string basePath, string name)
        {
            Name = name;

            FolderPath = Path.Combine(basePath, name);

            SaveFile = Path.Combine(FolderPath, "quick.save");
            PortraitsTexture = Path.Combine(FolderPath, "portraits_texture.png");

            ZoneFolder = Path.Combine(FolderPath, "zone");

            PlatoonFolder = Path.Combine(FolderPath, "platoon");

            LoadFiles();
        }

        public void LoadFiles()
        {
            ZoneFiles = Directory.Exists(ZoneFolder) ? Directory.GetFiles(ZoneFolder, "*.zone") : Array.Empty<string>();

            PlatoonFiles = Directory.Exists(PlatoonFolder) ? Directory.GetFiles(PlatoonFolder, "*.platoon") : Array.Empty<string>();
        }
    }
}
