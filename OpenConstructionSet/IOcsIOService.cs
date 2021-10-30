
namespace OpenConstructionSet;

/// <summary>
/// Service used to read and write game files.
/// </summary>
public interface IOcsIOService
{
    /// <summary>
    /// Read save or mod file (Type 14 or 15)
    /// </summary>
    /// <param name="reader">Reader to use.</param>
    /// <returns>A <c>DataFile</c> containing the file's data or <c>null</c> if unable to read.</returns>
    DataFile? ReadDataFile(OcsReader reader);

    /// <summary>
    /// Read the header from the reader.
    /// </summary>
    /// <param name="reader">The header to use.</param>
    /// <returns>The header read from the reader or <c>null</c> if unable to read.</returns>
    Header? ReadHeader(OcsReader reader);

    /// <summary>
    /// Read info file data from the given stream.
    /// </summary>
    /// <param name="stream">Stream containing the info file data.</param>
    /// <returns>A <c>ModInfo</c> from the stream or <c>null</c> if unable to read.</returns>
    ModInfo? ReadInfo(Stream stream);

    /// <summary>
    /// Write the <c>DataFile</c> to the given writer.
    /// </summary>
    /// <param name="writer">Writer to use.</param>
    /// <param name="data"><c>DataFile</c> to write.</param>
    void Write(OcsWriter writer, DataFile data);

    /// <summary>
    /// Write the info data to the stream. 
    /// </summary>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="info">The info file data to write.</param>
    void Write(Stream stream, ModInfo info);

    /// <summary>
    /// Attempts to read the enabled mods and load order from the specified file.
    /// </summary>
    /// <param name="file">The file containing the enabled mods and load order.</param>
    /// <returns>A collection of enabled mod names in load order. If the file cannot be found <c>null</c> is returned.</returns>
    List<string>? ReadEnabledMods(string file);

    /// <summary>
    /// Save a collection of mod names to the load order file. This file is contained in the game's data folder.
    /// </summary>
    /// <param name="file">The file to store the enabled mods and load order to.</param>
    /// <param name="enabledMods">List of enabled mod names in load order.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c>.</returns>
    void Write(string file, IEnumerable<string> enabledMods);

    /// <summary>
    /// Save the enabled mods and load order for this installation to file.
    /// </summary>
    /// <param name="installation">The installation who's enabled mods and load order should be saved.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c>.</returns>
    void SaveEnabledMods(Installation installation);
}