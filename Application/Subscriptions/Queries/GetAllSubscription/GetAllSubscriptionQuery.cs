using Application.Subscriptions.Dtos;
using MediatR;

namespace Application.Subscriptions.Queries.GetAllSubscription
{
    public record GetAllSubscriptionQuery : IRequest<List<SubscriptionInfoDto>>;

}
