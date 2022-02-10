namespace OpenConstructionSet.Saves;

/// <inheritdoc/>
public class SaveFolder : ISaveFolder
{
    /// <summary>
    /// Creats a new <see cref="SaveFolder"/> instance from the given path.
    /// </summary>
    /// <param name="path">The path of the <see cref="SaveFolder"/>.</param>
    public SaveFolder(string path)
    {
        Path = path;
    }

    /// <inheritdoc/>
    public string Path { get; set; }

    /// <inheritdoc/>
    public IEnumerable<ISave> GetSaves()
    {
        foreach (var folder in Directory.GetDirectories(Path))
        {
            yield return new Save(folder);
        }
    }

    /// <inheritdoc/>
    public override string ToString() => Path;
}
