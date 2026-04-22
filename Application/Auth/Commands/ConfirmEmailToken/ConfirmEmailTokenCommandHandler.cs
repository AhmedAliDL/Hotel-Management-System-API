using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.ConfirmEmailToken
{
    public class ConfirmEmailTokenCommandHandler : IRequestHandler<ConfirmEmailTokenCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ConfirmEmailTokenCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        async Task<ResponseResult<bool>> IRequestHandler<ConfirmEmailTokenCommand, ResponseResult<bool>>.Handle(ConfirmEmailTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.ConfirmEmailDto.UserEmail);
            if (user == null)
            {
                return ResponseResult<bool>.Failure("User not found");
            }
            var result = await _userManager.ConfirmEmailAsync(user, request.ConfirmEmailDto.Token);
            if (!result.Succeeded)
                return ResponseResult<bool>.Failure("Confirm Email Code is Wrong!");
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            return ResponseResult<bool>.Success(true);
        }
    }

}
