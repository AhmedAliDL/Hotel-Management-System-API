using Application.Auth.Dtos;
using Application.Responses;
using MediatR;

namespace Application.Auth.Queries.Profile
{
    public record GetUserProfileQuery(string email) : IRequest<ResponseResult<UserProfileDto>>;

}
