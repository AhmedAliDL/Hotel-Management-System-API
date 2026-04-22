using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.EmailConfirm
{
    public record SendEmailConfirmationTokenCommand(string userEmail) : IRequest<ResponseResult<bool>>;
}
