using Application.Auth.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.ConfirmEmailToken
{
    public record ConfirmEmailTokenCommand(ConfirmEmailDto ConfirmEmailDto) : IRequest<ResponseResult<bool>>;

}
