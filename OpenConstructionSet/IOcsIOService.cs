
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
    /// <param name="data"><c>DataFile</c> to write.</param>
    /// <param name="writer">Writer to use.</param>
    void Write(DataFile data, OcsWriter writer);

    /// <summary>
    /// Write the info data to the stream. 
    /// </summary>
    /// <param name="info">The info file data to write.</param>
    /// <param name="stream">The stream to write to.</param>
    void Write(ModInfo info, Stream stream);
}