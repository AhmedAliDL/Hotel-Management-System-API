using FluentValidation;

namespace Application.Auth.Commands.ConfirmEmailToken
{
    public class ConfirmEmailTokenCommandValidator : AbstractValidator<ConfirmEmailTokenCommand>
    {
        public ConfirmEmailTokenCommandValidator()
        {
            RuleFor(c => c.ConfirmEmailDto.UserEmail)
                .NotEmpty()
                .WithMessage("Email must be enetered");
            RuleFor(c => c.ConfirmEmailDto.Token)
                .NotEmpty()
                .WithMessage("Token is required");
        }
    }

}
