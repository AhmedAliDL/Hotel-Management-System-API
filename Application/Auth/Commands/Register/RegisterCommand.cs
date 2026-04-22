using Application.Auth.Dtos;
using MediatR;

namespace Application.Auth.Commands.Register
{
    public record RegisterCommand(RegisterDto Register) : IRequest<Guid>;
}
