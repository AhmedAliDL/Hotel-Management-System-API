using Application.Auth.Dtos;
using Application.Responses;
using Domain.Entities.User;
using Domain.Entities.UserEntity;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Common.Interfaces
{
    public interface IJwtTokenService : IServiceMarker
    {
        Task<JwtSecurityToken> CreateJWTTokenAsync(ApplicationUser user);
        RefreshToken CreateRefreshToken();
        Task<ResponseResult<RefreshTokenDto>> RefreshTokenAsync(string token);
        Task<ResponseResult<bool>> RevokeTokenAsync(string token);
    }
}
