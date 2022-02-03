namespace OpenConstructionSet.Saves
{
    public class PlatoonFile : DataFile, IPlatoonFile
    {
        public PlatoonFile(string path) : base(path)
        {
            var parts = Name.Split('_');

            Faction = parts[0];
            Id = int.Parse(parts[1]);
        }

        public string Faction { get; }

        public int Id { get; }

        public override string ToString() => $"{Faction} {Id}";
    }

    public class ZoneFile : DataFile, IZoneFile
    {
        public ZoneFile(string path) : base(path)
        {
            var parts = Name.Split('.');

            Id = new(int.Parse(parts[1]), int.Parse(parts[2]));
        }

        public Tuple<int, int> Id { get; }

        public override string ToString() => Id.ToString();
    }
}
