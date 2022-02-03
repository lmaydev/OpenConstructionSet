namespace OpenConstructionSet.Installations.Locators;

/// <summary>
/// Used to locate game installations from various platforms.
/// </summary>
public interface IInstallationLocator
{
    /// <summary>
    /// The unique identifier for this locator.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Attempt to find an installation.
    /// </summary>
    /// <returns>An <see cref="Installation"/> if located; otherwise, <c>null</c></returns>
    Task<IInstallation?> LocateAsync();
}
