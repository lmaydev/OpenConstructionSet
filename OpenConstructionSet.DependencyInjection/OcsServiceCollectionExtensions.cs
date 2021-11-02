using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenConstructionSet;
using OpenConstructionSet.IO.Discovery;

namespace Microsoft.Extensions.DependencyInjection;

public static class OcsServiceCollectionExtensions
{
    public static IServiceCollection AddOpenContructionSet(this IServiceCollection services)
    {
        services.TryAddEnumerable(new[]
        {
                ServiceDescriptor.Singleton<IInstallationLocator, SteamFolderLocator>(),
                ServiceDescriptor.Singleton<IInstallationLocator, GogFolderLocator>(),
                ServiceDescriptor.Singleton<IInstallationLocator, LocalFolderLocator>(),
            });

        return services.AddSingleton<IOcsIOService, OcsIOService>()
                       .AddSingleton<IModNameResolver, ModNameResolver>()
                       .AddSingleton<IOcsDiscoveryService, OcsDiscoveryService>()
                       .AddSingleton<IOcsDataContextBuilder, OcsDataContextBuilder>();
    }
}
