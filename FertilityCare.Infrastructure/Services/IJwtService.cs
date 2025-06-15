using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
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
