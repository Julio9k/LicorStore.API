using LiquorStore.Application.Implementations;
using LiquorStore.Application.Interfaces;
using LiquorStore.Infrastructure.Repositories.Implementations;
using LiquorStore.Infrastructure.Repositories.Interfaces;

namespace LiquorStore.API.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        // Applications
        services.AddScoped<IProductApplication, ProductApplication>();
     

        // Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
      

        // External services
        //services.AddScoped<IJwtService, JwtService>();
        

        // Middlewares
        //services.AddTransient<ExceptionHandlingMiddleware>();

        return services;
    }
}