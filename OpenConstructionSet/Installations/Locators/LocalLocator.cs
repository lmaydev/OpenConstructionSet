using System.Diagnostics.CodeAnalysis;

namespace OpenConstructionSet.Installations.Locators;

/// <summary>
/// Implementation of a <see cref="IInstallationLocator"/> that looks for the folders in the working directory.
/// </summary>
public class LocalLocator : IInstallationLocator
{
    /// <inheritdoc/>
    public string Id { get; } = "Local";

    public bool TryLocate([MaybeNullWhen(false)] out IInstallation installation)
    {
        if (!Directory.Exists("data") || !Directory.Exists("mods"))
        {
            installation = null;
            return false;
        }

        installation = new Installation(Id, Path.GetFullPath("."), null);
        return true;
    }
}
