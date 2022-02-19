using Libe.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Infrastructure.Data.EF
{
    public class ApiDbContext : IdentityDbContext<User,Role,int>, IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public ApiDbContext() { }

        public ApiDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApiDbContext>();
            builder.UseSqlServer("Server=tcp:libe-dev-sql-srv.database.windows.net,1433;Initial Catalog=libe-dev-sql-db;Persist Security Info=False;User ID=libe-dev-sa;Password=cJM23H87;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApiDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new ApiDbContext(builder.Options);
        }
    }
}
