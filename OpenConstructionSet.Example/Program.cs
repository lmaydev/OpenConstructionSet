using System;
using System.Linq;
using forgotten_construction_set;
using static forgotten_construction_set.GameData;

namespace OpenConstructionSet.Example
{
    internal class Program
    {
        private static void Main()
        {
            const string modFilename = "OCS Example.mod";

            // Metadata for new mod
            var header = new Header
            {
                Author = "lmaydev",
                Description = "Open Construction Set MA Example",
                Version = 2,
            };

            // Creates a new mod and saves it in the default mod folder
            var modPath = OcsHelper.NewMod(header, modFilename);

            Console.WriteLine($"Created new mod at {modPath}");

            // Load the base mods and the new mod as active.
            var gameData = OcsHelper.Load(OcsHelper.BaseMods, modFilename);

            // Change unarmed to match attack in all stats items
            gameData.items.OfType(itemType.STATS)
                          .Where(i => i.ContainsKey("attack"))
                          .ToList()
                          .ForEach(i =>
                          {
                              var attack = i["attack"];
                              i["unarmed"] = attack;
                              Console.WriteLine($"Updating {i.Name}, changing unarmed to {attack}");
                          });

            gameData.save(modPath);

            Console.ReadKey();
        }
    }
}