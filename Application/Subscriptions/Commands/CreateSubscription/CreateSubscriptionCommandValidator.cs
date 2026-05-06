using FluentValidation;

namespace Application.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
    {
        public CreateSubscriptionCommandValidator()
        {
            RuleFor(c => c.SubscriptionDto.CompanyId)
                .NotEmpty()
                .WithMessage("CompanyId is required.");
            RuleFor(c => c.SubscriptionDto.PlanName)
                .IsInEnum()
                .WithMessage("PlanName must be a valid subscription plan.");
        }
    }
}
