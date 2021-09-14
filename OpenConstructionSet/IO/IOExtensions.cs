using System.IO;

namespace OpenConstructionSet.IO
{
    public static class IOExtensions
    {
        internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
    }
}
