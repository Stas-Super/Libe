using Microsoft.Extensions.Options;
using Libe.AccountMicroservice.Business.Options;
using Microsoft.IdentityModel.Tokens;

namespace Libe.AccountMicroservice.Api.AppSetup
{
    public static class AuthenticationConfigurator
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Auth:Jwt:Issure"],
                        ValidAudience = configuration["Auth:Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(configuration["Auth:Jwt:SigningKey"]))
                    };
                });
            return services;
        }
    }
}
