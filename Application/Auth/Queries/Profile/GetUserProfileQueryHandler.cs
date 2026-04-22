using Application.Auth.Dtos;
using Application.Responses;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Queries.Profile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, ResponseResult<UserProfileDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public GetUserProfileQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseResult<UserProfileDto>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if (user == null)
                return ResponseResult<UserProfileDto>.Failure("User not found.");
            var response = new UserProfileDto
            {
                Email = user.Email!,
                Fname = user.Fname,
                Lname = user.Lname

            };
            return ResponseResult<UserProfileDto>.Success(response);
        }
    }

}
