using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using OpenConstructionSet.Installations;
using OpenConstructionSet.Installations.Locators;

namespace OpenConstructionSet;

/// <inheritdoc/>
/// <summary>
/// Creates a new <see cref="InstallationService"/> using the provided <see cref="IInstallationLocator"/>s.
/// </summary>
/// <param name="locators">Collection of <see cref="IInstallationLocator"/> used to find <see cref="IInstallation"/>s.</param>
[SupportedOSPlatform("windows")]
public class InstallationService(IEnumerable<IInstallationLocator> locators) : IInstallationService
{
    private readonly Dictionary<string, IInstallationLocator> locatorDictionary = locators.ToDictionary(l => l.Id, l => l, StringComparer.OrdinalIgnoreCase);

    /// <inheritdoc/>
    public string[] SupportedLocators { get; } = locators.Select(l => l.Id).ToArray();

    /// <inheritdoc/>
    public bool TryLocate([MaybeNullWhen(false)] out IInstallation installation)
    {
        foreach (var locator in locatorDictionary.Values)
        {
            if (locator.TryLocate(out installation))
            {
                return true;
            }
        }

        installation = null;
        return false;
    }

    /// <inheritdoc/>
    public bool TryLocate(string Id, [MaybeNullWhen(false)] out IInstallation installation)
        => locatorDictionary.TryGetValue(Id, out var locator) ? locator.TryLocate(out installation) : throw new InvalidOperationException($"Unknown locator: {Id}");

    /// <inheritdoc/>
    public IEnumerable<IInstallation> LocateAll()
    {
        foreach (var locator in locatorDictionary.Values)
        {
            if (locator.TryLocate(out var installation)) { yield return installation; }
        }
    }
}
