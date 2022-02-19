using Libe.Services.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Services.Interfaces.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LogInResponseModel> LogIn(LogInRequestModel model);
        Task<RegistrationResponseModel> Registration(RegistrationRequestModel model);
    }
}
