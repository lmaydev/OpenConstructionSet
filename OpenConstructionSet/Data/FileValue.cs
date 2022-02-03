namespace OpenConstructionSet.Data
{
    public struct FileValue
    {
        public FileValue(string path)
        {
            Path = path;
        }

        public string Path { get; set; }
    }
}