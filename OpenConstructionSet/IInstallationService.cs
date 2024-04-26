using System.Diagnostics.CodeAnalysis;
using OpenConstructionSet.Installations;

namespace OpenConstructionSet;

public interface IInstallationService
{
    /// <summary>
    /// List of supported <see cref="IInstallationLocator"/>.
    /// </summary>
    string[] SupportedLocators { get; }

    /// <summary>
    /// Find all available installations.
    /// </summary>
    /// <returns>All <see cref="IInstallation"/> that could be found.</returns>
    IEnumerable<IInstallation> LocateAll();

    /// <summary>
    /// Attempt to locate any <see cref="IInstallation"/>.
    /// </summary>
    /// <param name="installation">Will contain the <see cref="IInstallation"/> if found.</param>
    /// <returns><c>true</c> if an <see cref="IInstallation"/> could be located</returns>
    bool TryLocate([MaybeNullWhen(false)] out IInstallation installation);

    /// <summary>
    /// Attempt to locate an <see cref="IInstallation"/> using the specified detector.
    /// </summary>
    /// <param name="Id">The Id of the <see cref="IInstallationLocator"/> to use.</param>
    /// <param name="installation">Will contain the <see cref="IInstallation"/> if found./param>
    /// <returns><c>true</c> if an <see cref="IInstallation"/> could be located</returns>
    bool TryLocate(string Id, [MaybeNullWhen(false)] out IInstallation installation);
}
