using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenConstructionSet.IO
{
    public static class OcsIOExtensions
    {
        internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
    }
}
