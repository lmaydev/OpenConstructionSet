using OpenConstructionSet.Data;
using OpenConstructionSet.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenConstructionSet.Example;

internal static class Program
{
    private static void Main()
    {

        var entity = new Entity(ItemType.Building, "", "");

        var options = new JsonSerializerOptions { WriteIndented = true, };

        options.Converters.Add(new JsonStringEnumConverter());

        const string modName = "OCS Example";

        Console.WriteLine("Searching for game folders");

        var folders = OcsService.Default.FindGameFolders();

        if (folders is null)
        {
            Console.WriteLine("Could not find game folders!");
            Console.Write("Press any key to exit...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Game folder found: {folders.Game}");
        Console.WriteLine();

        Console.WriteLine("Building game data");

        var baseMods = OcsService.Default.ReadLoadOrder(folders.ToArray());

        var stopWatch = new Stopwatch();

        stopWatch.Start();

        var dataContext = OcsDataContextBuilder.Default.Build(
            modName + ".mod",
            folders: folders.ToArray(),
            baseMods: baseMods,
            header: new Header(2, "lmaydev", "OCS Example - Unarmed set equal to Attack for all stats items"),
            info: new ModInfo(0, modName + ".mod", modName, new[] { "Total Overhaul" }, 0, DateTime.Now),
            loadGameFiles: ModLoadType.Base,
            throwIfMissing: false);

        Console.WriteLine($"Game data built in {stopWatch.Elapsed.TotalSeconds} seconds");
        Console.WriteLine();

        Console.WriteLine("Updating items");

        stopWatch.Restart();

        var count = 0;

        dataContext.Items.Values.OfType(ItemType.Stats)
                                .Where(i => i.Values.ContainsKey("attack"))
                                .ForEach(item =>
                                {
                                    //Console.WriteLine($"\"{item.Name}\" unarmed set to {item.Values["attack"]}");
                                    item.Values["unarmed"] = item.Values["attack"];
                                    count++;
                                });

        Console.WriteLine($"{count} items updated in {stopWatch.Elapsed.TotalSeconds} seconds");

        if (folders.Mod is not null)
        {
            Console.WriteLine("Saving mod");

            stopWatch.Restart();

            dataContext.Save(folders.Mod);

            Console.WriteLine($"Save complete {stopWatch.Elapsed.TotalSeconds} seconds");
        }

        Console.ReadKey();
    }

    internal static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
    }
}
