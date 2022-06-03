using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BlazorProject.Api.WebApi.Extensions;

public static class AuthRegistration
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"]));

        services.AddAuthentication(
            options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    IssuerSigningKey = signingKey
                };
            });

        return services;
    }
}
