using Application.Auth.Dtos;
using Application.Common.Interfaces;
using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand,ResponseResult<RefreshTokenDto>>
    {
        private readonly IJwtTokenService _jwtTokenService;
        public RefreshTokenCommandHandler(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        public async Task<ResponseResult<RefreshTokenDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _jwtTokenService.RefreshTokenAsync(request.refreshToken);
        }
    }

}
