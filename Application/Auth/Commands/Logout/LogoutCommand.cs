using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.Logout
{
    public record LogoutCommand(string refreshToken) : IRequest<ResponseResult<bool>>;

}
