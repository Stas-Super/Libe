using Libe.AccountMicroservice.Business.Interfaces;
using Libe.AccountMicroservice.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Libe.AccountMicroservice.Business
{
    public static class Init
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IAccountService, AccountService>();
        }
    }
}