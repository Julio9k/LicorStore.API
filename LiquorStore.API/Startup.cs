using LiquorStore.API.Configurations;
using LiquorStore.Infrastructure.Mapping;

namespace LiquorStore.API;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        services.AddSwaggerDocumentation();
        services.ConfigureCorsPolicy();
        services.ConfigureDatabase(Configuration);
        //services.AddJwtAuthentication(Configuration);
        //services.AddEmailSettings(Configuration);

        services.RegisterApplicationServices(); ///
        services.ConfigureMapsterMappings();

        //services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
        //services.AddFluentValidationAutoValidation();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        //app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseRouting();
        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
