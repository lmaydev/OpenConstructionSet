namespace OpenConstructionSet.IO.Discovery;

public class ModNameResolver : IModNameResolver
{
    private static readonly Lazy<ModNameResolver> _default = new(() => new(OcsDiscoveryService.Default));

    public static ModNameResolver Default => _default.Value;

    private readonly IOcsDiscoveryService discoveryService;

    public ModNameResolver(IOcsDiscoveryService discoveryService) => this.discoveryService = discoveryService;

    public ModFile? Resolve(IEnumerable<ModFolder> modFolders, string mod)
    {
        if (File.Exists(mod))
        {
            return discoveryService.DiscoverFile(mod);
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

    public IEnumerable<ModFile> Resolve(IEnumerable<ModFolder> folders, IEnumerable<string> mods, bool throwIfMissing)
    {
        foreach (var mod in mods)
        {
            var modFile = Resolve(folders, mod);

            if (modFile is not null)
            {
                yield return modFile;
            }
            else if (throwIfMissing)
            {
                throw new Exception($"Could not resolve the mod \"{mod}\"");
            }
        }
    }
}
