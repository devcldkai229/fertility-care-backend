using FertilityCare.Domain.Entities;
using FertilityCare.Domain.Enums;
using FertilityCare.Infrastructure.Configurations;
using FertilityCare.Infrastructure.Identity;
using FertilityCare.UseCase.DTOs.Auths;
using FertilityCare.UseCase.DTOs.Users;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public async Task<AuthResult> GoogleLoginAsync(GoogleLoginRequest request)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _googleConfig.ClientId }
                });

                var user = await _userManager.FindByEmailAsync(payload.Email);

                if (user is null)
                {
                    if (payload.EmailVerified)
                    {
                        var profileId = Guid.NewGuid();

                        ApplicationUser newUser = new ApplicationUser
                        {
                            Id = Guid.NewGuid(),
                            UserName = payload.Email,
                            Email = payload.Email,
                            EmailConfirmed = payload.EmailVerified,
                            GoogleId = payload.Subject,
                            IsGoogleAccount = true,
                            UserProfileId = profileId,
                            UserProfile = new UserProfile
                            {
                                Id = profileId,
                                FirstName = payload.GivenName,
                                MiddleName = "",
                                LastName = payload.FamilyName,
                                AvatarUrl = payload.Picture
                            }
                        };

                        var createResult = await _userManager.CreateAsync(newUser);
                        if (!createResult.Succeeded)
                        {
                            return AuthResult.Failed("Failed to create user account");
                        }
                    }
                }
                else if (!user.IsGoogleAccount)
                {
                    user.GoogleId = payload.Subject;
                    user.IsGoogleAccount = true;
                    await _userManager.UpdateAsync(user);

                }

                user.LastLogin = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return await GenerateTokenAsync(user);
            }
            catch(Exception ex)
            {
                return AuthResult.Failed("Google login failed");
            }
        }

        public async Task<AuthResult> LoginAsync(LoginRequest request)
        {
            try
            {
                var loadedUser = await _userManager.FindByEmailAsync(request.Email);
                if (loadedUser is null)
                {
                    return AuthResult.Failed("Invalid credentials!");
                }

                if(await _userManager.IsLockedOutAsync(loadedUser))
                {
                    return AuthResult.Failed("Account is locked on!");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(loadedUser, request.Password, true);
                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        return AuthResult.Failed("Account locked due to multiple failed attempts");
                    }

                    return AuthResult.Failed("Invalid credentials");
                }

                loadedUser.LastLogin = DateTime.UtcNow;
                loadedUser.FailedLoginAttempts = 0;
                await _userManager.UpdateAsync(loadedUser);

                return await GenerateTokenAsync(loadedUser);
            }
            catch (Exception ex) 
            {
                return AuthResult.Failed("Login failed");
            }
        }

        public async Task<bool> LogoutAsync(string userId)
        {
            try
            {
                if (!Guid.TryParse(userId, out var id))
                {
                    return false;
                }

                var loadedUser = await _userManager.FindByIdAsync(id.ToString());
                if (loadedUser is null)
                {
                    return false;
                }

                loadedUser.RefreshToken = null;
                loadedUser.RefreshTokenExpiryTime = null;

                await _userManager.UpdateAsync(loadedUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<AuthResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<AuthResult> GenerateTokenAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Email, user.Email ?? ""),
                new ("userProfileId", user.UserProfileId.ToString())
            };

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            var accessToken = _jwtService.GenerateAccessToken(claims);
            var refreshToken = _jwtService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtConfig.RefreshTokenExpirationInDays);

            await _userManager.UpdateAsync(user);

            return AuthResult.Success(new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpirationInMinutes),
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.UserProfile.FirstName,
                    MiddleName = user.UserProfile.MiddleName,
                    LastName = user.UserProfile.LastName,
                    AvatarUrl = user.UserProfile.AvatarUrl,
                }
            });
        }
    }
}
