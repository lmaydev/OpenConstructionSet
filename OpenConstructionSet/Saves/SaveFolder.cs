namespace OpenConstructionSet.Saves
{
    public class SaveFolder : ISaveFolder
    {
        public SaveFolder(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        public IEnumerable<Save> GetSaves()
        {
            foreach (var folder in Directory.GetDirectories(Path))
            {
                yield return new(folder);
            }
        }

        public override string ToString() => Path;
    }
}
