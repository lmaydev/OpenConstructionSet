using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations
{
    public interface IInstallation
    {
        ModFolder? Content { get; }
        ModFolder Data { get; }
        string EnabledModsFile { get; }
        string Identifier { get; }
        ModFolder Mods { get; }
        string Path { get; }

        IEnumerable<IModFile> GetMods();

        Task<string[]> ReadEnabledModsAsync(CancellationToken cancellationToken = default);

        Task WriteEnabledModsAsync(IEnumerable<string> enabledMods, CancellationToken cancellationToken = default);
    }
}
