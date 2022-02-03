namespace OpenConstructionSet.Installations.Locators;

/// <summary>
/// Implementation of a <see cref="IInstallationLocator"/> that looks for the folders in the working directory.
/// </summary>
public class LocalLocator : IInstallationLocator
{
    /// <inheritdoc/>
    public string Id { get; } = "Local";

    /// <inheritdoc/>
    public Task<IInstallation?> LocateAsync()
    {
        if (!Directory.Exists("data") || !Directory.Exists("mods"))
        {
            return Task.FromResult<IInstallation?>(null);
        }

        return Task.FromResult<IInstallation?>(new Installation(Id, Path.GetFullPath("."), null));
    }
}