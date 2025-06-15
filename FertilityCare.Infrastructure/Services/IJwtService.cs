using FertilityCare.Infrastructure.Configurations;
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

namespace FertilityCare.Infrastructure.Services
{
    public interface IJwtService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken(IEnumerable<Claim> claims);

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

        bool ValidateToken(string token);

    }

    public class JwtService : IJwtService
    {
        private readonly JwtConfiguration _jwtConfig;

        public JwtService(IOptions<JwtConfiguration> jwtConfiguration)
        {
            _jwtConfig = jwtConfiguration.Value;
        }


        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtConfig.ExpirationInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken(IEnumerable<Claim> claims)
        {
            var randomNumber = new byte[64];
            using var r = RandomNumberGenerator.Create();
            r.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
