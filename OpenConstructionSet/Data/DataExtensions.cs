using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Data;

public static class DataExtensions
{
    public static bool IsModType(this DataFileType fileType) => fileType is (DataFileType.Mod or DataFileType.MergeMod);

    public static bool HasMergeData(this DataFileType fileType) => (int)fileType >= (int)DataFileType.MergeMod;
}
