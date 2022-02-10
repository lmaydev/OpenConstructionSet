namespace OpenConstructionSet.Saves;

/// <inheritdoc/>
public class PlatoonFile : DataFile, IPlatoonFile
{
    /// <summary>
    /// Creats a new <see cref="PlatoonFile"/> instance from the given path.
    /// </summary>
    /// <param name="path">The path of the <see cref="PlatoonFile"/>.</param>
    public PlatoonFile(string path) : base(path)
    {
        var parts = Name.Split('_');

        Faction = parts[0];
        Id = int.Parse(parts[1]);
    }

    /// <inheritdoc/>
    public string Faction { get; }

    /// <inheritdoc/>
    public int Id { get; }

    /// <inheritdoc/>
    public override string ToString() => $"{Faction} {Id}";
}
