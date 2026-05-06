using Application.Responses;
using Application.Subscriptions.Dtos;
using MediatR;

namespace Application.Subscriptions.Commands.CreateSubscription
{
    public record CreateSubscriptionCommand(SubscriptionDto SubscriptionDto) : IRequest<ResponseResult<Guid>>;
}
