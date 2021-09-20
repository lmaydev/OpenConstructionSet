using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenConstructionSet.IO.Discovery
{
    public class ModNameResolver : IModNameResolver
    {
        private readonly IOcsDiscoveryService discoveryService;

        public ModNameResolver(IOcsDiscoveryService discoveryService)
        {
            this.discoveryService = discoveryService;
        }

        public ModFile? Resolve(string mod, IEnumerable<ModFolder> modFolders)
        {
            if (File.Exists(mod))
            {
                return discoveryService.Discover(new FileInfo(mod));
            }

            mod = mod.AddModExtension();

            foreach (var folder in modFolders)
            {
                if (folder.Mods.TryGetValue(mod, out var modFile))
                {
                    return modFile;
                }
            }

            return null;
        }

        public ModFile ResolveOrThrow(string mod, IEnumerable<ModFolder> modFolders) => Resolve(mod, modFolders) ?? throw new Exception("Failed to resolve file");

        public IEnumerable<ModFile> ResolveOrThrow(IEnumerable<string> mods, IEnumerable<ModFolder> modFolders) => mods.Select(m =>
            Resolve(m, modFolders) ?? throw new Exception("Failed to resolve file"));
    }
}
