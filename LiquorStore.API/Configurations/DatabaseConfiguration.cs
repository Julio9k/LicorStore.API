using LiquorStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.API.Configurations;

public static class DatabaseConfiguration
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("LiquorStore.Infrastructure")));
        return services;
    }
}