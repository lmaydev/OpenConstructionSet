namespace OpenConstructionSet.IO.Discovery;

/// <inheritdoc/>
public class ModNameResolver : IModNameResolver
{
    private static readonly Lazy<ModNameResolver> _default = new(() => new(OcsService.Default));

    /// <summary>
    /// Lazy initiated singleton for when DI is not being used
    /// </summary>
    public static ModNameResolver Default => _default.Value;

    private readonly IOcsService discoveryService;

    /// <summary>
    /// Creates a new ModNameResolver instance.
    /// </summary>
    /// <param name="discoveryService">Service used when discovering files.</param>
    public ModNameResolver(IOcsService discoveryService) => this.discoveryService = discoveryService;

    /// <inheritdoc/>
    public ModFile? Resolve(IEnumerable<ModFolder> modFolders, string mod)
    {
        if (File.Exists(mod))
        {
            return discoveryService.DiscoverMod(mod);
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

    /// <inheritdoc/>
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
