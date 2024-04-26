using System.Diagnostics.CodeAnalysis;

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
    /// Attempts to find an installation
    /// </summary>
    /// <param name="installation">If the game is located this parameter will contain the resulting <see cref="IInstallation"/></param>
    /// <returns></returns>
    bool TryLocate([MaybeNullWhen(false)] out IInstallation installation);
}
