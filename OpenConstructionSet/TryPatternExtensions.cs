using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenConstructionSet;

/// <summary>
/// Provides Try/Out patterns to existing interface methods.
/// </summary>
public static class TryPatternExtensions
{
    /// <summary>
    /// Attempts to read the load order file. This file is contained in the game's data folder.
    /// </summary>
    /// <param name="service">The service to call the method on.</param>
    /// <param name="folder">Data folder to find the file in.</param>
    /// <param name="enabledMods">If successful will contain the collection of mod names from the load order.</param>
    /// <returns><c>true</c> if the load order can be read.</returns>
    public static bool TryReadLoadOrder(this IOcsService service, string folder, [MaybeNullWhen(false)]out string[] enabledMods)
    {
        try
        {
            enabledMods = service.ReadLoadOrder(folder);

            return enabledMods is not null;
        }
        catch(Exception ex)
        {
            // TODO log exception
        }

        enabledMods = null;
        return false;
    }

    /// <summary>
    /// Attempts to read the header of the provided file.
    /// </summary>
    /// <param name="service">The service to call the method on.</param>
    /// <param name="path">The path of the mod file.</param>
    /// <param name="header">Will contain the read header if successful.</param>
    /// <returns><c>true</c> if header can be read.</returns>
    public static bool TryReadHeader(this IOcsService service, string path, [MaybeNullWhen(false)] out Header header)
    {
        try
        {
            header = service.ReadHeader(path);

            return header is not null;
        }
        catch (Exception ex)
        {
            // TODO log exception
        }

        header = null;
        return false;
    }
}
