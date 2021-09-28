const string ModName = "OCS Patch SCAR's pathfinding fix";
const string ReferenceModName = "SCAR's pathfinding fix";

Console.WriteLine("OpenConstructionSet Patcher");
Console.WriteLine("SCAR's pathfinding fix https://www.nexusmods.com/kenshi/mods/602");
Console.WriteLine();

var installations = OcsService.Default.FindAllGameFolders();

if (installations.Count == 0)
{
    Console.WriteLine("Unable to find game folders");
    return;
}

GameFolders folders;

if (installations.Count == 1)
{
    folders = installations.Values.First();
}
else
{
    var keys = installations.Keys.ToList();

    Console.WriteLine("Multiple installations found");

    for (var i = 0; i < keys.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {keys[i]}");
    }

    Console.Write("Please select which to use: ");

    var installation = keys[int.Parse(Console.ReadLine() ?? "1") - 1];

    folders = installations[installation];

    Console.WriteLine($"Using the {installation} installation");
}

Console.WriteLine();

Console.Write("Reading load order... ");

var enabledMods = OcsService.Default.ReadLoadOrder(folders.Data).ToList();

if (!enabledMods.Any())
{
    Console.WriteLine("failed!");
    return;
}

Console.WriteLine("done");
Console.WriteLine();

var referenceMod = ModNameResolver.Default.Resolve(folders.ToArray(), ReferenceModName);

if (referenceMod is null)
{
    Console.WriteLine($"Unable to find {ReferenceModName}");
    return;
}

Console.WriteLine();
Console.Write("Loading data... ");

using var reader = new OcsReader(File.OpenRead(referenceMod.FullName));

(var referenceHeader, _, var items) = reader.ReadMod();

var greenLander = items["17-gamedata.quack"];

var pathfindAcceleration = greenLander.Values["pathfind acceleration"];
var waterAvoidance = greenLander.Values["water avoidance"];

var header = new Header(referenceHeader.Version, "LMayDev", "OpenConstructionSet Compatibility patch to apply core values from SCAR's pathfinding fix to custom races");

header.References.Add(ReferenceModName + ".mod");
header.Dependencies.AddRange(enabledMods);

var context = OcsDataContextBuilder.Default.Build(
    ModName,
    folders: folders.ToArray(),
    baseMods: enabledMods,
    header: header,
    loadGameFiles: ModLoadType.Base);

Console.WriteLine("done");
Console.WriteLine();

// Get all races where editor limits are not set
var races = context.Items.OfType(ItemType.Race).Where(i => !string.IsNullOrEmpty((i.Values["editor limits"] as FileValue)?.Path));

foreach (var race in races)
{
    Console.WriteLine("Updating " + race.Name);
    race.Values["pathfind acceleration"] = pathfindAcceleration;

    // avoid changing for races that like water
    if ((Single)race.Values["water avoidance"] > 0)
    {
        race.Values["water avoidance"] = waterAvoidance;
    }
}

Console.WriteLine();
Console.Write("Saving... ");

context.Save(folders.Mod);

Console.WriteLine("done");

if (!enabledMods.Contains(ModName))
{
    enabledMods.Add(ModName);

    OcsService.Default.SaveLoadOrder(folders.Data, enabledMods.ToArray());

    Console.WriteLine("Added patch to load order");
}

Console.ReadLine();