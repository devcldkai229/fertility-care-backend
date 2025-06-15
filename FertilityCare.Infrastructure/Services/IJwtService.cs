using FertilityCare.Domain.Entities;
using FertilityCare.Infrastructure.Configurations;
using FertilityCare.Infrastructure.Identity;
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

        Task<string> GenerateRefreshToken(IEnumerable<Claim> claims);

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

        bool ValidateToken(string token);

    }

    public class JwtService : IJwtService
    {
        private readonly JwtConfiguration _jwtConfig;

        private readonly FertilityCareDBContext _context;

        public JwtService(IOptions<JwtConfiguration> jwtConfiguration, FertilityCareDBContext context)
        {
            _jwtConfig = jwtConfiguration.Value;
            _context = context;
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

        public async Task<string> GenerateRefreshToken(IEnumerable<Claim> claims)
        {
            var principal = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (principal is null)
            {
                throw new UnauthorizedAccessException("Invalid user claim!");
            }

            if(!Guid.TryParse(principal.Value, out var result))
            {
                throw new UnauthorizedAccessException("Invalid user!");
            }

            var randomNumber = new byte[64];
            using var r = RandomNumberGenerator.Create();
            r.GetBytes(randomNumber);
            var token = Convert.ToBase64String(randomNumber);

            var refreshToken = new RefreshToken
            {
                Token = token,
                UserId = result,
                ExpiredAt = DateTime.UtcNow.AddDays(_jwtConfig.RefreshTokenExpirationInDays),
                CreatedAt = DateTime.UtcNow
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return token;
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey)),
                ValidateLifetime = false
            };

            var handler = new JwtSecurityTokenHandler();

            try
            {
                var principal = handler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                    !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }

                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var hanlder = new JwtSecurityTokenHandler();

                hanlder.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey)),
                    ValidIssuer = _jwtConfig.Issuer,
                    ValidAudience = _jwtConfig.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken securityToken);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
