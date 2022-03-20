using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Domain.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
    }
}
