using FluentValidation;

namespace Application.Auth.Commands.SendPasswordResetToken
{
    public class SendPasswordResetTokenCommandValidator : AbstractValidator<SendPasswordResetTokenCommand>
    {
        public SendPasswordResetTokenCommandValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage("Email should not be empty");
        }
    }


}
