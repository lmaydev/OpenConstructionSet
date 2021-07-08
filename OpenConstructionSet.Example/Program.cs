using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using forgotten_construction_set;
using static forgotten_construction_set.GameData;

namespace OpenConstructionSet.Example
{
    internal static class Program
    {
        private static void Main()
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };

            options.Converters.Add(new JsonStringEnumConverter());

            const string modName = "OCS Example";

            // Metadata for new mod
            var header = new Header
            {
                Author = "lmaydev",
                Description = "Open Construction Set MA Example",
                Version = 2,
            };

            // Creates a new mod and saves it in the default mod folder
            var modPath = OcsHelper.NewMod(header, modName);

            Console.WriteLine($"Created new mod at {modPath}");

            // Load the base mods and the new mod as active.
            var gameData = OcsHelper.Load(activeMod: modName);

            // For each STATS item with an attack set
            gameData.items.OfType(itemType.STATS)
                          .Where(i => i.ContainsKey("attack"))
                          .ForEach(item =>
                          {
                              // Set unarmed to equal attack
                              var attack = item["attack"];
                              item["unarmed"] = attack;
                              Console.WriteLine($"Updating {item.Name}, changing unarmed to {attack}");

                              // Convert to a model and serialize
                              var model = item.ToModel();
                              var json = JsonSerializer.Serialize(model, options);
                              Console.WriteLine(json);
                          });

            gameData.save(modPath);

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