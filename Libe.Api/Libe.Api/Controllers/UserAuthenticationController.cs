using Libe.Services.Interfaces.Interfaces;
using Libe.Services.Interfaces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Libe.Api.Controllers
{
    [Route("api/user/authentication")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UserAuthenticationController(IServiceManager serviceManager) =>
            _serviceManager = serviceManager;

        [HttpPost("log-in")]
        public async Task<LogInResponseModel> LogIn([FromBody] LogInRequestModel model) =>
            await _serviceManager.AuthenticationService.LogIn(model);

        [HttpPost("registration")]
        public async Task<RegistrationResponseModel> Registration([FromBody] RegistrationRequestModel model) =>
            await _serviceManager.AuthenticationService.Registration(model);
    }
}
