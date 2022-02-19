using Libe.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Services.Interfaces.Models
{
    public class RegistrationResponseModel
    {
        public User User { get; set; }
        public string VarificationResult { get; set; }
    }
}
