using NUnit.Framework;
using OpenConstructionSet.Data;

namespace OpenConstructionSet.Tests.Data;

public class DataExtensionTests
{
    [Test]
    [TestCase(DataFileType.Mod, true)]
    [TestCase(DataFileType.MergeMod, true)]
    [TestCase(DataFileType.Data, false)]
    public void IsModType(DataFileType fileType, bool expected)
    {
        var actual = fileType.IsModType();

        Assert.AreEqual(expected, actual);
    }
}