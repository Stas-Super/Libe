using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libe.DAL.EF
{
    public class ApiDbContext : DbContext 
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }
    }
}
