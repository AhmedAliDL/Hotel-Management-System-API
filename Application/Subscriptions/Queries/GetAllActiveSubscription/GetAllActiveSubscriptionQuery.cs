using Application.Subscriptions.Dtos;
using MediatR;

namespace Application.Subscriptions.Queries.GetAllActiveSubscription
{
    public record GetAllActiveSubscriptionQuery : IRequest<List<ActiveSubscriptionInfoDto>>;

}
