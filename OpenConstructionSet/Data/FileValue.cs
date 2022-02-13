namespace OpenConstructionSet.Data;

/// <summary>
/// Represents a file stored in the game data.
/// </summary>
public struct FileValue
{
    /// <summary>
    /// Creates a new <see cref="FileValue"/> with the given path value.
    /// </summary>
    /// <param name="path">The file path reference by this <see cref="FileValue"/></param>
    public FileValue(string path)
    {
        Path = path;
    }

    /// <summary>
    /// The file path referenced by this <see cref="FileValue"/>
    /// </summary>
    public string Path { get; set; }
}
