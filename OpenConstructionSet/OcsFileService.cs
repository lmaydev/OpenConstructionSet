using OpenConstructionSet.IO;
using OpenConstructionSet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace OpenConstructionSet
{
    public class OcsFileService : IOcsFileService
    {
        public void Write(OcsWriter writer, Header? header, int lastId, IEnumerable<Item> items)
        {
            writer.Write((int)FileType.Mod);

            writer.Write(header ?? new Header(1, "", ""));

            writer.Write(lastId);

            writer.Write(items);
        }

        public Header ReadHeader(OcsReader reader)
        {
            var type = (FileType)reader.ReadInt();

            if (type != FileType.Mod)
            {
                throw new InvalidOperationException("The specified file is not a mod");
            }

            return reader.ReadHeader();
        }

        public bool TryReadHeader(OcsReader reader, [MaybeNullWhen(false)] out Header header)
        {
            try
            {
                header = ReadHeader(reader);
                return true;
            }
            catch
            {
                header = null;
                return false;
            }
        }

        public bool Delete(ModFolder folder, string mod)
        {
            mod = mod.AddModExtension();

            if (!folder.Mods.TryGetValue(mod, out var file))
            {
                return false;
            }

            Delete(file);

            return true;
        }

        public void Delete(ModFile file)
        {
            var directory = Path.GetDirectoryName(file.FullName);

            // individual mod folder, burn it all
            if (directory == file.Info?.Id.ToString() || directory == Path.GetFileNameWithoutExtension(file.Name))
            {
                Directory.Delete(directory, true);
            }
            else
            {
                // Installation/data folder so only delete file
                File.Delete(file.FullName);
            }
        }

        /// <summary>
        /// Returns the full path of a mod from its' name.
        /// If the mod has been discovered it's path will be used.
        /// If not the path will be created using the folder and mod path.
        /// </summary>
        /// <param name="modName">The file name of the mod. e.g. example.mod</param>
        /// <returns>The full path of a mod file.</returns>
        public string GetPath(ModFolder folder, string modName)
        {
            modName = modName.AddModExtension();

            if (folder.Mods.ContainsKey(modName))
            {
                return folder.Mods[modName].FullName;
            }

            return GetPath(folder.FullName, modName);
        }

        private string GetPath(string folder, string modName) => Path.Combine(folder, Path.GetFileNameWithoutExtension(modName), modName.AddModExtension());
    }
}
