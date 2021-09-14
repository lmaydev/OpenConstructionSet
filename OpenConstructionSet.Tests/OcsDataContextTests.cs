using NUnit.Framework;
using OpenConstructionSet.Data;
using OpenConstructionSet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet.Tests
{
    public class OcsDataContextTests
    {
        [Test]
        public void Test()
        {
            var input = @"C:\Program Files (x86)\Steam\steamapps\common\Kenshi\mods\base\base.mod";
            var output = @"C:\Program Files (x86)\Steam\steamapps\common\Kenshi\mods\base\base2.mod";

            var context = new OcsDataContextBuilder("base2.mod")
                .WithHeader(OcsModFile.ReadHeader(input))
                .UsingFolders(@"C:\Program Files (x86)\Steam\steamapps\common\Kenshi\mods",
                              @"C:\Program Files (x86)\Steam\steamapps\common\Kenshi\data")
                .LoadGameFiles()
                .Build();

            // Acient Citadel
            context.Items["5316-TwoStorey.mod"].Values["door type"] = 1;

            // Acient Citadel Ruin
            context.Items["49546-Newwworld.mod"].Name += "1";

            context.Save(output);
        }
    }
}
