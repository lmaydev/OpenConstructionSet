using OpenConstructionSet.Models;
using System.IO;

namespace OpenConstructionSet.IO
{
    public class ModFile
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public Header Header { get; set; }

        public ModInfo? Info { get; set; }

        public ModFile()
        {
            Name = FullName = string.Empty;

            Header = new Header();
        }

        public void Delete()
        {
            var directory = new DirectoryInfo(FullName);

            if (directory.GetFiles("*.mod").Length == 1)
            {
                // Individual mod folder so delete everything
                directory.Delete(true);
            }
            else
            {
                // Installation/data folder so only delete file
                File.Delete(FullName);
            }
        }

        public static ModFile Discover(FileInfo file) => new()
        {
            Name = file.Name,
            FullName = file.FullName,
            Header = OcsModFile.ReadHeader(file.FullName),
            Info = OcsModInfoFile.Read(file.FullName, true),
        };

        public static ModFile Discover(string file) => Discover(new FileInfo(file));
    }
}
