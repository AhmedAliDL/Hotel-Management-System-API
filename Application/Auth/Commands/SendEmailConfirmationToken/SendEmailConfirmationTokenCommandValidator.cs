using FluentValidation;

namespace Application.Auth.Commands.EmailConfirm
{
    public class SendEmailConfirmationTokenCommandValidator : AbstractValidator<SendEmailConfirmationTokenCommand>
    {
        public SendEmailConfirmationTokenCommandValidator()
        {
            RuleFor(e => e.UserEmail)
                .NotEmpty()
                .WithMessage("Email should not be empty");
        }
    }
}
