using FertilityCare.Infrastructure.Configurations;
using FertilityCare.Infrastructure.Identity;
using FertilityCare.UseCase.DTOs.Auths;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(LoginRequest request);

        Task<AuthResult> GoogleLoginAsync(GoogleLoginRequest request);

        Task<AuthResult> RefreshTokenAsync(RefreshTokenRequest request);

        Task<bool> LogoutAsync(string userId);

        Task<AuthResult> RegisterAsync(RegisterRequest request);

    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IJwtService _jwtService;

        private readonly JwtConfiguration _jwtConfig;

        private readonly GoogleAuthConfiguration _googleConfig;

        public AuthService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            IJwtService jwtService, IOptions<JwtConfiguration> jwtConfig, 
            IOptions<GoogleAuthConfiguration> googleConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _jwtConfig = jwtConfig.Value;
            _googleConfig = googleConfig.Value;
        }

        public Task<AuthResult> GoogleLoginAsync(GoogleLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
