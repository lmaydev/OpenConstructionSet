
namespace OpenConstructionSet.Mods
{
    public interface IModFile
    {
        string Filename { get; }
        string Name { get; }
        string Path { get; }

        Task<ModFileData> ReadDataAsync(CancellationToken cancellationToken = default);
        Task<Header> ReadHeaderAsync(CancellationToken cancellationToken = default);
        Task<ModFileInfo?> ReadInfoAsync(CancellationToken cancellationToken = default);
        Task WriteDataAsync(ModFileData data, CancellationToken cancellationToken = default);
        Task WriteHeaderAsync(Header header, CancellationToken cancellationToken = default);
        Task WriteInfoAsync(ModFileInfo info, CancellationToken cancellationToken = default);
    }
}