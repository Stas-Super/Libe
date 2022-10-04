using Libe.AccountMicroservice.Domain.EF;
using Libe.AccountMicroservice.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace Libe.AccountMicroservice.Api.AppSetup
{
    public static class IdentityConfigurator
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            }).AddRoles<Role>()
           .AddEntityFrameworkStores<AccountMicroserviceDbContext>();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AccountMicroserviceDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
