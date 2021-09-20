using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenConstructionSet;
using OpenConstructionSet.Data;
using OpenConstructionSet.IO.Discovery;

namespace Microsoft.Extensions.DependencyInjection;

public static class OcsServiceCollectionExtensions
{
    public static IServiceCollection UseOpenContructionSet(this IServiceCollection services)
    {
        services.TryAddEnumerable(new[]
        {
                ServiceDescriptor.Singleton<IFolderLocator, LocalFolderLocator>(),
                ServiceDescriptor.Singleton<IFolderLocator, SteamFolderLocator>(),
                ServiceDescriptor.Singleton<IFolderLocator, GogFolderLocator>(),
            });

        services.TryAddEnumerable(ServiceDescriptor.Singleton<IModNameResolver, ModNameResolver>());

        return services.AddSingleton<IOcsFileService, OcsFileService>()
                       .AddSingleton<IOcsDiscoveryService, OcsDiscoveryService>()
                       .AddSingleton<IOcsDataContextBuilder, OcsDataContextBuilder>();
    }
}
