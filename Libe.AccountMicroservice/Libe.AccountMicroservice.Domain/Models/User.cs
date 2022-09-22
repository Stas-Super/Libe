using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
