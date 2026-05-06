using Application.Auth.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.RefreshToken
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<ResponseResult<RefreshTokenDto>>;

}
