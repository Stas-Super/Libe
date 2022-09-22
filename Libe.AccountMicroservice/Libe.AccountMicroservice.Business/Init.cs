using Microsoft.Extensions.DependencyInjection;

namespace Libe.AccountMicroservice.Business
{
    public static class Init
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}