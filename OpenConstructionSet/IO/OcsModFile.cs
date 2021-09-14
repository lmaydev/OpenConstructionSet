using OpenConstructionSet.Models;
using System;

namespace OpenConstructionSet.IO
{
    public static class OcsModFile
    {
        public static DataFile Read(OcsReader reader)
        {
            var type = (FileType)reader.ReadInt();

            if (type != FileType.Mod)
            {
                throw new InvalidOperationException($"Invalid file type. Expected 16; received {type}");
            }

            return new DataFile(type, reader.ReadHeader(), reader.ReadInt(), reader.ReadModData(), reader.ReadItems());
        }

        public static void Write(DataFile value, OcsWriter writer)
        {
            writer.Write((Int32)FileType.Mod);

            writer.Write(value.Header ?? new Header(1, "", ""));

            writer.Write(value.LastId);

            writer.Write(value.Items.Values);
        }

        public static Header ReadHeader(string path)
        {
            using var reader = new OcsReader(path);

            var type = (FileType)reader.ReadInt();

            if (type != FileType.Mod)
            {
                throw new InvalidOperationException("The specified file is not a mod");
            }

            return reader.ReadHeader();
        }
    }
}