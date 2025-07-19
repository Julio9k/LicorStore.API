using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace LiquorStore.Infrastructure.Mapping;

public static class MapsterConfiguration
{
    public static IServiceCollection ConfigureMapsterMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        ProductMappings.Register(config);
       
        config.Compile();
        return services;
    }
}