using Application.Config;
using Application.Conmon.Request.Identity;
using Application.Conmon.Response.Identity;
using Application.Repositery.Service;
using Domain.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Share.Wapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Implementation.Service
{
    public class IdentityService : ITokenService
    {

        private readonly AppConfig _appConfig;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public IdentityService(
           UserManager<User> userManager, RoleManager<Role> roleManager,
           IOptions<AppConfig> appConfig, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appConfig = appConfig.Value;
            _signInManager = signInManager;
        }

        public async Task<Response<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model)
        {
            if (model is null) return await Response<TokenResponse>.FailAsync("Invalid Client Token.");
            var userPrincipal = GetPrincipalFromExpiredToken(model.Token!);
            var userName = userPrincipal?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return await Response<TokenResponse>.FailAsync("Invalid Client Token.");
            var token = GenerateEncryptedToken(GetSigningCredentials(), await GetClaimsAsync(user));

            user.RefreshToken = GenerateRefreshToken();
            await _userManager.UpdateAsync(user);

            var response = new TokenResponse
            {
                Token = token,
                RefreshToken = user.RefreshToken,
                RefreshTokenExpiryTime = user.RefreshTokenExpiryTime
            };
            return await Response<TokenResponse>.SuccessAsync(response);
        }


        public async Task<Response<TokenResponse>> LoginAsync(TokenRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return await Response<TokenResponse>.FailAsync("User Not Found.");
            if (user.Status != true)
                return await Response<TokenResponse>.FailAsync("User Not Active. Please contact the administrator.");
            if (!user.EmailConfirmed) return await Response<TokenResponse>.FailAsync("Email not confirmed.");
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid) return await Response<TokenResponse>.FailAsync("Invalid Credentials.");

            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(user);
            var token = await GenerateJwtAsync(user);
            var response = new TokenResponse { 
                Token = token,
                RefreshToken = user.RefreshToken,
                RefreshTokenExpiryTime = user.RefreshTokenExpiryTime.ToUniversalTime() //ToString("MMM ddd dd yyyy HH: mm:ss tt")
            };
            return await Response<TokenResponse>.SuccessAsync(response);
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private async Task<string> GenerateJwtAsync(User user)
        {
            var token = GenerateEncryptedToken(GetSigningCredentials(), await GetClaimsAsync(user));
            return token;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var secret = Encoding.UTF8.GetBytes(_appConfig.Secret!);
            return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
        }
        private static string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptedToken = tokenHandler.WriteToken(token);
            return encryptedToken;
        }
        private async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            var permissionClaims = new List<Claim>();
            for (var i = roles.Count - 1; i >= 0; i--)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
                var thisRole = await _roleManager.FindByNameAsync(roles[i]);
                var allPermissionsForThisRoles = await _roleManager.GetClaimsAsync(thisRole);
                permissionClaims.AddRange(allPermissionsForThisRoles);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, user.FirstName!),
                new(ClaimTypes.Surname, user.LastName!),
                new(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty)
            }.Union(userClaims).Union(roleClaims).Union(permissionClaims);

            return claims;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Secret!)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RoleClaimType = ClaimTypes.Role,
                ClockSkew = TimeSpan.FromDays(1)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
