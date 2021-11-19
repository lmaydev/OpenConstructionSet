namespace OpenConstructionSet.IO.Discovery;

/// <summary>
/// Used to resolve a mod name (e.g. example.mod) to it's full path.
/// </summary>
public interface IModNameResolver
{
    /// <summary>
    /// Search the given folders for the specified mod.
    /// </summary>
    /// <param name="folders">A collection of folders to search.</param>
    /// <param name="mod">Name of the mod to search for. e.g. example.mod</param>
    /// <returns>A <c>ModFile</c> if the name could be resolved; otherwise, <c>null</c></returns>
    ModFile? Resolve(IEnumerable<ModFolder> folders, string mod);

    /// <summary>
    /// Resolve all provided mods using the given folders.
    /// </summary>
    /// <param name="folders">A collection of folders to search.</param>
    /// <param name="mods">A collection of mod names to search for. e.g. exmaple.mod</param>
    /// <param name="throwIfMissing">
    /// If <c>true</c> an exception will be thrown for any missing mods.
    /// If <c>false</c> missing mods will be omitted from the results.
    /// </param>
    /// <returns>A collection of all mods that could be resolved.</returns>
    IEnumerable<ModFile> Resolve(IEnumerable<ModFolder> folders, IEnumerable<string> mods, bool throwIfMissing);
}
