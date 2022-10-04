using Libe.AccountMicroservice.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Domain.EF
{
    public class AccountMicroserviceDbContext : IdentityDbContext<User, Role, int>, IDesignTimeDbContextFactory<AccountMicroserviceDbContext>
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountMicroserviceDbContext(DbContextOptions<AccountMicroserviceDbContext> options) : base(options) { }
        public AccountMicroserviceDbContext() { }

        public AccountMicroserviceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AccountMicroserviceDbContext>();
            builder.UseSqlServer("Server=tcp:libe-sql-srv.database.windows.net,1433;Initial Catalog=libe-dev-sql-db;Persist Security Info=False;User ID=libe-dev-sa;Password=cJM23H87;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(AccountMicroserviceDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new AccountMicroserviceDbContext(builder.Options);
        }
    }
}
