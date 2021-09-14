using NUnit.Framework;
using OpenConstructionSet.IO;
using OpenConstructionSet.Models;

namespace OpenConstructionSet.Tests;
public class ModDataTests
{
    private readonly static string TestInfoPath = Path.Combine(Environment.CurrentDirectory, "Content\\test.info");

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Read()
    {
        var success = OcsModInfoFile.TryRead(TestInfoPath, out var info);

        Assert.IsTrue(success);
    }

    [Test]
    public void Write()
    {
        var info = new ModInfo
        {
            Id = 1489675661,
            Mod = "Thousand Hands Martial Village",
            Title = "Martial Village",
            Tags = new[] { "Buildings", "Characters", "Clothing/Armour", "Environment/Map", "Factions", "Gameplay", "Items/Weapons", "Races", "Research" },
            LastUpdate = DateTime.Parse("2019-06-10T02:46:48.1320735-03:00"),
            Visibility = 0
        };

        var tempFile = Path.GetTempFileName();

        var success = OcsModInfoFile.TryWrite(tempFile, info);

        Assert.IsTrue(success);
        Assert.AreEqual(File.ReadAllBytes(TestInfoPath), File.ReadAllBytes(TestInfoPath));
    }
}