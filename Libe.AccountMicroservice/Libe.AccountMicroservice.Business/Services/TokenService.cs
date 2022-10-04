using Libe.AccountMicroservice.Business.Interfaces;
using Libe.AccountMicroservice.Business.Options;
using Libe.AccountMicroservice.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AuthenticationOptions> _options;

        public TokenService(IOptions<AuthenticationOptions> options)
        {
            _options = options;
        }

        public string GenerateAccessToken(User user)
        {
            var jwt = new JwtSecurityToken(
                _options.Value.Issuer,
                _options.Value.Audience,
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Role, user.RoleName)
                },
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_options.Value.ExpiresAfterMitutes),
                new SigningCredentials(
                        new SymmetricSecurityKey(_options.Value.SigningKeyBytes),
                        SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string GenerateRefreshToken()
        {
            var code = new byte[1024];
            using (var randomNamberGenerator = RandomNumberGenerator.Create())
            {
                randomNamberGenerator.GetBytes(code);
                return Convert.ToBase64String(code);
            }
        }
    }
}
