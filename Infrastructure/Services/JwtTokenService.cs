using Application.Auth.Dtos;
using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities.User;
using Domain.Entities.UserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public JwtTokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<JwtSecurityToken> CreateJWTTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName ?? user.Email ?? string.Empty),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]!));

            var signingCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha384);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpirationInMinutes"]!)),
                signingCredentials: signingCredentials);

            return token;
        }
        public RefreshToken CreateRefreshToken()
        {
            var randomNum = RandomNumberGenerator.GetBytes(32);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNum),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
            };

        }
        public async Task<ResponseResult<RefreshTokenDto>> RefreshTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens!.Any(t => t.Token == token));
            if (user == null)
            {
                return ResponseResult<RefreshTokenDto>.Failure("User is not found.");
            }
            var refreshToken = user.RefreshTokens!.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
            {
                return ResponseResult<RefreshTokenDto>.Failure("Inactive token.");
            }
            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = CreateRefreshToken();
            user.RefreshTokens!.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);
            var jwtToken = await CreateJWTTokenAsync(user);

            var response = new RefreshTokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = jwtToken.ValidTo,
                RefreshToken = newRefreshToken.Token,
                RefreshTokenExpiration = newRefreshToken.ExpiresOn,
            };

            return ResponseResult<RefreshTokenDto>.Success(response);

        }
        public async Task<ResponseResult<bool>> RevokeTokenAsync(string token)
        {

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens!.Any(t => t.Token == token));
            if (user == null)
            {
                return ResponseResult<bool>.Failure("User is not found.");
            }
            var refreshToken = user.RefreshTokens!.Single(t => t.Token == token);
            if (!refreshToken.IsActive)
            {
                return ResponseResult<bool>.Failure("Inactive token.");
            }
            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return ResponseResult<bool>.Success(true);
        }
    }
}
