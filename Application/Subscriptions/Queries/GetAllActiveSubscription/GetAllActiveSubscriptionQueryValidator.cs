using Application.Subscriptions.Queries.GetAllActiveSubscription;
using FluentValidation;

namespace Application.Subscriptions.Queries.GetAllSubscription
{
    public class GetAllActiveSubscriptionQueryValidator : AbstractValidator<GetAllActiveSubscriptionQuery>
    {
        // No validation rules for this query as it does not contain any parameters
    }

}
