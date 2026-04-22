using Application.Auth.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Auth.Commands.EditPeofile
{
    public record EditProfileCommand(EditProfileDto editProfileDto) : IRequest<ResponseResult<UserProfileDto>>;

}
