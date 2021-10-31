using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet;

/// <summary>
/// Collection of wrapper function for the IO service.
/// Implemented as extension methods because they wrap a single method and this way they don't have to be added to the interface.
/// </summary>
public static class OcsIOServiceExtensions
{
    private static bool TryOpenRead(string file, [MaybeNullWhen(false)] out Stream stream)
    {
        if (!File.Exists(file))
        {
            stream = null;
            return false;
        }

        stream = File.OpenRead(file);
        return true;
    }

    private static bool TryReadAll(string file, [MaybeNullWhen(false)] out byte[] data)
    {
        if (!File.Exists(file))
        {
            data = null;
            return false;
        }

        data = File.ReadAllBytes(file);
        return true;
    }

    private static bool TryCreateFile(string file, [MaybeNullWhen(false)] out Stream stream)
    {
        if (File.Exists(file))
        {
            File.Delete(file);
        }

        stream = File.Create(file);
        return true;
    }

    /// <summary>
    /// Write the <c>DataFile</c> to the specified file.
    /// </summary>
    /// <param name="service">Service to wrap.</param>
    /// <param name="file">The file to write to.</param>
    /// <param name="data">The data to write to file.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c></returns>
    public static bool Write(this IOcsIOService service, string file, DataFile data)
    {
        if (!TryCreateFile(file, out var stream))
        {
            return false;
        }

        using var writer = new OcsWriter(stream);

        service.Write(writer, data);

        return true;
    }

    /// <summary>
    /// Write the mod info file data to the specified file.
    /// </summary>
    /// <param name="service">Service to wrap.</param>
    /// <param name="file">The file to write to.</param>
    /// <param name="info">The mod inf file data to write.</param>
    /// <returns><c>true</c> if successful; otherwise, <c>false</c></returns>
    public static bool Write(this IOcsIOService service, string file, ModInfo info)
    {
        if (!TryCreateFile(file, out var stream))
        {
            return false;
        }

        service.Write(stream, info);

        stream.Dispose();

        return true;
    }

    /// <summary>
    /// Attempts to read the header of the provided file.
    /// </summary>
    /// <param name="service">Service to wrap.</param>
    /// <param name="file">The file to read.</param>
    /// <returns>The file's header if readable; otherwise, <c>null</c>.</returns>
    public static Header? ReadHeader(this IOcsIOService service, string file)
    {
        if (!TryOpenRead(file, out var stream))
        {
            return null;
        }

        using var reader = new OcsReader(stream);

        return service.ReadHeader(reader);
    }

    /// <summary>
    /// Attempts to read the specified data file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="file">The file to read.</param>
    /// <returns>A <c>DataFile</c> read from the file if readable; otherwise; <c>null</c>.</returns>
    public static DataFile? ReadDataFile(this IOcsIOService service, string file) => TryReadAll(file, out var data) ? service.ReadDataFile(new OcsReader(data)) : null;

    /// <summary>
    /// Attempts to read the provided mod info file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="file">The file to read.</param>
    /// <returns>A <c>ModInfo</c> read from the file if readable; otherwise, <c>null</c></returns>
    public static ModInfo? ReadInfo(this IOcsIOService service, string file)
    {
        if (!TryOpenRead(file, out var stream))
        {
            return null;
        }
        using (stream)
        {
            return service.ReadInfo(stream);
        }
    }

    /// <summary>
    /// Attempts to read the enabled mods and load order from file in the given directory. This should the be the game's data folder.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="folder">Data folder to find the file in.</param>
    /// <param name="enabledMods">If successful will contain the collection of mod names from the load order.</param>
    /// <returns><c>true</c> if the load order can be read.</returns>
    public static bool TryReadEnabledMods(this IOcsIOService service, string folder, [MaybeNullWhen(false)] out List<string> enabledMods)
    {
        try
        {
            enabledMods = service.ReadEnabledMods(folder);

            return enabledMods is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        enabledMods = null;
        return false;
    }

    /// <summary>
    /// Attempts to read the header of the provided file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="path">The path of the mod file.</param>
    /// <param name="header">Will contain the read header if successful.</param>
    /// <returns><c>true</c> if header can be read.</returns>
    public static bool TryReadHeader(this IOcsIOService service, string path, [MaybeNullWhen(false)] out Header header)
    {
        try
        {
            header = service.ReadHeader(path);

            return header is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        header = null;
        return false;
    }

    /// <summary>
    /// Attempts to read the specified data file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="path">The path of the data file.</param>
    /// <param name="data">Will contain a <c>DataFile</c> read from the file if successful.</param>
    /// <returns><c>true</c> if the data file can be read.</returns>
    public static bool TryReadDataFile(this IOcsIOService service, string path, [MaybeNullWhen(false)] out DataFile data)
    {
        try
        {
            data = service.ReadDataFile(path);

            return data is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        data = null;
        return false;
    }

    /// <summary>
    /// Attempts to read the specified mod info file.
    /// </summary>
    /// <param name="service">The service to wrap.</param>
    /// <param name="path">The path of the mod info file.</param>
    /// <param name="info">Will contain a <c>ModInfo</c> if successful.</param>
    /// <returns><c>true</c> if the mod info file can be read.</returns>
    public static bool TryReadInfo(this IOcsIOService service, string path, [MaybeNullWhen(false)] out ModInfo info)
    {
        try
        {
            info = service.ReadInfo(path);

            return info is not null;
        }
        catch (Exception)
        {
            // TODO log exception
        }

        info = null;
        return false;
    }
}
