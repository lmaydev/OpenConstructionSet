namespace OpenConstructionSet.Saves
{
    /// <summary>
    /// Represents a .zone file from a <see cref="ISave"/>.
    /// </summary>
    public interface IZoneFile : IDataFile
    {
        /// <summary>
        /// The unique Id of this <see cref="IZoneFile"/>.
        /// </summary>
        Tuple<int, int> Id { get; }
    }
}
