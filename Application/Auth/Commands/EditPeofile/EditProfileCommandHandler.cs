using Application.Auth.Dtos;
using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.EditPeofile
{
    public class EditProfileCommandHandler : IRequestHandler<EditProfileCommand, ResponseResult<UserProfileDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public EditProfileCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseResult<UserProfileDto>> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.editProfileDto.Email);
            if (user == null)
                ResponseResult<UserProfileDto>.Failure("User not found");

            user!.Fname = request.editProfileDto.Fname ?? user.Fname;
            user.Lname = request.editProfileDto.Lname ?? user.Lname;
            user.UpdateAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            var response = new UserProfileDto
            {
                Email = user.Email!,
                Fname = user.Fname,
                Lname = user.Lname,
            };
            return ResponseResult<UserProfileDto>.Success(response);
        }
    }

}
