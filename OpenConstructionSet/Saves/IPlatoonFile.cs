namespace OpenConstructionSet.Saves;

/// <summary>
/// Represents a .platoon file from a <see cref="ISave"/>.
/// </summary>
public interface IPlatoonFile : IDataFile
{
    /// <summary>
    /// The faction this platoon belongs to.
    /// </summary>
    string Faction { get; }

    /// <summary>
    /// The Id of this platoon.
    /// </summary>
    int Id { get; }
}
