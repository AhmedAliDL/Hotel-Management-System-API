using Application.Common.Interfaces;
using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, ResponseResult<bool>>
    {
        private readonly IJwtTokenService _jwtTokenService;
        public LogoutCommandHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        async Task<ResponseResult<bool>> IRequestHandler<LogoutCommand, ResponseResult<bool>>.Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return await _jwtTokenService.RevokeTokenAsync(request.refreshToken);
        }
    }

}
