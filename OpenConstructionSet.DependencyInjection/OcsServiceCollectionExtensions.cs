using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenConstructionSet.Installations.Locators;

namespace Microsoft.Extensions.DependencyInjection;

public static class OcsServiceCollectionExtensions
{
    public static IServiceCollection AddOpenContructionSet(this IServiceCollection services)
    {
        services.TryAddEnumerable(new[]
        {
                ServiceDescriptor.Singleton<IInstallationLocator, SteamLocator>(),
                ServiceDescriptor.Singleton<IInstallationLocator, GogLocator>(),
                ServiceDescriptor.Singleton<IInstallationLocator, LocalLocator>(),
            });

        return services.AddSingleton<IOcsIOService, OcsIOService>()
                       .AddSingleton<IModNameResolver, ModNameResolver>()
                       .AddSingleton<IOcsDiscoveryService, OcsDiscoveryService>()
                       .AddSingleton<IOcsDataContextBuilder, OcsDataContextBuilder>()
                       .AddSingleton<IOcsDataBuilder, OcsDataContextBuilder>();
    }
}