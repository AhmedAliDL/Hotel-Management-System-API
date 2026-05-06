using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.Logout
{
    public record LogoutCommand(string RefreshToken) : IRequest<ResponseResult<bool>>;

}
