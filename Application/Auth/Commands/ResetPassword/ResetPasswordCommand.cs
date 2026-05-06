using Application.Auth.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.ResetPassword
{
    public record ResetPasswordCommand(ResetPasswordDto ResetPasswordDto) : IRequest<ResponseResult<bool>>;

}
