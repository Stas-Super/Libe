using AutoMapper;
using Libe.Domain.Core.Entities;
using Libe.Infrastructure.Data.EF;
using Libe.Services.Interfaces.Interfaces;
using Libe.Services.Interfaces.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Infrastructure.Bussines.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(
            ApiDbContext ctx,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<JwtOptions> jwtOptions,
            IMapper mapper)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(ctx,userManager,roleManager,jwtOptions, mapper));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
