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
    /// Adds .mod to a mod name if no extension is present.
    /// e.g. example becomes example.mod while example.data will be unchanged
    /// </summary>
    /// <param name="modName">The name, filename or path of a mod.</param>
    /// <returns>
    /// The given mod name with a .mod extension if there was no extension originally.
    /// Otherwise simply returns the given mod name.
    /// </returns>
    internal static string AddModExtension(this string modName) => string.IsNullOrEmpty(Path.GetExtension(modName)) ? $"{modName}.mod" : modName;
}
