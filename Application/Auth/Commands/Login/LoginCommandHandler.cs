using Application.Auth.Dtos;
using Application.Common.Interfaces;
using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;


namespace Application.Auth.Commands.Login
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseResult<LoginResponseDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(UserManager<ApplicationUser> userManager, IConfiguration configuration, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _configuration = configuration;
        }
        public async Task<ResponseResult<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(request.LoginDto.Email);

            if (user is null)
            {
                return ResponseResult<LoginResponseDto>.Failure("Invalid email or passowrd");
            }
            var checkPassword = await _userManager.CheckPasswordAsync(user!, request.LoginDto.Password);
            if (!checkPassword)
            {
                return ResponseResult<LoginResponseDto>.Failure("Invalid email or passowrd");
            }

            var token = await _jwtTokenService.CreateJWTTokenAsync(user);
            var response = new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
            if (user.RefreshTokens!.Any(rt => rt.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens!.SingleOrDefault(t => t.IsActive);
                response.RefreshToken = activeRefreshToken!.Token;
                response.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = _jwtTokenService.CreateRefreshToken();
                response.RefreshToken = refreshToken.Token;
                response.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens!.Add(refreshToken);
            }
            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return ResponseResult<LoginResponseDto>.Success(response);
        }
    }

}
