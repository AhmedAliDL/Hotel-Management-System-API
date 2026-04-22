using Application.Auth.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.ChangePassword
{
    public record ChangePasswordCommand(ChangePasswordDto ChangePasswordDto) : IRequest<ResponseResult<bool>>;

}
