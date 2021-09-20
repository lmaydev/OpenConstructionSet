using OpenConstructionSet.Models;
using System;
using System.Collections.Generic;

namespace OpenConstructionSet.IO
{
    public class ModFile : IEquatable<ModFile?>
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

        public override bool Equals(object? obj)
        {
            return Equals(obj as ModFile);
        }

        public bool Equals(ModFile? other)
        {
            return other != null &&
                   FullName == other.FullName;
        }

        public override int GetHashCode()
        {
            return 733961487 + EqualityComparer<string>.Default.GetHashCode(FullName);
        }

        public static bool operator ==(ModFile? left, ModFile? right)
        {
            return EqualityComparer<ModFile?>.Default.Equals(left, right);
        }

        public static bool operator !=(ModFile? left, ModFile? right)
        {
            return !(left == right);
        }
    }
}
