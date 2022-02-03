using OpenConstructionSet.Mods;

namespace OpenConstructionSet.Installations
{
    public interface IModFolder
    {
        string Path { get; }
        ModFolderType Type { get; }

        string GetModPath(string modName, uint modId = 0);
        IEnumerable<IModFile> GetMods();
    }
}