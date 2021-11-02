namespace OpenConstructionSet.IO;

/// <summary>
/// A collection of helper functions for dealing with the game's files.
/// </summary>
public static class OcsPathHelper
{
    /// <summary>
    /// Gets the path of the info file for the given mod file.
    /// </summary>
    /// <param name="mod">The file to get the info file name for.</param>
    /// <returns>The path of the info file for the specified mod.</returns>
    public static string GetInfoPath(string mod)
    {
        var folder = Path.GetDirectoryName(mod) ?? "";

        var name = Path.GetFileNameWithoutExtension(mod);

        return Path.Combine(folder, $"_{name}.info");
    }

    /// <summary>
    /// Returns the full path of a mod from its' name.
    /// If the mod has been discovered it's path will be used.
    /// If not the path will be created using the folder and mod.
    /// </summary>
    /// <param name="folder">The mod folder.</param>
    /// <param name="mod">The file name of the mod. e.g. example.mod</param>
    /// <returns>The full path of a mod file.</returns>
    public static string GetModPath(ModFolder folder, string mod)
    {
        mod = mod.AddModExtension();

        return folder.Mods.ContainsKey(mod) ? folder.Mods[mod].FullName : GetModPath(folder.FullName, mod);
    }

    /// <summary>
    /// Get the full path for the named mod in the given folder.
    /// </summary>
    /// <param name="folder">The folder that will contain the mod.</param>
    /// <param name="mod">The name of the mod e.g. example.mod</param>
    /// <returns>The path of thge named mod in the given folder.</returns>
    public static string GetModPath(string folder, string mod) => Path.Combine(folder, Path.GetFileNameWithoutExtension(mod), mod.AddModExtension());

    /// <summary>
    /// Determines if the mod is in a standard folder structure. 
    /// </summary>
    /// <param name="mod">The name of the mod e.g. example.mod</param>
    /// <returns><c>true</c> if the mod is in a standard folder structure.</returns>
    public static bool CorrectModFolder(this ModFile mod)
    {
        var directory = Path.GetDirectoryName(mod.FullName);

        // Individual mod folder or content folder
        return directory == mod.Info?.Id.ToString() || directory == mod.Name;
    }

    internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
}
