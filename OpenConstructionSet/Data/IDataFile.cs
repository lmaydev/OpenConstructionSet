namespace OpenConstructionSet.Data
{
    public interface IDataFile
    {
        string Filename { get; }
        string Name { get; }
        string Path { get; }

        Task<DataFileData> ReadDataAsync(CancellationToken cancellationToken = default);

        Task WriteDataAsync(DataFileData data, CancellationToken cancellationToken = default);
    }
}
