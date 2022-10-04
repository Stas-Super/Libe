using Libe.AccountMicroservice.Domain.Interfaces;
using Libe.AccountMicroservice.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Libe.AccountMicroservice.Domain
{
    public static class Init
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient<IAccountRepository, AccountRepository>();
        }
    }
}