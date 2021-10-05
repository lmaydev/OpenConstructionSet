using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.IO.Discovery;

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
    /// <param name="folders">If successful will be set to the located installation; otherwise, <c>null</c>.</param>
    /// <returns><c>true</c> if an installation was found.</returns>
    bool TryFind([MaybeNullWhen(false)] out LocatedFolders folders);
}
