namespace OpenConstructionSet.Saves
{
    /// <inheritdoc/>
    public class ZoneFile : DataFile, IZoneFile
    {
        /// <summary>
        /// Creats a new <see cref="ZoneFile"/> instance from the given path.
        /// </summary>
        /// <param name="path">The path of the <see cref="ZoneFile"/>.</param>
        public ZoneFile(string path) : base(path)
        {
            var parts = Name.Split('.');

            Id = new(int.Parse(parts[1]), int.Parse(parts[2]));
        }

        /// <inheritdoc/>
        public Tuple<int, int> Id { get; }

        /// <inheritdoc/>
        public override string ToString() => Id.ToString();
    }
}
