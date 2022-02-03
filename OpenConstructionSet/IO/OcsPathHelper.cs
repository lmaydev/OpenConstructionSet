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

    internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
}