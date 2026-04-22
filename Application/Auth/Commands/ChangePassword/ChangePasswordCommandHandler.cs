using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        async Task<ResponseResult<bool>> IRequestHandler<ChangePasswordCommand, ResponseResult<bool>>.Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.ChangePasswordDto.UserEmail);
            if (user == null)
                return ResponseResult<bool>.Failure("User not found");
            var checkPassword = await _userManager.CheckPasswordAsync(user, request.ChangePasswordDto.CurrentPassword);
            if (!checkPassword)
                return ResponseResult<bool>.Failure("Current Password is wrong!");

            await _userManager.ChangePasswordAsync(user, request.ChangePasswordDto.CurrentPassword, request.ChangePasswordDto.NewPassword);

            return ResponseResult<bool>.Success(true);
        }
    }

}
