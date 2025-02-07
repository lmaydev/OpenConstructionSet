using OpenConstructionSet.Saves;

namespace OpenConstructionSet.Installations;

public class InstallationFactory(SaveFolderHelper saveHelper)
{
    public virtual IInstallation Build(string identifier, string rootPath, string? contentPath)
    {
        var modsPath = Path.Combine(rootPath, "mods");
        var dataPath = Path.Combine(rootPath, "data");
        var savePath = saveHelper.GetSaveFolder(rootPath);

        var data = new ModFolder(dataPath, ModFolderType.Data);
        var mods = new ModFolder(modsPath, ModFolderType.Mod);
        var content = contentPath is not null ? new ModFolder(contentPath, ModFolderType.Content) : null;
        var saves = new SaveFolder(savePath);

        return new Installation(identifier, rootPath, data, mods, content, saves);
    }
}
