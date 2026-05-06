using FluentValidation;

namespace Application.Subscriptions.Commands.EditSubscription
{
    public class EditSubscriptionCommandValidator : AbstractValidator<EditSubscriptionCommand>
    {
        public EditSubscriptionCommandValidator()
        {
            RuleFor(c => c.EditSubscriptionDto.CompanyId)
                .NotEmpty()
                .WithMessage("CompanyId is required.");
            RuleFor(c => c.EditSubscriptionDto.PlanName)
                .IsInEnum()
                .WithMessage("PlanName must be a valid subscription plan.");
        }
    }

}
