using OpenConstructionSet.Installations.Settings;

namespace OpenConstructionSet.Installations;

public class SaveFolderHelper(SettingsHelper settings)
{
    public virtual string GetSaveFolder(string installationPath) => settings.GetUserSaveLocation(installationPath) switch
    {
        UserSaveLocation.ProgramFolder => Path.Combine(installationPath, "save"),
        UserSaveLocation.LocalData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "kenshi", "save"),
        _ => throw new InvalidOperationException(),
    };
}
