using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Business.Dtos
{
    public class LogInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
