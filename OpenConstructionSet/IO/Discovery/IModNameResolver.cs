namespace OpenConstructionSet.IO.Discovery;

public interface IModNameResolver
{
    ModFile? Resolve(IEnumerable<ModFolder> folders, string mod);
    IEnumerable<ModFile> Resolve(IEnumerable<ModFolder> folders, IEnumerable<string> mods, bool throwIfMissing);
}
