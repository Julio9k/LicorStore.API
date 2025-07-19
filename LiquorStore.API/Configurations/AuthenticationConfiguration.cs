using System.Text;
using LiquorStore.Common;
using LiquorStore.Common.Enums;
using LiquorStore.Common.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LiquorStore.API.Configurations;

public static class AuthenticationConfiguration
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("JwtSettings");

        var jwtSettings = new JwtSettings
        {
            Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? jwtSection["Issuer"]!,
            Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? jwtSection["Audience"]!,
            SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET") ?? jwtSection["SecretKey"]!,
            ExpiryInMinutes = int.TryParse(Environment.GetEnvironmentVariable("JWT_EXPIRY_IN_MINUTES"), out var expiry)
                ? expiry
                : jwtSection.GetValue<int>("ExpiryInMinutes")
        };

        services.Configure<JwtSettings>(opts =>
        {
            opts.Issuer = jwtSettings.Issuer;
            opts.Audience = jwtSettings.Audience;
            opts.SecretKey = jwtSettings.SecretKey;
            opts.ExpiryInMinutes = jwtSettings.ExpiryInMinutes;
        });

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddAuthorization(options =>
        {
            foreach (var role in Enum.GetValues(typeof(RoleCode)))
            {
                options.AddPolicy(role.ToString(), policy =>
                    policy.RequireClaim(Constants.Claims.Role, role.ToString()));
            }
        });

        return services;
    }
}
