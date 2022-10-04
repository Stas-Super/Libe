using Libe.AccountMicroservice.Domain.EF;
using Microsoft.EntityFrameworkCore;

namespace Libe.AccountMicroservice.Api.AppSetup
{
    public static class DbContextConfigurator
    {
        public static void ConfiugreDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountMicroserviceDbContext>(ctxOptions =>
            {
                ctxOptions.UseSqlServer(
                    configuration.GetConnectionString("DevelopmentConnection"),
                    options => options.MigrationsAssembly("../Libe.AccountMicroservice.Domain"));
            });
        }
    }
}
