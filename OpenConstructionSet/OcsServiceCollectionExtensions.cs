using System.Runtime.Versioning;
using GameFinder.RegistryUtils;
using GameFinder.StoreHandlers.GOG;
using GameFinder.StoreHandlers.Steam;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NexusMods.Paths;
using OpenConstructionSet;
using OpenConstructionSet.Installations;
using OpenConstructionSet.Installations.Locators;
using OpenConstructionSet.Installations.Settings;

namespace Microsoft.Extensions.DependencyInjection;

public static class OcsServiceCollectionExtensions
{
    [SupportedOSPlatform("windows")]
    public static IServiceCollection AddOpenConstructionSet(this IServiceCollection services)
    {
        // Game finder
        services.TryAddSingleton(FileSystem.Shared);
        services.TryAddSingleton(WindowsRegistry.Shared);
        services.TryAddSingleton<SteamHandler>();
        services.TryAddSingleton<GOGHandler>();

        // Locators
        services.TryAddEnumerable(
        [
                ServiceDescriptor.Singleton<IInstallationLocator, SteamLocator>(),
                ServiceDescriptor.Singleton<IInstallationLocator, GogLocator>(),
                ServiceDescriptor.Singleton<IInstallationLocator, LocalLocator>(),
        ]);

        services.TryAddSingleton<SettingsHelper>();
        services.TryAddSingleton<SaveFolderHelper>();

        // Core services
        services.TryAddSingleton<IInstallationService, InstallationService>();
        services.TryAddSingleton<IContextBuilder, ContextBuilder>();

        return services;
    }
}
