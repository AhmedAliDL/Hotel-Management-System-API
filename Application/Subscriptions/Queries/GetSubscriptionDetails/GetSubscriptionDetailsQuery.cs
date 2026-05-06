using Application.Responses;
using Application.Subscriptions.Dtos;
using MediatR;

namespace Application.Subscriptions.Queries.GetSubscriptionDetails
{
    public record GetSubscriptionDetailsQuery(Guid CompanyId) : IRequest<ResponseResult<SubscriptionInfoDto>>;

}
