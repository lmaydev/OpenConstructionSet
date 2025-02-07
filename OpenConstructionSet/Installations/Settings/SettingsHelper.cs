namespace OpenConstructionSet.Installations.Settings;

public class SettingsHelper
{
    const string SettingsFile = "settings.cfg";

    const string UserSaveLocationSettingName = "User save location";

    public virtual string ReadSetting(string installationPath, string name)
    {
        try
        {
            var settingLine = File.ReadLines(Path.Combine(installationPath, SettingsFile))
                                   .FirstOrDefault(l => l.StartsWith(UserSaveLocationSettingName, StringComparison.OrdinalIgnoreCase))
                                   ?? throw new KeyNotFoundException("Setting could not be found");

            var parts = settingLine.Split('=', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parts.Length is not 2) { throw new FormatException("Setting not in the format Key=Value"); }

            return parts[1];
        }
        catch (Exception ex)
        {
            throw SettingException.ReadFailed(name, ex);
        }
    }

    public virtual UserSaveLocation GetUserSaveLocation(string installationPath)
    {
        try
        {
            return (UserSaveLocation)int.Parse(ReadSetting(installationPath, UserSaveLocationSettingName));
        }
        catch (SettingException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw SettingException.ReadFailed(UserSaveLocationSettingName, ex);
        }
    }
}
