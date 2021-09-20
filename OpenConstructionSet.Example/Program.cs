using Microsoft.Extensions.DependencyInjection;
using OpenConstructionSet.Data;
using OpenConstructionSet.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenConstructionSet.Example
{
    internal static class Program
    {
        private static void Main()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };

            options.Converters.Add(new JsonStringEnumConverter());

            const string modName = "OCS Example";

            // Setup dependency injection
            var services = new ServiceCollection().UseOpenContructionSet().BuildServiceProvider();

            // Get the required services
            var discovery = services.GetRequiredService<IOcsDiscoveryService>();
            var builder = services.GetRequiredService<IOcsDataContextBuilder>();

            if (!discovery.TryFindGameFolders(out var folders))
            {
                Console.WriteLine("Could not find game folders!");
                Console.Write("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            var dataContext = builder.Build(
                modName + ".mod",
                folders: folders.ToArray(),
                header: new Header(2, "lmaydev", "OCS Example - Unarmed set equal to Attack for all stats items"),
                info: new ModInfo(0, modName + ".mod", modName, new[] { "Total Overhaul" }, 0, DateTime.Now),
                loadGameFiles: true);

            dataContext.Items.Values.OfType(ItemType.Stats)
                                    .Where(i => i.Values.ContainsKey("attack"))
                                    .ForEach(item => item.Values["unarmed"] = item.Values["attack"]);

            if (folders.Mod is not null)
            {
                dataContext.Save(folders.Mod);
            }

            Console.ReadKey();
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}