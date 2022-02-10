namespace OpenConstructionSet.Saves;

/// <summary>
/// Represents a folder that contains the folder's of <see cref="ISave"/>s.
/// </summary>
public interface ISaveFolder
{
    /// <summary>
    /// The path to the <see cref="ISaveFolder"/>.
    /// </summary>
    string Path { get; set; }

    /// <summary>
    /// Get's all <see cref="ISave"/>s contained in this <see cref="ISaveFolder"/>.
    /// </summary>
    /// <returns>A collection of <see cref="ISave"/>s contained in this <see cref="ISaveFolder"/>.</returns>
    IEnumerable<ISave> GetSaves();
}
