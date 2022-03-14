using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models.JWT;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PersonManagement.Services.Implementations
{
    public class JWTService : IJWTService
    {
        private readonly string _secret;
        private readonly int _expDateInMinutes;

        public JWTService(IOptions<JWTConfiguration> options)
        {
            _secret = options.Value.Secret;
            _expDateInMinutes = options.Value.ExpirationInMinutes;
        }

        public string GenerateSecurityToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expDateInMinutes),
                Audience = "localhost",
                Issuer = "localhost",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
