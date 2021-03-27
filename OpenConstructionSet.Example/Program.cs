using System.Collections.Generic;
using System.Linq;
using forgotten_construction_set;
using static forgotten_construction_set.GameData;

namespace OpenConstructionSet.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var folders = ModFolder.ResolveDefaultFolders();

            var modFilename = "OCS Example.mod";
            var modFullPath = folders.Mod.GetFilePath(modFilename);

            var header = new Header
            {
                Author = "lmay",
                Description = "Open Construction Set Example",
                Version = 2,
            };

            var service = new OpenConstructionSetService(new[] { folders.Mod, folders.Base });

            var gameData = service.InitMod(header, folders.Mod, modFilename);

            var mods = new List<string> { modFilename };
            mods.AddRange(OpenConstructionSetService.BaseMods);

            service.Load(mods, true, gameData);

            // Get all stats with an attack value set and change the item's unarmed to match
            gameData.items.OfType(itemType.STATS)
                          .Where(i => i.ContainsKey("attack"))
                          .ToList()
                          .ForEach(i => i["unarmed"] = i["attack"]);

            gameData.save(modFullPath);
        }
    }
}