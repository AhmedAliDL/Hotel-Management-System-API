using Application.Responses;
using Application.Subscriptions.Dtos;
using MediatR;

namespace Application.Subscriptions.Commands.EditSubscription
{
    public record EditSubscriptionCommand(SubscriptionDto EditSubscriptionDto) : IRequest<ResponseResult<bool>>;

}
