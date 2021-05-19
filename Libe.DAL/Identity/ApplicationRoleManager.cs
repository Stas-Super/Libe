using Libe.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libe.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<Role>
    {
        public ApplicationRoleManager(IRoleStore<Role> roleStore, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer normalizer, IdentityErrorDescriber identityError, ILogger<RoleManager<Role>> logger)
            : base(roleStore, roleValidators, normalizer, identityError, logger) { }
    }
}
