namespace OpenConstructionSet.Installations.Settings;

public class SettingException : Exception
{
    public SettingException()
    {
    }

    public SettingException(string? message) : base(message)
    {
    }

    public SettingException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public static SettingException ReadFailed(string settingName, Exception? innerException)
        => new SettingException($"Failed to read setting {settingName}", innerException);
}
