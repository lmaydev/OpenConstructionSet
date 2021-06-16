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
            // If we can't find the game folders panic!
            if (!OcsSteamHelper.TryFindDefaultFolders(out var defaultFolders))
                throw new Exception("Failed to find default game folders");

            const string modFilename = "OCS Example.mod";

            // Delete existing mod
            defaultFolders.Mod.Delete(modFilename);

            var modFullPath = defaultFolders.Mod.GetFullFilename(modFilename);

            // Metadata for new mod
            var header = new Header
            {
                Author = "lmaydev",
                Description = "Open Construction Set MA Example",
                Version = 2,
            };

            // Creates a new mod and saves it in the default mod folder
            var gameData = OcsHelper.NewMod(header, defaultFolders.Mod, modFilename);

            // Search the default folders for the base mods and their dependencies.
            var mods = OcsHelper.ResolveDependencyTree(OcsHelper.BaseMods, defaultFolders.ToArray());

            // Mods will be loaded and become dependencies of the new mod.
            // Adding other mods above would allow you to create content patchers.
            OcsHelper.Load(mods, modFullPath, gameData);

            // Get all stats items with an attack value set and change the item's unarmed to match
            gameData.items.OfType(itemType.STATS)
                          .Where(i => i.ContainsKey("attack"))
                          .ToList()
                          .ForEach(i => i["unarmed"] = i["attack"]);

            gameData.save(modFullPath);
        }
    }
}