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
                ServiceDescriptor.Singleton<IFolderLocator, SteamFolderLocator>(),
                ServiceDescriptor.Singleton<IFolderLocator, GogFolderLocator>(),
                ServiceDescriptor.Singleton<IFolderLocator, LocalFolderLocator>(),
            });

        services.TryAddEnumerable(ServiceDescriptor.Singleton<IModNameResolver, ModNameResolver>());

        return services.AddSingleton<IOcsService, OcsService>()
                       .AddSingleton<IOcsDataContextBuilder, OcsDataContextBuilder>();
    }
}
