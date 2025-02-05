using NUnit.Framework;
using OpenConstructionSet.IO;
using System.IO;
using System.Linq;

namespace OpenConstructionSet.Tests.IO;

public class ReadWriteTests
{
    [Test]
    [TestCase(["Content/Mods/changes.mod"])]
    [TestCase(["Content/Mods/delete-building.mod"])]
    [TestCase(["Content/Mods/instance-changes.mod"])]
    [TestCase(["Content/Mods/merge.mod"])]
    [TestCase(["Content/Mods/new-building.mod"])]
    [TestCase(["Content/Mods/ref-changes.mod"])]
    public void ReadWrite(string file)
    {
        var inputData = File.ReadAllBytes(file);

        using var reader = new OcsReader(inputData);

        var data = reader.ReadDataFile();

        var outputStream = new MemoryStream(inputData.Length);

        using var writer = new OcsWriter(outputStream);

        writer.Write(data);

        var outputData = outputStream.ToArray();

        for (int i = 0; i < outputData.Length; i++)
        {
            if (i >= inputData.Length)
            {
                Assert.Fail("Output too long");
            }
            else if (inputData[i] != outputData[i])
            {
                Assert.Fail("Byte {i} doesn't match");
            }
        }

        Assert.True(inputData.SequenceEqual(outputData));
    }
}
