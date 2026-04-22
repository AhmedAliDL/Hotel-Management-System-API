using Application.Auth.Dtos;
using Application.Responses;
using MediatR;


namespace Application.Auth.Commands.Login
{
    public record LoginCommand(LoginDto LoginDto) : IRequest<ResponseResult<LoginResponseDto>>;

}
