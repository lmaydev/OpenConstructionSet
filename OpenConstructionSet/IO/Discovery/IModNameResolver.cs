namespace OpenConstructionSet.IO.Discovery;

public interface IModNameResolver
{
    ModFile? Resolve(string mod, IEnumerable<ModFolder> modFolders);
    IEnumerable<ModFile> ResolveOrThrow(IEnumerable<string> mods, IEnumerable<ModFolder> modFolders);
    ModFile ResolveOrThrow(string mod, IEnumerable<ModFolder> modFolders);
}
