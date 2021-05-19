using Libe.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libe.DAL.Identity
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> userStore, IOptions<IdentityOptions> options,  IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer normalizer,IdentityErrorDescriber describer, IServiceProvider service, ILogger<UserManager<User>> logger) 
            : base(userStore, options, passwordHasher, userValidators, passwordValidators, normalizer, describer, service, logger) { }
    }
}
