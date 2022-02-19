using AutoMapper;
using Libe.Domain.Core.Entities;
using Libe.Infrastructure.Data.EF;
using Libe.Services.Interfaces.Interfaces;
using Libe.Services.Interfaces.Models;
using Libe.Services.Interfaces.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Libe.Infrastructure.Bussines.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiDbContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly IMapper _mapper;
        public AuthenticationService(
            ApiDbContext ctx, 
            UserManager<User> userManager,
            IOptions<JwtOptions> jwtOptions,
            IMapper mapper)
        {
            _ctx = ctx;
            _userManager = userManager;
            _jwtOptions = jwtOptions;
            _mapper = mapper;
        }

        public async Task<LogInResponseModel> LogIn(LogInRequestModel model)
        {
           var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
               return new LogInResponseModel { VarificationResponse = "User not found" };

            var passwordVarification = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (passwordVarification == PasswordVerificationResult.Failed)
                return new LogInResponseModel { VarificationResponse = "Password not valid" };

            var jwt = Generate(user);

            return new LogInResponseModel { User = user, VarificationResponse = jwt };
        }

        private string Generate(User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                     _jwtOptions.Value.Issure,
                     _jwtOptions.Value.Audience,
                     new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) },
                     DateTime.UtcNow,
                     DateTime.UtcNow.AddMinutes(_jwtOptions.Value.ExpiresAfterMitutes),
                     new SigningCredentials(
                         new SymmetricSecurityKey(_jwtOptions.Value.SigningKeyBytes),
                             SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public async Task<RegistrationResponseModel> Registration(RegistrationRequestModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
                return new RegistrationResponseModel { VarificationResult = "User allready created" };

            var userResponse = _mapper.Map<User>(model);

            _userManager.PasswordHasher.HashPassword(userResponse, model.Password);

           await _userManager.CreateAsync(userResponse);

            await _ctx.SaveChangesAsync();

            var jwt = Generate(user);

            return new RegistrationResponseModel { User = user, VarificationResult = jwt};
        }
    }
}
