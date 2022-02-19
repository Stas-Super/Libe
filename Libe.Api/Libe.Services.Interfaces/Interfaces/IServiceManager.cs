using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Services.Interfaces.Interfaces
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
    }
}
