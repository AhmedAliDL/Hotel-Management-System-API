using FluentValidation;

namespace Application.Subscriptions.Queries.GetSubscriptionDetails
{
    public class GetSubscriptionDetailsQueryValidator : AbstractValidator<GetSubscriptionDetailsQuery>
    {
        public GetSubscriptionDetailsQueryValidator()
        {
            RuleFor(s => s.CompanyId)
                .NotEmpty()
                .WithMessage("CompanyId is required.");
        }
    }
    
}
