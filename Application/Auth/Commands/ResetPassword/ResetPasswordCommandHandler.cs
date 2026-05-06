using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ResponseResult<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.ResetPasswordDto.UserEmail);
            if (user == null)
                return ResponseResult<bool>.Failure("User not found");
            var result = await _userManager.ResetPasswordAsync(user, request.ResetPasswordDto.ValidationToken, request.ResetPasswordDto.NewPassword);
            if (!result.Succeeded)
                return ResponseResult<bool>.Failure("Invalid validation token");
            return ResponseResult<bool>.Success(true);
        }
    }

}
