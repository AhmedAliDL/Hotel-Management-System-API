using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.SendPasswordResetToken
{
    public record SendPasswordResetTokenCommand(string Email) : IRequest<ResponseResult<bool>>;


}
