using OpenConstructionSet.Data;
using OpenConstructionSet.Installations;
using OpenConstructionSet.Mods;
using OpenConstructionSet.Mods.Context;

const string ModName = "OCSP SCAR's pathfinding fix";
const string ModFileName = ModName + ".mod";
const string ReferenceModName = "SCAR's pathfinding fix.mod";

Console.WriteLine("OpenConstructionSet Patcher");
Console.WriteLine("SCAR's pathfinding fix https://www.nexusmods.com/kenshi/mods/602");
Console.WriteLine();

var installations = await new InstallationService().DiscoverAllInstallationsAsync().ToDictionaryAsync(i => i.Identifier);

if (installations.Count == 0)
{
    Console.WriteLine("Unable to find game");
    Console.ReadKey();
    return;
}

IInstallation installation;

if (installations.Count == 1)
{
    // One installation so use it
    installation = installations.Values.First();
}
else
{
    // Display the installations to the user
    var keys = installations.Keys.ToList();

    Console.WriteLine("Multiple installations found");

    for (var i = 0; i < keys.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {keys[i]}");
    }

    Console.Write("Please select which to use: ");

    // Get the user to chose
    var selection = keys[int.Parse(Console.ReadLine() ?? "1") - 1];

    installation = installations[selection];

    Console.WriteLine($"Using the {selection} installation");
}

Console.WriteLine();

Console.Write("Reading load order... ");

var baseMods = new List<string>(await installation.ReadEnabledModsAsync());

// Don't patch ourselves or SCAR's mod
baseMods.Remove(ModFileName);
baseMods.Remove(ReferenceModName);

if (baseMods.Count == 0)
{
    // No mods found to patch
    Console.WriteLine("failed!");
    Console.WriteLine("No mods found to patch");
    Console.ReadKey();
    return;
}

Console.WriteLine("done");
Console.WriteLine();

// Find SCAR's mod
var referenceMod = installation.Mods.GetMods().FirstOrDefault(m => m.Filename == ReferenceModName);

if (referenceMod is null)
{
    // Not found
    Console.WriteLine($"Unable to find {ReferenceModName}");
    Console.ReadKey();
    return;
}

Console.Write("Loading data... ");

ModFileData referenceData;

try
{
    referenceData = await referenceMod.ReadDataAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Unable to load {ReferenceModName}");
    Console.WriteLine($"Error: {ex}");
    Console.ReadKey();
    return;
}

// Extract core values from the Greenlander race item
var greenlander = referenceData.Items.Find(i => i.Name == "Greenlander");

if (greenlander is null)
{
    Console.WriteLine("Could not find Greenlander");
    Console.ReadKey();
    return;
}

var pathfindAcceleration = greenlander.Values["pathfind acceleration"];
var waterAvoidance = greenlander.Values["water avoidance"];

// Build mod
var header = new Header(referenceData.Header?.Version ?? 1,
                        "LMayDev",
                        "OpenConstructionSet Compatibility patch to apply core values from SCAR's pathfinding fix to custom races");
header.References.Add(ReferenceModName);
header.Dependencies.AddRange(baseMods);

var options = new ModContextOptions(ModFileName,
    installation: installation,
    baseMods: baseMods,
    header: header,
    loadGameFiles: ModLoadType.Base,
    throwIfMissing: false);

var context = await new ModContextBuilder().Build(options);

Console.WriteLine("done");
Console.WriteLine();

// Get all races where editor limits are set i.e. it is not an animal race
var races = context.Items.OfType(ItemType.Race).Where(race => race.Values.TryGetValue("editor limits", out var value)
                                                              && value is FileValue file
                                                              && !string.IsNullOrEmpty(file.Path));

foreach (var race in races)
{
    Console.WriteLine("Updating " + race.Name);
    race.Values["pathfind acceleration"] = pathfindAcceleration;

    // avoid changing for races that like water
    if ((float)race.Values["water avoidance"] > 0)
    {
        race.Values["water avoidance"] = waterAvoidance;
    }
}

Console.WriteLine();
Console.Write("Saving... ");

await context.SaveAsync();

Console.WriteLine("done");
Console.WriteLine();

var enabledMods = (await installation.ReadEnabledModsAsync().ConfigureAwait(false)).ToList();

// Remove this mod and then add to the end of the load order
enabledMods.RemoveAll(s => s == ModFileName);
enabledMods.Add(ModFileName);

await installation.WriteEnabledModsAsync(enabledMods).ConfigureAwait(false);

Console.WriteLine("Added patch to end of load order");

Console.Write("Press any key to exit...");
Console.ReadKey();