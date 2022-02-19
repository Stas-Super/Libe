using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Services.Interfaces.Models
{
    public class RegistrationRequestModel
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public DateTime Bearthday { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
